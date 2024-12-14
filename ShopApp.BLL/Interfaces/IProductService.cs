using ShopApp.Models;

namespace ShopApp.BLL.Interfaces
{
    public interface IProductService
    {
        void CreateProduct(Product product);
        void AddStockToStore(int storeCode, string productName, int quantity, decimal price);
        Store FindCheapestStoreForProduct(string productName);
        IEnumerable<Product> GetProductsWithinBudget(int storeCode, decimal budget);
        decimal PurchaseProducts(int storeCode, List<PurchaseRequest> requests);
        Store FindCheapestStoreForBatch(List<PurchaseRequest> requests);
    }
}