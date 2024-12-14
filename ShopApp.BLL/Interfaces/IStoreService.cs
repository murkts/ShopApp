using ShopApp.Models;

namespace ShopApp.BLL.Interfaces
{
    public interface IStoreService
    {
        void CreateStore(Store store);
        Store GetStore(int storeCode);
    }
}