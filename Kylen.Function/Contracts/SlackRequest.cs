using Kylen.Domain.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Text;

namespace Kylen.Function.Contracts
{
    public class SlackRequest
    {
        public string token { get; set; }
        public string team_id { get; set; }
        public string team_domain { get; set; }
        public string enterprise_id { get; set; }
        public string enterprise_name { get; set; }
        public string channel_id { get; set; }
        public string channel_name { get; set; }
        public string user_id { get; set; }
        public string user_name { get; set; }
        public string command { get; set; }
        public string text { get; set; }
        public string response_url { get; set; }
        public string trigger_id { get; set; }

        public SlackRequest(IFormCollection formCollection)
        {
            user_name = formCollection["user_name"].ToString();
            command = formCollection["command"].ToString();
            text = formCollection["text"].ToString();
        }

        public DrinkRequest ToDrinkRequest( SlackRequest slackRequest)
        {
            var texts = slackRequest.text.Split(new char[] { ' ' }, 3);
            var enumType = (EnumType)Enum.Parse(typeof(EnumType), texts[0].ToUpper());
            if (enumType == EnumType.STATUS)
            {
                return new DrinkRequest
                {
                    EnumType = enumType
                };
            };

            var drinkName = GetDrinkName(texts);

            return new DrinkRequest
            {
                EnumType = enumType,
                User = slackRequest.user_name,
                Drinks = new Drink
                {
                    Name = drinkName,
                    Quantity = Convert.ToInt32(texts[1])
                }
            };
        }

        private static string GetDrinkName(string[] texts)
        {
            var stringBuilder = new StringBuilder();
            var drinkNames = texts[2]
                .ToLower()
                .Split(new char[] { ' ' });

            foreach (var drinkName in drinkNames)
            {
                NormalizeDrinkName(stringBuilder, drinkName);
            }

            return stringBuilder.ToString();
        }

        private static void NormalizeDrinkName(StringBuilder stringBuilder, string drinkName)
        {
            var drinkNameLetters = drinkName.ToCharArray();
            drinkNameLetters[0] = char.ToUpper(drinkNameLetters[0]);
            stringBuilder.Append(new string(drinkNameLetters));
            stringBuilder.Append(" ");
        }
    }
}
