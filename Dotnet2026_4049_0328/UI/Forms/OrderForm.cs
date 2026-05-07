using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BL.BlApi;
using BO;

namespace UI.Forms
{
    public class OrderForm : Form
    {
        readonly IBl bl = Factory.Get;

        ComboBox cmbProducts = new() { Width = 420 };
        TextBox txtProductId = new() { Width = 120 };
        NumericUpDown nudQuantity = new() { Width = 80, Minimum = 1, Maximum = 1000, Value = 1 };
        Button btnAdd = new() { Text = "Add to Cart" };
        DataGridView dgvCart = new();
        Label lblTotal = new() { Text = "Total: $0.00", ForeColor = Color.Gold, AutoSize = true, Font = new Font("Segoe UI", 12F, FontStyle.Bold) };
        Button btnCheckout = new() { Text = "Checkout", Width = 140, Height = 36 };

        BindingList<CartLine> cart = new();

        public OrderForm()
        {
            Text = "Cashier - Create Order";
            Font = new Font("Segoe UI", 9F);
            BackColor = Color.FromArgb(10, 25, 40);
            ForeColor = Color.White;
            Size = new Size(920, 640);
            StartPosition = FormStartPosition.CenterParent;

            InitializeLayout();
            LoadProducts();
        }

        void InitializeLayout()
        {
            var p = new Panel { Location = new Point(20, 12), Size = new Size(860, 80) };
            var lblPick = new Label { Text = "Select product:", Location = new Point(0, 10), AutoSize = true, ForeColor = Color.White };
            cmbProducts.Location = new Point(110, 8);
            cmbProducts.DropDownStyle = ComboBoxStyle.DropDownList;
            var lblId = new Label { Text = "or ID:", Location = new Point(0, 44), ForeColor = Color.White, AutoSize = true };
            txtProductId.Location = new Point(110, 40);
            var lblQty = new Label { Text = "Qty:", Location = new Point(250, 44), ForeColor = Color.White, AutoSize = true };
            nudQuantity.Location = new Point(290, 40);
            btnAdd.Location = new Point(400, 36);

            btnAdd.Click += BtnAdd_Click;
            p.Controls.AddRange(new Control[] { lblPick, cmbProducts, lblId, txtProductId, lblQty, nudQuantity, btnAdd });
            Controls.Add(p);

            dgvCart.Location = new Point(20, 110);
            dgvCart.Size = new Size(860, 380);
            dgvCart.AutoGenerateColumns = false;
            dgvCart.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCart.ReadOnly = true;

            dgvCart.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "ProductId", DataPropertyName = "ProductId", Width = 90 });
            dgvCart.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Name", DataPropertyName = "Name", Width = 360 });
            dgvCart.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Qty", DataPropertyName = "Quantity", Width = 80 });
            dgvCart.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Unit", DataPropertyName = "UnitPrice", Width = 120 });
            dgvCart.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Total", DataPropertyName = "LineTotal", Width = 120 });

            Controls.Add(dgvCart);

            var bottom = new Panel { Location = new Point(20, 510), Size = new Size(860, 100) };
            lblTotal.Location = new Point(6, 10);
            btnCheckout.Location = new Point(700, 30);
            btnCheckout.BackColor = Color.FromArgb(30, 90, 160);
            btnCheckout.ForeColor = Color.White;
            btnCheckout.Click += BtnCheckout_Click;

            bottom.Controls.Add(lblTotal);
            bottom.Controls.Add(btnCheckout);
            Controls.Add(bottom);

            dgvCart.DataSource = cart;
        }

        void LoadProducts()
        {
            try
            {
                var all = bl.Product.ReadAll();
                var list = all.Select(p => new { p.Id, Display = $"{p.Id} - {p.Name} ({p.Price:C})" }).ToList();
                cmbProducts.DataSource = list;
                cmbProducts.DisplayMember = "Display";
                cmbProducts.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to load products: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void BtnAdd_Click(object? s, EventArgs e)
        {
            try
            {
                int productId;
                if (!string.IsNullOrWhiteSpace(txtProductId.Text) && int.TryParse(txtProductId.Text, out var pidFromText))
                    productId = pidFromText;
                else if (cmbProducts.SelectedValue != null)
                    productId = Convert.ToInt32(cmbProducts.SelectedValue);
                else
                {
                    MessageBox.Show("Select or enter a product ID.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var prod = bl.Product.Read(productId);
                if (prod == null) { MessageBox.Show($"Product {productId} not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                int qty = (int)nudQuantity.Value;
                var existing = cart.FirstOrDefault(c => c.ProductId == productId);
                if (existing != null)
                {
                    existing.Quantity += qty;
                    existing.LineTotal = existing.Quantity * existing.UnitPrice;
                }
                else
                {
                    cart.Add(new CartLine
                    {
                        ProductId = prod.Id,
                        Name = prod.Name,
                        Quantity = qty,
                        UnitPrice = prod.Price,
                        LineTotal = qty * prod.Price
                    });
                }

                RefreshCart();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Add to cart failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void RefreshCart()
        {
            dgvCart.Refresh();
            lblTotal.Text = $"Total: {cart.Sum(x => x.LineTotal):C2}";
        }

        void BtnCheckout_Click(object? s, EventArgs e)
        {
            if (cart.Count == 0) { MessageBox.Show("Cart is empty.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            var confirm = MessageBox.Show($"Finalize order with total {cart.Sum(x => x.LineTotal):C2}?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                // Map cart lines to Sale objects via BL.Sale.Create
                foreach (var line in cart.ToList())
                {
                    var sale = new Sale
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

                cart.Clear();
                RefreshCart();
                MessageBox.Show("Order finalized. Sales recorded.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Checkout failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        class CartLine
        {
            public int ProductId { get; set; }
            public string? Name { get; set; }
            public int Quantity { get; set; }
            public double UnitPrice { get; set; }
            public double LineTotal { get; set; }
        }
    }
}