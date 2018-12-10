using System;

namespace Kylen.Infrastructure.Models
{
    public class DrinkStatus
    {
        public string _id { get; set; }
        public string item { get; set; }
        public int quantity { get; set; }
        public string unit { get; set; }
        public DateTime created_at { get; set; }
        public int __v { get; set; }
        public string image { get; set; }
        public string code { get; set; }
        public DateTime updated_t { get; set; }

        public Domain.Models.DrinkStatus ToDrinkStatus(DrinkStatus drinkStatus)
        {
            return new Domain.Models.DrinkStatus
            {
                Name = drinkStatus.item,
                Quantity = drinkStatus.quantity
            };
        }

    }
}
