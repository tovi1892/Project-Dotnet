namespace UI_
{
    partial class Products
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            showProduct = new Button();
            deleteProduct = new Button();
            showAllProducts = new Button();
            createProduct = new Button();
            updateProduct = new Button();
            panel1 = new Panel();
            categoryComboBox = new ComboBox();
            stockTextBox = new TextBox();
            priceTextBox = new TextBox();
            nameTextBox = new TextBox();
            confirmCreate = new Button();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panelID = new Panel();
            confirmAction = new Button();
            idTextBox = new TextBox();
            labelID = new Label();
            panelUpdate = new Panel();
            categoryComboBoxUpdate = new ComboBox();
            upStockTextBox = new TextBox();
            upPriceTextBox = new TextBox();
            upNameTextBox = new TextBox();
            UpdateConfirm = new Button();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            upIdTextBox = new TextBox();
            panelDelete = new Panel();
            DeleteConfirm = new Button();
            idDeleteTextBox = new TextBox();
            panelShowAll = new Panel();
            filterByCategory = new Button();
            label10 = new Label();
            categoryFilterComboBox = new ComboBox();
            closeShowAll = new Button();
            labelFilter = new Label();
            filterTextBox = new TextBox();
            dataGridViewProducts = new DataGridView();
            label9 = new Label();
            panel1.SuspendLayout();
            panelID.SuspendLayout();
            panelUpdate.SuspendLayout();
            panelDelete.SuspendLayout();
            panelShowAll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProducts).BeginInit();
            SuspendLayout();
            // 
            // showProduct
            // 
            showProduct.Location = new Point(849, 128);
            showProduct.Margin = new Padding(4, 5, 4, 5);
            showProduct.Name = "showProduct";
            showProduct.Size = new Size(174, 63);
            showProduct.TabIndex = 0;
            showProduct.Text = "Show Product";
            showProduct.UseVisualStyleBackColor = true;
            showProduct.Click += showProduct_Click;
            // 
            // deleteProduct
            // 
            deleteProduct.Location = new Point(849, 348);
            deleteProduct.Margin = new Padding(4, 5, 4, 5);
            deleteProduct.Name = "deleteProduct";
            deleteProduct.Size = new Size(174, 63);
            deleteProduct.TabIndex = 1;
            deleteProduct.Text = "Delete Product";
            deleteProduct.UseVisualStyleBackColor = true;
            deleteProduct.Click += deleteProduct_Click;
            // 
            // showAllProducts
            // 
            showAllProducts.Location = new Point(849, 202);
            showAllProducts.Margin = new Padding(4, 5, 4, 5);
            showAllProducts.Name = "showAllProducts";
            showAllProducts.Size = new Size(174, 63);
            showAllProducts.TabIndex = 2;
            showAllProducts.Text = "Show All Products";
            showAllProducts.UseVisualStyleBackColor = true;
            showAllProducts.Click += showAllProducts_Click;
            // 
            // createProduct
            // 
            createProduct.Location = new Point(849, 275);
            createProduct.Margin = new Padding(4, 5, 4, 5);
            createProduct.Name = "createProduct";
            createProduct.Size = new Size(174, 63);
            createProduct.TabIndex = 2;
            createProduct.Text = "Create Product";
            createProduct.UseVisualStyleBackColor = true;
            createProduct.Click += createProduct_Click;
            // 
            // updateProduct
            // 
            updateProduct.Location = new Point(849, 422);
            updateProduct.Margin = new Padding(4, 5, 4, 5);
            updateProduct.Name = "updateProduct";
            updateProduct.Size = new Size(174, 63);
            updateProduct.TabIndex = 3;
            updateProduct.Text = "Update Product";
            updateProduct.UseVisualStyleBackColor = true;
            updateProduct.Click += updateProduct_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(categoryComboBox);
            panel1.Controls.Add(stockTextBox);
            panel1.Controls.Add(priceTextBox);
            panel1.Controls.Add(nameTextBox);
            panel1.Controls.Add(confirmCreate);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(44, 222);
            panel1.Margin = new Padding(4, 5, 4, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(281, 285);
            panel1.TabIndex = 4;
            // 
            // categoryComboBox
            // 
            categoryComboBox.FormattingEnabled = true;
            categoryComboBox.Location = new Point(100, 183);
            categoryComboBox.Margin = new Padding(4, 5, 4, 5);
            categoryComboBox.Name = "categoryComboBox";
            categoryComboBox.Size = new Size(171, 33);
            categoryComboBox.TabIndex = 8;
            // 
            // stockTextBox
            // 
            stockTextBox.Location = new Point(4, 147);
            stockTextBox.Margin = new Padding(4, 5, 4, 5);
            stockTextBox.Name = "stockTextBox";
            stockTextBox.Size = new Size(84, 31);
            stockTextBox.TabIndex = 4;
            // 
            // priceTextBox
            // 
            priceTextBox.Location = new Point(147, 147);
            priceTextBox.Margin = new Padding(4, 5, 4, 5);
            priceTextBox.Name = "priceTextBox";
            priceTextBox.Size = new Size(124, 31);
            priceTextBox.TabIndex = 3;
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(4, 73);
            nameTextBox.Margin = new Padding(4, 5, 4, 5);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(267, 31);
            nameTextBox.TabIndex = 0;
            // 
            // confirmCreate
            // 
            confirmCreate.Location = new Point(111, 233);
            confirmCreate.Margin = new Padding(4, 5, 4, 5);
            confirmCreate.Name = "confirmCreate";
            confirmCreate.Size = new Size(107, 38);
            confirmCreate.TabIndex = 7;
            confirmCreate.Text = "OK";
            confirmCreate.UseVisualStyleBackColor = true;
            confirmCreate.Click += confirmCreate_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(147, 117);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(49, 25);
            label4.TabIndex = 3;
            label4.Text = "Price";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(4, 117);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(55, 25);
            label3.TabIndex = 2;
            label3.Text = "Stock";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(4, 38);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(59, 25);
            label2.TabIndex = 1;
            label2.Text = "Name";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 183);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(84, 25);
            label1.TabIndex = 1;
            label1.Text = "Category";
            // 
            // panelID
            // 
            panelID.Controls.Add(confirmAction);
            panelID.Controls.Add(idTextBox);
            panelID.Location = new Point(169, 77);
            panelID.Margin = new Padding(4, 5, 4, 5);
            panelID.Name = "panelID";
            panelID.Size = new Size(484, 67);
            panelID.TabIndex = 9;
            // 
            // confirmAction
            // 
            confirmAction.Location = new Point(39, 20);
            confirmAction.Margin = new Padding(4, 5, 4, 5);
            confirmAction.Name = "confirmAction";
            confirmAction.Size = new Size(107, 38);
            confirmAction.TabIndex = 8;
            confirmAction.Text = "OK";
            confirmAction.UseVisualStyleBackColor = true;
            confirmAction.Click += confirmAction_Click;
            // 
            // idTextBox
            // 
            idTextBox.Location = new Point(207, 20);
            idTextBox.Margin = new Padding(4, 5, 4, 5);
            idTextBox.Name = "idTextBox";
            idTextBox.Size = new Size(141, 31);
            idTextBox.TabIndex = 8;
            // 
            // labelID
            // 
            labelID.AutoSize = true;
            labelID.Location = new Point(371, 25);
            labelID.Margin = new Padding(4, 0, 4, 0);
            labelID.Name = "labelID";
            labelID.Size = new Size(75, 25);
            labelID.TabIndex = 8;
            labelID.Text = "Enter ID";
            // 
            // panelUpdate
            // 
            panelUpdate.Controls.Add(label9);
            panelUpdate.Controls.Add(categoryComboBoxUpdate);
            panelUpdate.Controls.Add(upStockTextBox);
            panelUpdate.Controls.Add(upPriceTextBox);
            panelUpdate.Controls.Add(upNameTextBox);
            panelUpdate.Controls.Add(UpdateConfirm);
            panelUpdate.Controls.Add(label8);
            panelUpdate.Controls.Add(label7);
            panelUpdate.Controls.Add(label6);
            panelUpdate.Controls.Add(label5);
            panelUpdate.Controls.Add(upIdTextBox);
            panelUpdate.Location = new Point(349, 222);
            panelUpdate.Margin = new Padding(4, 5, 4, 5);
            panelUpdate.Name = "panelUpdate";
            panelUpdate.Size = new Size(304, 285);
            panelUpdate.TabIndex = 10;
            // 
            // categoryComboBoxUpdate
            // 
            categoryComboBoxUpdate.FormattingEnabled = true;
            categoryComboBoxUpdate.Location = new Point(100, 200);
            categoryComboBoxUpdate.Margin = new Padding(4, 5, 4, 5);
            categoryComboBoxUpdate.Name = "categoryComboBoxUpdate";
            categoryComboBoxUpdate.Size = new Size(171, 33);
            categoryComboBoxUpdate.TabIndex = 10;
            // 
            // upStockTextBox
            // 
            upStockTextBox.Location = new Point(4, 147);
            upStockTextBox.Margin = new Padding(4, 5, 4, 5);
            upStockTextBox.Name = "upStockTextBox";
            upStockTextBox.Size = new Size(84, 31);
            upStockTextBox.TabIndex = 4;
            // 
            // upPriceTextBox
            // 
            upPriceTextBox.Location = new Point(147, 147);
            upPriceTextBox.Margin = new Padding(4, 5, 4, 5);
            upPriceTextBox.Name = "upPriceTextBox";
            upPriceTextBox.Size = new Size(124, 31);
            upPriceTextBox.TabIndex = 3;
            // 
            // upNameTextBox
            // 
            upNameTextBox.Location = new Point(4, 73);
            upNameTextBox.Margin = new Padding(4, 5, 4, 5);
            upNameTextBox.Name = "upNameTextBox";
            upNameTextBox.Size = new Size(267, 31);
            upNameTextBox.TabIndex = 0;
            // 
            // UpdateConfirm
            // 
            UpdateConfirm.Location = new Point(89, 242);
            UpdateConfirm.Margin = new Padding(4, 5, 4, 5);
            UpdateConfirm.Name = "UpdateConfirm";
            UpdateConfirm.Size = new Size(107, 38);
            UpdateConfirm.TabIndex = 7;
            UpdateConfirm.Text = "OK";
            UpdateConfirm.UseVisualStyleBackColor = true;
            UpdateConfirm.Click += UpdateConfirm_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(8, 203);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(84, 25);
            label8.TabIndex = 2;
            label8.Text = "Category";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(147, 117);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(49, 25);
            label7.TabIndex = 3;
            label7.Text = "Price";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(4, 117);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(55, 25);
            label6.TabIndex = 2;
            label6.Text = "Stock";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(4, 38);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(59, 25);
            label5.TabIndex = 1;
            label5.Text = "Name";
            // 
            // upIdTextBox
            // 
            upIdTextBox.Location = new Point(182, 20);
            upIdTextBox.Margin = new Padding(4, 5, 4, 5);
            upIdTextBox.Name = "upIdTextBox";
            upIdTextBox.Size = new Size(84, 31);
            upIdTextBox.TabIndex = 9;
            // 
            // panelDelete
            // 
            panelDelete.Controls.Add(DeleteConfirm);
            panelDelete.Controls.Add(idDeleteTextBox);
            panelDelete.Controls.Add(labelID);
            panelDelete.Location = new Point(169, 145);
            panelDelete.Margin = new Padding(4, 5, 4, 5);
            panelDelete.Name = "panelDelete";
            panelDelete.Size = new Size(484, 67);
            panelDelete.TabIndex = 10;
            // 
            // DeleteConfirm
            // 
            DeleteConfirm.Location = new Point(39, 20);
            DeleteConfirm.Margin = new Padding(4, 5, 4, 5);
            DeleteConfirm.Name = "DeleteConfirm";
            DeleteConfirm.Size = new Size(107, 38);
            DeleteConfirm.TabIndex = 8;
            DeleteConfirm.Text = "OK";
            DeleteConfirm.UseVisualStyleBackColor = true;
            DeleteConfirm.Click += DeleteConfirm_Click;
            // 
            // idDeleteTextBox
            // 
            idDeleteTextBox.Location = new Point(207, 20);
            idDeleteTextBox.Margin = new Padding(4, 5, 4, 5);
            idDeleteTextBox.Name = "idDeleteTextBox";
            idDeleteTextBox.Size = new Size(141, 31);
            idDeleteTextBox.TabIndex = 8;
            // 
            // panelShowAll
            // 
            panelShowAll.Controls.Add(filterByCategory);
            panelShowAll.Controls.Add(label10);
            panelShowAll.Controls.Add(categoryFilterComboBox);
            panelShowAll.Controls.Add(closeShowAll);
            panelShowAll.Controls.Add(labelFilter);
            panelShowAll.Controls.Add(filterTextBox);
            panelShowAll.Controls.Add(dataGridViewProducts);
            panelShowAll.Location = new Point(13, 67);
            panelShowAll.Margin = new Padding(4, 5, 4, 5);
            panelShowAll.Name = "panelShowAll";
            panelShowAll.Size = new Size(804, 440);
            panelShowAll.TabIndex = 11;
            // 
            // filterByCategory
            // 
            filterByCategory.Location = new Point(356, 50);
            filterByCategory.Name = "filterByCategory";
            filterByCategory.Size = new Size(256, 33);
            filterByCategory.TabIndex = 5;
            filterByCategory.Text = "Filter by Category";
            filterByCategory.UseVisualStyleBackColor = true;
            filterByCategory.Click += filterByCategory_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(14, 55);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(88, 25);
            label10.TabIndex = 2;
            label10.Text = "Category:";
            // 
            // categoryFilterComboBox
            // 
            categoryFilterComboBox.FormattingEnabled = true;
            categoryFilterComboBox.Location = new Point(93, 50);
            categoryFilterComboBox.Margin = new Padding(4, 5, 4, 5);
            categoryFilterComboBox.Name = "categoryFilterComboBox";
            categoryFilterComboBox.Size = new Size(174, 33);
            categoryFilterComboBox.TabIndex = 6;
            categoryFilterComboBox.SelectedIndexChanged += categoryFilterComboBox_SelectedIndexChanged;
            // 
            // closeShowAll
            // 
            closeShowAll.Location = new Point(704, 15);
            closeShowAll.Margin = new Padding(4, 5, 4, 5);
            closeShowAll.Name = "closeShowAll";
            closeShowAll.Size = new Size(79, 32);
            closeShowAll.TabIndex = 3;
            closeShowAll.Text = "X";
            closeShowAll.UseVisualStyleBackColor = true;
            closeShowAll.Click += closeShowAll_Click;
            // 
            // labelFilter
            // 
            labelFilter.AutoSize = true;
            labelFilter.Location = new Point(31, 15);
            labelFilter.Margin = new Padding(4, 0, 4, 0);
            labelFilter.Name = "labelFilter";
            labelFilter.Size = new Size(54, 25);
            labelFilter.TabIndex = 2;
            labelFilter.Text = "Filter:";
            // 
            // filterTextBox
            // 
            filterTextBox.Location = new Point(93, 12);
            filterTextBox.Margin = new Padding(4, 5, 4, 5);
            filterTextBox.Name = "filterTextBox";
            filterTextBox.PlaceholderText = "Search by Name";
            filterTextBox.Size = new Size(174, 31);
            filterTextBox.TabIndex = 1;
            filterTextBox.TextChanged += filterTextBox_TextChanged;
            // 
            // dataGridViewProducts
            // 
            dataGridViewProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProducts.Location = new Point(14, 88);
            dataGridViewProducts.Margin = new Padding(4, 5, 4, 5);
            dataGridViewProducts.Name = "dataGridViewProducts";
            dataGridViewProducts.ReadOnly = true;
            dataGridViewProducts.RowHeadersWidth = 62;
            dataGridViewProducts.Size = new Size(767, 335);
            dataGridViewProducts.TabIndex = 0;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(115, 19);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(30, 25);
            label9.TabIndex = 11;
            label9.Text = "ID";
            // 
            // Products
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1143, 750);
            Controls.Add(panelShowAll);
            Controls.Add(panelDelete);
            Controls.Add(panelUpdate);
            Controls.Add(panelID);
            Controls.Add(panel1);
            Controls.Add(updateProduct);
            Controls.Add(createProduct);
            Controls.Add(showAllProducts);
            Controls.Add(deleteProduct);
            Controls.Add(showProduct);
            Margin = new Padding(4, 5, 4, 5);
            Name = "Products";
            Text = "Products";
            Load += Products_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panelID.ResumeLayout(false);
            panelID.PerformLayout();
            panelUpdate.ResumeLayout(false);
            panelUpdate.PerformLayout();
            panelDelete.ResumeLayout(false);
            panelDelete.PerformLayout();
            panelShowAll.ResumeLayout(false);
            panelShowAll.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProducts).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button showProduct;
        private Button deleteProduct;
        private Button showAllProducts;
        private Button createProduct;
        private Button updateProduct;
        private Panel panel1;
        private Label label1;
        private TextBox nameTextBox;
        private Label label4;
        private Label label3;
        private TextBox priceTextBox;
        private TextBox stockTextBox;
        private ComboBox categoryComboBox;
        private Button confirmCreate;
        private Label label2;
        private Panel panelID;
        private TextBox idTextBox;
        private Button confirmAction;
        private Panel panelUpdate;
        private TextBox upNameTextBox;
        private Label label5;
        private Label label6;
        private TextBox upPriceTextBox;
        private Label label7;
        private TextBox upStockTextBox;
        private Label label8;
        private Button UpdateConfirm;
        private TextBox upIdTextBox;
        private Panel panelDelete;
        private Button DeleteConfirm;
        private TextBox idDeleteTextBox;
        private Panel panelShowAll;
        private DataGridView dataGridViewProducts;
        private TextBox filterTextBox;
        private Label labelFilter;
        private Button closeShowAll;
        private Label labelID;
        private Button filterByCategory;
        private ComboBox categoryFilterComboBox;
        private Label label10;
        private ComboBox categoryComboBoxUpdate;
        private Label label9;
    }
}
