using System;
using System.Windows.Forms;
using ShopApp.BLL.Services;
using ShopApp.DAL.Repositories;

namespace ShopApp.API
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            var productFilePath = "products.csv";
            var storeFilePath = "stores.csv";
            var productRepository = new FileProductRepository(productFilePath);
            var storeRepository = new FileStoreRepository(storeFilePath);
            var productService = new ProductService(productRepository, storeRepository);
            var storeService = new StoreService(storeRepository);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(storeService, productService));
        }
    }
}