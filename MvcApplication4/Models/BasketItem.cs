namespace MvcApplication4.Models {
    public class BasketItem {
        public int Id { get; set; }
        public int PurchaseId { get; set; }
        public int VegetableId { get; set; }
        public decimal Weight { get; set; }
        public decimal Price { get; set; }
    }
}