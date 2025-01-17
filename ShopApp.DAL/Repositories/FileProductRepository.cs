using ShopApp.DAL.Interfaces;
using ShopApp.Models;

namespace ShopApp.DAL.Repositories
{
    public class FileProductRepository : IProductRepository
    {
        private readonly List<Product> _products = new();
        private readonly string _filePath;

        public FileProductRepository(string filePath)
        {
            _filePath = filePath;
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public Product GetProduct(string name)
        {
            return _products.FirstOrDefault(p => p.Name == name);
        }

        public void UpdateProductStock(int storeCode, string productName, int quantity, decimal price)
        {
            var product = GetProduct(productName);
            if (product == null) throw new Exception("Товар не найден.");
            
            if (!product.Stores.ContainsKey(storeCode))
            {
                product.Stores[storeCode] = new StoreProductInfo();
            }

            product.Stores[storeCode].Quantity += quantity;
            product.Stores[storeCode].Price = price;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _products;
        }
    }
}