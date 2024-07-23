namespace FoodOrderApp.Entity
{
    public enum MaterialType
    {
        Pepperoni, Sosis, Jambon, Tavuk, Soğan, Domates, Mısır, Sucuk, Jalepeno, Sarımsak, Biber, Ananas, Kabak
    }
    public enum Size
    {
        Small, Medium, Large
    }
    public enum DoughSize
    {
        Süpperİnce, İnce, Orta, Kalın
    }
    public class ProductVar
    {
        public int ProductVarId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
        public decimal Price { get; set; }
        public Size Size { get; set; }
        public DoughSize DoughSize { get; set; }
        public List<MaterialType> Materials { get; set; } = new List<MaterialType>();
        public bool IsVegetarian
        {
            get
            {
                return Materials.All(m => m != MaterialType.Pepperoni && m != MaterialType.Sosis &&
                                          m != MaterialType.Jambon && m != MaterialType.Tavuk &&
                                          m != MaterialType.Sucuk && m != MaterialType.Jalepeno);
            }
        }

    }
}