using ShopApp.Models;

namespace ShopApp.DAL.Interfaces
{
    public interface IStoreRepository
    {
        void AddStore(Store store);
        Store GetStore(int storeCode);
        IEnumerable<Store> GetAllStores();
    }
}