using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using UI.Forms;

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
}