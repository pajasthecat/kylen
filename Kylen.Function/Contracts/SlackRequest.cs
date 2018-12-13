using Kylen.Domain.Models;
using Microsoft.AspNetCore.Http;
using System;

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
            if(enumType == EnumType.STATUS)
            {
                return new DrinkRequest
                {
                    EnumType = enumType
                };
            };
            return new DrinkRequest
            {
                EnumType = enumType,
                User = slackRequest.user_name,
                Drinks = new Drink
                {
                    Name = texts[2],
                    Quantity = Convert.ToInt32(texts[1])
                }
            };
        }
    }
}
