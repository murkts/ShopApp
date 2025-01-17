namespace ShopApp.API
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button createStoreButton;
        private System.Windows.Forms.Button createProductButton;
        private System.Windows.Forms.Button addStockButton;
        private System.Windows.Forms.Button findCheapestStoreButton;
        private System.Windows.Forms.Button findAffordableProductsButton;
        private System.Windows.Forms.Button purchaseProductsButton;
        private System.Windows.Forms.Button findCheapestBatchStoreButton;

        private void InitializeComponent()
        {
            this.createStoreButton = new System.Windows.Forms.Button();
            this.createProductButton = new System.Windows.Forms.Button();
            this.addStockButton = new System.Windows.Forms.Button();
            this.findCheapestStoreButton = new System.Windows.Forms.Button();
            this.findAffordableProductsButton = new System.Windows.Forms.Button();
            this.purchaseProductsButton = new System.Windows.Forms.Button();
            this.findCheapestBatchStoreButton = new System.Windows.Forms.Button();
            this.createStoreButton.Location = new System.Drawing.Point(10, 10);
            this.createStoreButton.Name = "createStoreButton";
            this.createStoreButton.Size = new System.Drawing.Size(200, 30);
            this.createStoreButton.Text = "Создать магазин";
            this.createStoreButton.UseVisualStyleBackColor = true;
            this.createProductButton.Location = new System.Drawing.Point(10, 50);
            this.createProductButton.Name = "createProductButton";
            this.createProductButton.Size = new System.Drawing.Size(200, 30);
            this.createProductButton.Text = "Создать товар";
            this.createProductButton.UseVisualStyleBackColor = true;
            this.addStockButton.Location = new System.Drawing.Point(10, 90);
            this.addStockButton.Name = "addStockButton";
            this.addStockButton.Size = new System.Drawing.Size(200, 30);
            this.addStockButton.Text = "Добавить партию товаров";
            this.addStockButton.UseVisualStyleBackColor = true;
            this.findCheapestStoreButton.Location = new System.Drawing.Point(10, 130);
            this.findCheapestStoreButton.Name = "findCheapestStoreButton";
            this.findCheapestStoreButton.Size = new System.Drawing.Size(200, 30);
            this.findCheapestStoreButton.Text = "Найти дешевый магазин";
            this.findCheapestStoreButton.UseVisualStyleBackColor = true;
            this.findAffordableProductsButton.Location = new System.Drawing.Point(10, 170);
            this.findAffordableProductsButton.Name = "findAffordableProductsButton";
            this.findAffordableProductsButton.Size = new System.Drawing.Size(200, 30);
            this.findAffordableProductsButton.Text = "Товары в бюджете";
            this.findAffordableProductsButton.UseVisualStyleBackColor = true;
            this.purchaseProductsButton.Location = new System.Drawing.Point(10, 210);
            this.purchaseProductsButton.Name = "purchaseProductsButton";
            this.purchaseProductsButton.Size = new System.Drawing.Size(200, 30);
            this.purchaseProductsButton.Text = "Купить товары";
            this.purchaseProductsButton.UseVisualStyleBackColor = true;
            this.findCheapestBatchStoreButton.Location = new System.Drawing.Point(10, 250);
            this.findCheapestBatchStoreButton.Name = "findCheapestBatchStoreButton";
            this.findCheapestBatchStoreButton.Size = new System.Drawing.Size(200, 30);
            this.findCheapestBatchStoreButton.Text = "Где дешевле партия?";
            this.findCheapestBatchStoreButton.UseVisualStyleBackColor = true;
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Controls.Add(this.createStoreButton);
            this.Controls.Add(this.createProductButton);
            this.Controls.Add(this.addStockButton);
            this.Controls.Add(this.findCheapestStoreButton);
            this.Controls.Add(this.findAffordableProductsButton);
            this.Controls.Add(this.purchaseProductsButton);
            this.Controls.Add(this.findCheapestBatchStoreButton);
            this.Text = "Управление магазином";
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}