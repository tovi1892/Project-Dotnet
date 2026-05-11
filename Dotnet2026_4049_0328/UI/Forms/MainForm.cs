using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using UI.Forms;
using BlApi;
using BO;
using BL.BlApi;

namespace UI.Forms
{
    // Shared in-memory cart service and model used by UI forms for synchronization.
    public static class CartService
    {
        public static BindingList<CartLine> Cart { get; } = new();

        public static event EventHandler? CartChanged;

        public static void AddProduct(BO.Product product, int quantity)
        {
            if (product == null) return;
            if (quantity <= 0) return;

            var existing = Cart.FirstOrDefault(c => c.ProductId == product.Id);
            if (existing != null)
            {
                existing.Quantity += quantity;
                existing.LineTotal = existing.Quantity * existing.UnitPrice;
            }
            else
            {
                Cart.Add(new CartLine
                {
                    ProductId = product.Id,
                    Name = product.Name,
                    Quantity = quantity,
                    UnitPrice = product.Price,
                    LineTotal = quantity * product.Price
                });
            }

            CartChanged?.Invoke(null, EventArgs.Empty);
        }

        internal static void Clear()
        {
            throw new NotImplementedException();
        }
    }

    public class CartLine
    {
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double LineTotal { get; set; }
    }

    public class MainForm : Form
    {
        readonly Button btnProducts = new() { Text = "Products", Width = 220, Height = 64 };
        readonly Button btnCustomers = new() { Text = "Customers", Width = 220, Height = 64 };
        readonly Button btnCashier = new() { Text = "Cashier", Width = 220, Height = 64 };

        public MainForm()
        {
            Text = "Luxury Jewelry - Management";
            Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            BackColor = Color.FromArgb(10, 25, 40);
            ForeColor = Color.White;
            StartPosition = FormStartPosition.CenterScreen;
            WindowState = FormWindowState.Maximized;

            InitializeLayout();
        }

        void InitializeLayout()
        {
            var root = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 3,
                Padding = new Padding(24)
            };
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 88));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 24));

            var header = new Label
            {
                Text = "Luxury Jewelry - Admin",
                Font = new Font("Segoe UI", 28F, FontStyle.Bold),
                ForeColor = Color.Gold,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                AutoSize = false
            };

            var panel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.LeftToRight,
                BackColor = Color.FromArgb(12, 30, 50),
                AutoScroll = true,
                Padding = new Padding(20)
            };

            StyleMainButton(btnProducts);
            StyleMainButton(btnCustomers);
            StyleMainButton(btnCashier);

            btnProducts.Click += (s, e) => { using var f = new ProductsForm(); f.ShowDialog(this); };
            btnCustomers.Click += (s, e) => { using var f = new CustomersForm(); f.ShowDialog(this); };
            btnCashier.Click += (s, e) => { using var f = new CashierForm(); f.ShowDialog(this); };

            panel.Controls.AddRange(new Control[] { btnProducts, btnCustomers, btnCashier });

            root.Controls.Add(header, 0, 0);
            root.Controls.Add(panel, 0, 1);

            Controls.Add(root);
        }

        static void StyleMainButton(Button b)
        {
            b.FlatStyle = FlatStyle.Flat;
            b.BackColor = Color.FromArgb(14, 40, 70);
            b.ForeColor = Color.White;
            b.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            b.Margin = new Padding(20);
            b.Anchor = AnchorStyles.Top;
        }
    }
    public class ManagerDashboardForm : Form
    {
        public ManagerDashboardForm()
        {
            Text = "Manager Dashboard";
            WindowState = FormWindowState.Maximized;
            BackColor = Color.FromArgb(10, 25, 40);

            var root = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 1, RowCount = 3, Padding = new Padding(40) };
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 33));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 33));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 34));

            var btnProducts = new Button { Text = "Products", Dock = DockStyle.Fill, Font = new Font(Font, FontStyle.Bold), Height = 80 };
            btnProducts.Click += (s, e) => new ProductManagementForm().ShowDialog();

            var btnCustomers = new Button { Text = "Customers", Dock = DockStyle.Fill, Font = new Font(Font, FontStyle.Bold), Height = 80 };
            btnCustomers.Click += (s, e) => new CustomersForm().ShowDialog();

            var btnPromotions = new Button { Text = "Promotions", Dock = DockStyle.Fill, Font = new Font(Font, FontStyle.Bold), Height = 80 };
            btnPromotions.Click += (s, e) => new PromotionsForm().ShowDialog();

            root.Controls.Add(btnProducts, 0, 0);
            root.Controls.Add(btnCustomers, 0, 1);
            root.Controls.Add(btnPromotions, 0, 2);

            Controls.Add(root);
        }
    }
    public class ProductManagementForm : Form
    {
        readonly IBl bl = BlApi.Factory.Get(); DataGridView dgv = new();
        TextBox txtSearch = new() { Width = 300 };
        Button btnSearch = new() { Text = "Filter" };
        Button btnRefresh = new() { Text = "Refresh" };
        Button btnAdd = new() { Text = "Add" };
        Button btnUpdate = new() { Text = "Update" };
        Button btnDelete = new() { Text = "Delete" };
        Button btnRestock = new() { Text = "Restock" };
        BindingList<Product> bound = new();

        public ProductManagementForm()
        {
            Text = "Product Management";
            Font = new Font("Segoe UI", 9F);
            BackColor = Color.FromArgb(10, 25, 40);
            ForeColor = Color.White;
            WindowState = FormWindowState.Maximized;

            InitializeLayout();
            bound = new BindingList<Product>();
            dgv.DataSource = bound;
            Load += (s, e) => LoadProducts();
        }

        void InitializeLayout()
        {
            var root = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 1, RowCount = 2, Padding = new Padding(12) };
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 72));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

            // Top search row
            var top = new FlowLayoutPanel { Dock = DockStyle.Fill, FlowDirection = FlowDirection.LeftToRight, AutoSize = true };
            top.Controls.Add(new Label { Text = "Name contains:", ForeColor = Color.White, AutoSize = true, TextAlign = ContentAlignment.MiddleLeft });
            txtSearch.Location = new Point(110, 6);
            txtSearch.TextChanged += (s, e) => LoadProducts();
            top.Controls.Add(txtSearch);
            btnSearch.Click += (s, e) => LoadProducts();
            top.Controls.Add(btnSearch);
            btnRefresh.Click += (s, e) => { txtSearch.Text = ""; LoadProducts(); };
            top.Controls.Add(btnRefresh);
            root.Controls.Add(top, 0, 0);

            // Grid
            dgv.Dock = DockStyle.Fill;
            dgv.ReadOnly = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoGenerateColumns = false;
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(12, 30, 50);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.Gold;
            dgv.BackgroundColor = Color.FromArgb(6, 20, 35);
            dgv.GridColor = Color.Gray;
            dgv.RowHeadersVisible = false;
            dgv.Columns.Add
