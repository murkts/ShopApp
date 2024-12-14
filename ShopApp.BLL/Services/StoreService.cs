using ShopApp.BLL.Interfaces;
using ShopApp.DAL.Interfaces;
using ShopApp.Models;

namespace ShopApp.BLL.Services
{
    public class StoreService : IStoreService
    {
        private readonly IStoreRepository _storeRepository;

        public StoreService(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        public void CreateStore(Store store)
        {
            _storeRepository.AddStore(store);
        }

        public Store GetStore(int storeCode)
        {
            return _storeRepository.GetStore(storeCode);
        }
    }
}