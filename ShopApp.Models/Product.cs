namespace ShopApp.Models
{
    public class Product
    {
        public string Name { get; set; }
        public Dictionary<int, StoreProductInfo> Stores { get; set; } = new();
    }
}