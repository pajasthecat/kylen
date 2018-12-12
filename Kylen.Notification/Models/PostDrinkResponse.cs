using System;

namespace Kylen.Infrastructure.Models
{
    public class PostDrinkResponse
    {
        public string _id { get; set; }
        public string item { get; set; }
        public int quantity { get; set; }
        public string unit { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public int __v { get; set; }
        public string image { get; set; }
        public string code { get; set; }
        public string coinbase { get; set; }

    }
}
