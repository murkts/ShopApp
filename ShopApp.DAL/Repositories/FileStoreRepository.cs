using ShopApp.DAL.Interfaces;
using ShopApp.Models;

namespace ShopApp.DAL.Repositories
{
    public class FileStoreRepository : IStoreRepository
    {
        private readonly string _filePath;

        public FileStoreRepository(string filePath)
        {
            _filePath = filePath;
        }
        private readonly List<Store> _stores = new();

        public void AddStore(Store store)
        {
            _stores.Add(store);
        }

        public Store GetStore(int storeCode)
        {
            return _stores.FirstOrDefault(s => s.StoreCode == storeCode);
        }

        public IEnumerable<Store> GetAllStores()
        {
            return _stores;
        }
    }
}