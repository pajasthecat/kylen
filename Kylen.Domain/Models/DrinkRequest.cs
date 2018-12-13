namespace Kylen.Domain.Models
{
    public class DrinkRequest
    {
        public EnumType EnumType { get; set; }
        public Drink Drinks { get; set; }
        public string User { get; set; }
    }
}