(new DataGridViewTextBoxColumn { HeaderText = "ID", DataPropertyName = "Id", Width = 100 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Name", DataPropertyName = "Name", Width = 260 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Category", DataPropertyName = "Category", Width = 180 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Stock", DataPropertyName = "QuantityInStock", Width = 120 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Price", DataPropertyName = "Price", Width = 120 });

            dgv.SelectionChanged += Dgv_SelectionChanged;

            // Visual indicator for low stock
            dgv.RowPrePaint += (s, e) =>
            {
                if (dgv.Rows[e.RowIndex].DataBoundItem is Product p && p.QuantityInStock < 5)
                {
                    dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(255, 220, 220);
                }
                else
                {
                    dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                }
            };

            // Actions
            var actions = new FlowLayoutPanel { Dock = DockStyle.Bottom, FlowDirection = FlowDirection.LeftToRight, AutoSize = true, Padding = new Padding(8) };
            btnAdd.Click += BtnAdd_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnDelete.Click += BtnDelete_Click;
            btnRestock.Click += BtnRestock_Click;
            actions.Controls.Add(btnAdd);
            actions.Controls.Add(btnUpdate);
            actions.Controls.Add(btnDelete);
            actions.Controls.Add(btnRestock);

            var panel = new Panel { Dock = DockStyle.Fill };
            panel.Controls.Add(dgv);
            panel.Controls.Add(actions);

            root.Controls.Add(panel, 0, 1);
            Controls.Add(root);
        }

        void LoadProducts()
        {
            try
            {
                var all = bl.Product.ReadAll() ?? new List<Product>();
                var filter = txtSearch.Text?.Trim() ?? string.Empty;
                if (!string.IsNullOrWhiteSpace(filter))
                    all = all.Where(p => (p.Name ?? string.Empty).Contains(filter, StringComparison.OrdinalIgnoreCase)).ToList();
                bound = new BindingList<Product>(all.ToList());
                dgv.DataSource = bound;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to load products: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void Dgv_SelectionChanged(object? s, EventArgs e)
        {
            // Optionally, update UI fields for editing
        }

        void BtnAdd_Click(object? s, EventArgs e)
        {
            try
            {
                using var dlg = new ProductEditDialog();
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    bl.Product.Create(dlg.Product);
                    LoadProducts();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Add failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void BtnUpdate_Click(object? s, EventArgs e)
        {
            try
            {
                if (dgv.CurrentRow?.DataBoundItem is not Product p) { MessageBox.Show("Select a product first."); return; }
                using var dlg = new ProductEditDialog(p);
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    bl.Product.Update(dlg.Product);
                    LoadProducts();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Update failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void BtnDelete_Click(object? s, EventArgs e)
        {
            try
            {
                if (dgv.CurrentRow?.DataBoundItem is not Product p) { MessageBox.Show("Select a product first."); return; }
                var confirm = MessageBox.Show($"Delete product {p.Name} (ID {p.Id})?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm != DialogResult.Yes) return;
                bl.Product.Delete(p.Id);
                LoadProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Delete failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void BtnRestock_Click(object? s, EventArgs e)
        {
            try
            {
                if (dgv.CurrentRow?.DataBoundItem is not Product p) { MessageBox.Show("Select a product first."); return; }
                string input = Microsoft.VisualBasic.Interaction.InputBox("Enter quantity to add:", "Restock", "10");
                if (int.TryParse(input, out int qty) && qty > 0)
                {
                    p.QuantityInStock += qty;
                    bl.Product.Update(p);
                    LoadProducts();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Restock failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}