using ShopApp.BLL.Interfaces;
using ShopApp.DAL.Interfaces;
using ShopApp.Models;

namespace ShopApp.BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IStoreRepository _storeRepository;

        public ProductService(IProductRepository productRepository, IStoreRepository storeRepository)
        {
            _productRepository = productRepository;
            _storeRepository = storeRepository;
        }

        public void CreateProduct(Product product)
        {
            _productRepository.AddProduct(product);
        }

        public void AddStockToStore(int storeCode, string productName, int quantity, decimal price)
        {
            _productRepository.UpdateProductStock(storeCode, productName, quantity, price);
        }

        public Store FindCheapestStoreForProduct(string productName)
        {
            var product = _productRepository.GetProduct(productName);
            if (product == null) throw new Exception("Товар не найден.");

            var cheapestStore = product.Stores.OrderBy(s => s.Value.Price).FirstOrDefault();
            return _storeRepository.GetStore(cheapestStore.Key);
        }

        public IEnumerable<Product> GetProductsWithinBudget(int storeCode, decimal budget)
        {
            return _productRepository.GetAllProducts()
                .Where(p => p.Stores.ContainsKey(storeCode) && p.Stores[storeCode].Price <= budget)
                .Select(p => new Product
                {
                    Name = p.Name,
                    Stores = new Dictionary<int, StoreProductInfo>
                    {
                        { storeCode, p.Stores[storeCode] }
                    }
                });
        }

        public decimal PurchaseProducts(int storeCode, List<PurchaseRequest> requests)
        {
            decimal totalCost = 0;

            foreach (var request in requests)
            {
                var product = _productRepository.GetProduct(request.ProductName);
                if (product == null || !product.Stores.ContainsKey(storeCode))
                    throw new Exception("Товар не найден в магазине.");

                var stock = product.Stores[storeCode];
                if (stock.Quantity < request.Quantity)
                    throw new Exception($"Недостаточно товара: {request.ProductName}");

                totalCost += stock.Price * request.Quantity;
                stock.Quantity -= request.Quantity;
            }

            return totalCost;
        }

        public Store FindCheapestStoreForBatch(List<PurchaseRequest> requests)
        {
            return _storeRepository.GetAllStores()
                .OrderBy(store =>
                    requests.Sum(req =>
                    {
                        var product = _productRepository.GetProduct(req.ProductName);
                        return product?.Stores.ContainsKey(store.StoreCode) == true
                            ? product.Stores[store.StoreCode].Price * req.Quantity
                            : decimal.MaxValue;
                    }))
                .FirstOrDefault();
        }
    }
}
