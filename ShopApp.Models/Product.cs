namespace ShopApp.Models
{
    using System.Collections.Generic;

    public class Product
    {
        public string Name { get; set; } 
        public Dictionary<int, StoreProductInfo> Stores { get; set; } = new Dictionary<int, StoreProductInfo>();
    }
}