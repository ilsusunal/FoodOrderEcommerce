namespace FoodOrderApp.Entity
{
    public class Card
    {
        public int CardId { get; set; }
        public long CardNo { get; set; }
        public int ExpireMonth { get; set; }
        public int ExpireYear { get; set; }
        public string? NameOnCard { get; set; }
        public int UserId { get; set; }
        public User User{ get; set; } = null!;
    }
}