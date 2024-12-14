using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ShopApp.BLL.Interfaces;
using ShopApp.Models;

namespace ShopApp.API
{
    public partial class MainForm : Form
    {
        private readonly IStoreService _storeService;
        private readonly IProductService _productService;

        public MainForm(IStoreService storeService, IProductService productService)
        {
            _storeService = storeService;
            _productService = productService;
            InitializeComponent();
            createStoreButton.Click += CreateStoreButton_Click;
            createProductButton.Click += CreateProductButton_Click;
            addStockButton.Click += AddStockButton_Click;
            findCheapestStoreButton.Click += FindCheapestStoreButton_Click;
            findAffordableProductsButton.Click += FindAffordableProductsButton_Click;
            purchaseProductsButton.Click += PurchaseProductsButton_Click;
            findCheapestBatchStoreButton.Click += FindCheapestBatchStoreButton_Click;
        }
        
        private void CreateStoreButton_Click(object sender, EventArgs e)
        {
            string name = Prompt.ShowDialog("Введите название магазина", "Создать магазин");
            int code = int.Parse(Prompt.ShowDialog("Введите код магазина", "Создать магазин"));
            _storeService.CreateStore(new Store { StoreCode = code, Name = name });
            MessageBox.Show("Магазин создан.");
        }

        private void CreateProductButton_Click(object sender, EventArgs e)
        {
            string name = Prompt.ShowDialog("Введите название товара", "Создать товар");
            _productService.CreateProduct(new Product { Name = name });
            MessageBox.Show("Товар создан.");
        }

        private void AddStockButton_Click(object sender, EventArgs e)
        {
            int storeCode = int.Parse(Prompt.ShowDialog("Введите код магазина", "Добавить партию товаров"));
            string productName = Prompt.ShowDialog("Введите название товара", "Добавить партию товаров");
            int quantity = int.Parse(Prompt.ShowDialog("Введите количество", "Добавить партию товаров"));
            decimal price = decimal.Parse(Prompt.ShowDialog("Введите цену", "Добавить партию товаров"));

            _productService.AddStockToStore(storeCode, productName, quantity, price);
            MessageBox.Show("Партия добавлена.");
        }
        private void FindCheapestStoreButton_Click(object sender, EventArgs e)
        {
            string productName = Prompt.ShowDialog("Введите название товара", "Найти дешевый магазин");
            var store = _productService.FindCheapestStoreForProduct(productName);

            if (store != null)
                MessageBox.Show($"Магазин с самым дешевым товаром: {store.Name}");
            else
                MessageBox.Show("Товар не найден.");
        }

        private void FindAffordableProductsButton_Click(object sender, EventArgs e)
        {
            int storeCode = int.Parse(Prompt.ShowDialog("Введите код магазина", "Товары в бюджете"));
            decimal budget = decimal.Parse(Prompt.ShowDialog("Введите бюджет", "Товары в бюджете"));

            var products = _productService.GetProductsWithinBudget(storeCode, budget);

            string result = "";
            foreach (var product in products)
            {
                result += $"{product.ProductName}: {product.Quantity} шт.\n";
            }

            MessageBox.Show(result);
        }
        private void PurchaseProductsButton_Click(object sender, EventArgs e)
        {
            int storeCode = int.Parse(Prompt.ShowDialog("Введите код магазина", "Купить товары"));
            string productName = Prompt.ShowDialog("Введите название товара", "Купить товары");
            int quantity = int.Parse(Prompt.ShowDialog("Введите количество", "Купить товары"));

            try
            {
                decimal cost = _productService.PurchaseProducts(storeCode, new List<PurchaseRequest>
                {
                    new PurchaseRequest { ProductName = productName, Quantity = quantity }
                });

                MessageBox.Show($"Покупка завершена. Общая стоимость: {cost}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FindCheapestBatchStoreButton_Click(object sender, EventArgs e)
        {
            string input = Prompt.ShowDialog("Введите товары и количество (формат: товар-количество, через запятую)", "Где дешевле партия?");
            var requests = new List<PurchaseRequest>();

            foreach (var item in input.Split(','))
            {
                var parts = item.Split('-');
                requests.Add(new PurchaseRequest
                {
                    ProductName = parts[0].Trim(),
                    Quantity = int.Parse(parts[1].Trim())
                });
            }
            var store = _productService.FindCheapestStoreForBatch(requests);

            if (store != null)
                MessageBox.Show($"Магазин с самой дешевой партией: {store.Name}");
            else
                MessageBox.Show("Партия не доступна в магазинах.");
        }
    }
}