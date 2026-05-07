using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using BL.BlApi;
using UI.Services;
using UI.Services;
using BO;

namespace UI.Forms
{
    public class ProductsForm : Form
    {
        readonly IBl bl = Factory.Get;

        DataGridView dgv = new();
        TextBox txtSearch = new() { Width = 260 };
        ComboBox cmbCategory = new() { Width = 180 };
        Button btnSearch = new() { Text = "Filter" };
        Button btnRefresh = new() { Text = "Refresh" };
        Button btnAdd = new() { Text = "Add" };
        Button btnUpdate = new() { Text = "Update" };
        Button btnDelete = new() { Text = "Delete" };

        TextBox txtName = new() { Width = 220 };
        ComboBox cmbEditCategory = new() { Width = 160 };
        NumericUpDown nudPrice = new() { DecimalPlaces = 2, Maximum = 1_000_000, Width = 120 };
        NumericUpDown nudQty = new() { Maximum = 1_000_000, Width = 120 };

        BindingList<Product> boundProducts = new();

        public ProductsForm()
        {
            Text = "Products Manager";
            Font = new Font("Segoe UI", 9F);
            BackColor = Color.FromArgb(10, 25, 40);
            ForeColor = Color.White;
            Size = new Size(900, 600);
            StartPosition = FormStartPosition.CenterParent;

            InitializeLayout();
            LoadCategories();
            LoadProducts();
        }

        void InitializeLayout()
        {
            dgv.Location = new Point(20, 60);
            dgv.Size = new Size(840, 340);
            dgv.ReadOnly = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoGenerateColumns = false;
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(12, 30, 50);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.Gold;
            dgv.BackgroundColor = Color.FromArgb(6, 20, 35);
            dgv.GridColor = Color.Gray;

            dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "ID", DataPropertyName = "Id", Width = 60 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Name", DataPropertyName = "Name", Width = 280 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Category", DataPropertyName = "Category", Width = 150 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Price", DataPropertyName = "Price", Width = 120 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "In Stock", DataPropertyName = "QuantityInStock", Width = 120 });

            var topPanel = new Panel { Location = new Point(20, 12), Size = new Size(840, 40) };
            var lblSearch = new Label { Text = "Name contains:", ForeColor = Color.White, AutoSize = true, Location = new Point(0, 8) };
            cmbCategory.Location = new Point(280, 6);
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            txtSearch.Location = new Point(110, 6);
            btnSearch.Location = new Point(470, 4);
            btnRefresh.Location = new Point(560, 4);

            btnSearch.Click += (s, e) => LoadProducts();
            btnRefresh.Click += (s, e) => { txtSearch.Text = ""; cmbCategory.SelectedIndex = -1; LoadProducts(); };

            topPanel.Controls.AddRange(new Control[] { lblSearch, txtSearch, cmbCategory, btnSearch, btnRefresh });
            Controls.Add(topPanel);
            Controls.Add(dgv);

            // Editor panel
            var editor = new GroupBox { Text = "Edit / Add Product", ForeColor = Color.Gold, Location = new Point(20, 420), Size = new Size(840, 120) };
            var lblName = new Label { Text = "Name:", ForeColor = Color.White, Location = new Point(12, 24), AutoSize = true };
            txtName.Location = new Point(70, 20);
            var lblCat = new Label { Text = "Category:", ForeColor = Color.White, Location = new Point(320, 24), AutoSize = true };
            cmbEditCategory.Location = new Point(390, 20);
            var lblPrice = new Label { Text = "Price:", ForeColor = Color.White, Location = new Point(12, 60), AutoSize = true };
            nudPrice.Location = new Point(70, 56);
            var lblQty = new Label { Text = "Qty:", ForeColor = Color.White, Location = new Point(220, 60), AutoSize = true };
            nudQty.Location = new Point(260, 56);

            btnAdd.Location = new Point(580, 22);
            btnUpdate.Location = new Point(580, 54);
            btnDelete.Location = new Point(680, 22);

            btnAdd.Click += BtnAdd_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnDelete.Click += BtnDelete_Click;
            dgv.SelectionChanged += Dgv_SelectionChanged;

            editor.Controls.AddRange(new Control[] { lblName, txtName, lblCat, cmbEditCategory, lblPrice, nudPrice, lblQty, nudQty, btnAdd, btnUpdate, btnDelete });
            Controls.Add(editor);
        }

        void LoadCategories()
        {
            try
            {
                cmbCategory.Items.Clear();
                cmbEditCategory.Items.Clear();
                foreach (var name in Enum.GetNames(typeof(BO.Categories)))
                {
                    cmbCategory.Items.Add(name);
                    cmbEditCategory.Items.Add(name);
                }
                cmbCategory.Items.Insert(0, "-- All Categories --");
            }
            catch
            {
                // If enum is unavailable for any reason, leave category combo empty
            }
        }

        void LoadProducts()
        {
            try
            {
                var all = bl.Product.ReadAll();
                IEnumerable<Product> filtered = all;

                if (!string.IsNullOrWhiteSpace(txtSearch.Text))
                    filtered = filtered.Where(p => (p.Name ?? "").Contains(txtSearch.Text, StringComparison.OrdinalIgnoreCase));

                if (cmbCategory.SelectedIndex > 0)
                {
                    var selected = cmbCategory.SelectedItem.ToString();
                    filtered = filtered.Where(p => p.Category.ToString().Equals(selected, StringComparison.OrdinalIgnoreCase));
                }

                boundProducts = new BindingList<Product>(filtered.ToList());
                dgv.DataSource = boundProducts;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to load products: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void Dgv_SelectionChanged(object? s, EventArgs e)
        {
            if (dgv.CurrentRow?.DataBoundItem is Product p)
            {
                txtName.Text = p.Name;
                cmbEditCategory.SelectedItem = p.Category.ToString();
                nudPrice.Value = Convert.ToDecimal(p.Price);
                nudQty.Value = p.QuantityInStock;
            }
        }

        void BtnAdd_Click(object? s, EventArgs e)
        {
            try
            {
                var item = new Product
                {
                    Name = txtName.Text.Trim(),
                    Price = Convert.ToDouble(nudPrice.Value),
                    QuantityInStock = (int)nudQty.Value
                };
                if (cmbEditCategory.SelectedItem != null)
                    item.Category = (BO.Categories)Enum.Parse(typeof(BO.Categories), cmbEditCategory.SelectedItem.ToString());

                int id = bl.Product.Create(item);
                MessageBox.Show($"Product created (ID {id})", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Create failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void BtnUpdate_Click(object? s, EventArgs e)
        {
            try
            {
                if (dgv.CurrentRow?.DataBoundItem is not Product p) { MessageBox.Show("Select a product first."); return; }

                p.Name = txtName.Text.Trim();
                p.Price = Convert.ToDouble(nudPrice.Value);
                p.QuantityInStock = (int)nudQty.Value;
                if (cmbEditCategory.SelectedItem != null)
                    p.Category = (BO.Categories)Enum.Parse(typeof(BO.Categories), cmbEditCategory.SelectedItem.ToString());

                bl.Product.Update(p);
                MessageBox.Show("Product updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadProducts();
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
                MessageBox.Show("Product deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Delete failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}