using ShopApp.Models;

namespace ShopApp.DAL.Interfaces
{
    public interface IProductRepository
    {
        void AddProduct(Product product);
        Product GetProduct(string name);
        void UpdateProductStock(int storeCode, string productName, int quantity, decimal price);
        IEnumerable<Product> GetAllProducts();
    }
}