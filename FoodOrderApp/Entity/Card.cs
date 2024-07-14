namespace FoodOrderApp.Entity
{
    public class Card
    {
        public int CardId { get; set; }
        public int CardNo { get; set; }
        public int ExpireMonth { get; set; }
        public int ExpireYear { get; set; }
        public string? NameOnCard { get; set; }
    }
}