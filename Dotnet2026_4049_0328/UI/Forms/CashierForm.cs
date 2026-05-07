using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using BL.BlApi;
using UI.Services;

namespace UI.Forms
{
    public class CashierForm : Form
    {
        readonly IBl bl = Factory.Get;

        DataGridView dgvCart = new();
        Label lblTotal = new() { Text = "Total: $0.00", ForeColor = Color.Gold, AutoSize = true, Font = new Font("Segoe UI", 14F, FontStyle.Bold) };
        Button btnCheckout = new() { Text = "Checkout", Width = 140, Height = 36 };
        Button btnBack = new() { Text = "Back", Width = 100, Height = 36 };

        public CashierForm()
        {
            Text = "Cashier - Create Order";
            Font = new Font("Segoe UI", 9F);
            BackColor = Color.FromArgb(10, 25, 40);
            ForeColor = Color.White;
            WindowState = FormWindowState.Maximized;

            InitializeLayout();

            Load += (s, e) =>
            {
                dgvCart.DataSource = CartService.Cart;
                RefreshCart();
            };

            // refresh whenever cart changes
            CartService.CartChanged += (s, e) => RefreshCart();
            CartService.Cart.ListChanged += (s, e) => RefreshCart();
        }

        void InitializeLayout()
        {
            var root = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 1, RowCount = 3, Padding = new Padding(16) };
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 88));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 88));

            var header = new FlowLayoutPanel { Dock = DockStyle.Fill, FlowDirection = FlowDirection.LeftToRight, Padding = new Padding(8) };
            header.Controls.Add(new Label { Text = "Cashier - Order", Font = new Font("Segoe UI", 20F, FontStyle.Bold), ForeColor = Color.Gold, AutoSize = true });
            header.Controls.Add(new Label { Text = " ", AutoSize = true, Width = 40 });
            header.Controls.Add(lblTotal);
            header.Controls.Add(new FlowLayoutPanel { Width = 20 });
            btnCheckout.BackColor = Color.FromArgb(30, 90, 160);
            btnCheckout.ForeColor = Color.White;
            btnCheckout.Click += BtnCheckout_Click;
            btnBack.Click += (s, e) => Close();
            header.Controls.Add(btnCheckout);
            header.Controls.Add(btnBack);

            root.Controls.Add(header, 0, 0);

            dgvCart.Dock = DockStyle.Fill;
            dgvCart.AutoGenerateColumns = false;
            dgvCart.ReadOnly = true;
            dgvCart.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCart.RowHeadersVisible = false;
            SetDoubleBuffer(dgvCart, true);

            dgvCart.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "ProductId", DataPropertyName = "ProductId", Width = 100 });
            dgvCart.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Name", DataPropertyName = "Name", Width = 420 });
            dgvCart.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Qty", DataPropertyName = "Quantity", Width = 90 });
            dgvCart.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Unit", DataPropertyName = "UnitPrice", Width = 140, DefaultCellStyle = { Format = "C2" } });
            dgvCart.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Total", DataPropertyName = "LineTotal", Width = 140, DefaultCellStyle = { Format = "C2" } });

            root.Controls.Add(dgvCart, 0, 1);

            Controls.Add(root);
        }

        static void SetDoubleBuffer(Control c, bool enabled)
        {
            try
            {
                var prop = typeof(Control).GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
                prop?.SetValue(c, enabled, null);
            }
            catch { }
        }

        void RefreshCart()
        {
            try
            {
                dgvCart.InvokeIfRequired(() =>
                {
                    dgvCart.Refresh();

                    // compute grand total and apply simple promotions from BL.Sale
                    double grand = 0.0;
                    var sales = new System.Collections.Generic.List<BO.Sale>();
                    try
                    {
                        sales = bl.Sale.ReadAll() ?? new System.Collections.Generic.List<BO.Sale>();
                    }
                    catch
                    {
                        // if promotions unavailable, proceed with normal pricing
                        sales = new System.Collections.Generic.List<BO.Sale>();
                    }

                    foreach (var line in CartService.Cart)
                    {
                        double unit = line.UnitPrice;
                        // safe: try to find sale by product id
                        var active = sales.FirstOrDefault(s => s != null && s.ProductId == line.ProductId && DateTime.Now >= s.SaleStartDate && DateTime.Now <= s.SaleEndDate);
                        if (active != null)
                        {
                            // if sale.Quantity > 0 treat TotalPrice as price-for-quantity, compute unit
                            if (active.Quantity > 0)
                            {
                                var discountedUnit = active.TotalPrice / Math.Max(active.Quantity, 1);
                                unit = Math.Min(unit, discountedUnit);
                            }
                            else
                            {
                                // if quantity not set, but TotalPrice is lower than unit treat as special unit price
                                if (active.TotalPrice > 0 && active.TotalPrice < unit)
                                    unit = active.TotalPrice;
                            }
                        }

                        grand += unit * line.Quantity;
                    }

                    lblTotal.Text = $"Total: {grand:C2}";
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to refresh cart: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        async void BtnCheckout_Click(object? s, EventArgs e)
        {
            if (CartService.Cart.Count == 0) { MessageBox.Show("Cart is empty.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            var confirm = MessageBox.Show($"Finalize order with total {lblTotal.Text}?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                // create Sale entries via BL.Sale.Create with null-safety
                foreach (var line in CartService.Cart.ToList())
                {
                    if (line == null) continue;
                    var sale = new BO.Sale
                    {
                        ProductId = line.ProductId,
                        Quantity = line.Quantity,
                        TotalPrice = line.LineTotal,
                        IsClub = false,
                        SaleStartDate = DateTime.Now,
                        SaleEndDate = DateTime.Now
                    };
                    bl.Sale.Create(sale);
                }

                    CartService.Clear();
                MessageBox.Show("Order finalized. Sales recorded.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Checkout failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    static class ControlExtensions
    {
        public static void InvokeIfRequired(this Control c, Action action)
        {
            if (c.IsHandleCreated && c.InvokeRequired) c.Invoke(action);
            else action();
        }
    }
}