using Kylen.Domain.Models;

namespace Kylen.Function.Contracts
{
    public class SlackResponse
    {
        public string Text { get; set; }

        public Attachments[] Attachments { get; set; }

        public SlackResponse(string text)
        {
            Text = text;
        }
    }

}
