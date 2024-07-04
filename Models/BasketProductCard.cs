namespace BasketApp.Models
{
    public class BasketProductCard
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
        public int ProductId { get; set; }
        Product? Product { get; set; }
        public int HistoryId { get; set; }
        History? History { get; set; }
    }
}
