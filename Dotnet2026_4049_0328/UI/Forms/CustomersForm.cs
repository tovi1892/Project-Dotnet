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
    public class CustomersForm : Form
    {
        readonly IBl bl = Factory.Get;

        DataGridView dgv = new();
        TextBox txtSearch = new() { Width = 300 };
        Button btnSearch = new() { Text = "Filter" };
        Button btnRefresh = new() { Text = "Refresh" };
        Button btnAdd = new() { Text = "Add" };
        Button btnUpdate = new() { Text = "Update" };
        Button btnDelete = new() { Text = "Delete" };
        Button btnBack = new() { Text = "Back" };

        TextBox txtName = new() { Width = 240 };
        TextBox txtAddress = new() { Width = 300 };
        TextBox txtPhone = new() { Width = 180 };

        BindingList<Customer> bound = new();

        public CustomersForm()
        {
            Text = "Customers Manager";
            Font = new Font("Segoe UI", 9F);
            BackColor = Color.FromArgb(10, 25, 40);
            ForeColor = Color.White;
            WindowState = FormWindowState.Maximized;

            InitializeLayout();

            // bind early to avoid drawing issues and load data when form shows
            bound = new BindingList<Customer>();
            dgv.DataSource = bound;

            Load += (s, e) => LoadCustomers();
        }

        void InitializeLayout()
        {
            var root = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 1, RowCount = 3, Padding = new Padding(12) };
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 72));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 180));

            // Top search row
            var top = new FlowLayoutPanel { Dock = DockStyle.Fill, FlowDirection = FlowDirection.LeftToRight, AutoSize = true };
            top.Controls.Add(new Label { Text = "Name contains:", ForeColor = Color.White, AutoSize = true, TextAlign = ContentAlignment.MiddleLeft });

            txtSearch.Location = new Point(110, 6);
            // subscribe to TextChanged with a named handler (safe, clear)
            txtSearch.TextChanged += TxtSearch_TextChanged;
            top.Controls.Add(txtSearch);

            btnSearch.Click += (s, e) => LoadCustomers();
            top.Controls.Add(btnSearch);

            btnRefresh.Click += (s, e) => { txtSearch.Text = ""; LoadCustomers(); };
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

            dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "ID", DataPropertyName = "Id", Width = 100 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Name", DataPropertyName = "Name", Width = 360 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Address", DataPropertyName = "Address", Width = 420 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Phone", DataPropertyName = "PhoneNumber", Width = 200 });

            dgv.SelectionChanged += Dgv_SelectionChanged;

            root.Controls.Add(dgv, 0, 1);

            // Editor / actions
            var editor = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, RowCount = 1, Padding = new Padding(8) };
            editor.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70));
            editor.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30));

            var left = new FlowLayoutPanel { FlowDirection = FlowDirection.TopDown, Dock = DockStyle.Fill, AutoSize = true };
            left.Controls.Add(new Label { Text = "Name:", ForeColor = Color.White, AutoSize = true });
            left.Controls.Add(txtName);
            left.Controls.Add(new Label { Text = "Address:", ForeColor = Color.White, AutoSize = true });
            left.Controls.Add(txtAddress);
            left.Controls.Add(new Label { Text = "Phone:", ForeColor = Color.White, AutoSize = true });
            left.Controls.Add(txtPhone);

            var right = new FlowLayoutPanel { FlowDirection = FlowDirection.TopDown, Dock = DockStyle.Fill, AutoSize = true };
            btnAdd.Click += BtnAdd_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnDelete.Click += BtnDelete_Click;
            btnBack.Click += (s, e) => Close();

            right.Controls.Add(btnAdd);
            right.Controls.Add(btnUpdate);
            right.Controls.Add(btnDelete);
            right.Controls.Add(new Label { Text = " ", AutoSize = true });
            right.Controls.Add(btnBack);

            editor.Controls.Add(left, 0, 0);
            editor.Controls.Add(right, 1, 0);

            root.Controls.Add(editor, 0, 2);

            Controls.Add(root);
        }

        // Named handler for the search box
        private void TxtSearch_TextChanged(object? sender, EventArgs e)
        {
            LoadCustomers();
        }

        void LoadCustomers()
        {
            try
            {
                var all = bl.Customer.ReadAll() ?? new List<Customer>();

                var filter = txtSearch.Text?.Trim() ?? string.Empty;
                if (!string.IsNullOrWhiteSpace(filter))
                    all = all.Where(c => (c.Name ?? string.Empty).Contains(filter, StringComparison.OrdinalIgnoreCase)).ToList();

                bound = new BindingList<Customer>(all.ToList());
                dgv.DataSource = bound;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to load customers: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void Dgv_SelectionChanged(object? s, EventArgs e)
        {
            if (dgv.CurrentRow?.DataBoundItem is Customer c)
            {
                txtName.Text = c.Name ?? string.Empty;
                txtAddress.Text = c.Address ?? string.Empty;
                txtPhone.Text = c.PhoneNumber ?? string.Empty;
            }
        }

        void BtnAdd_Click(object? s, EventArgs e)
        {
            try
            {
                var item = new Customer
                {
                    Name = txtName.Text?.Trim() ?? string.Empty,
                    Address = txtAddress.Text?.Trim() ?? string.Empty,
                    PhoneNumber = txtPhone.Text?.Trim() ?? string.Empty
                };
                int id = bl.Customer.Create(item);
                MessageBox.Show($"Customer created (ID {id})", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCustomers();
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
                if (dgv.CurrentRow?.DataBoundItem is not Customer c) { MessageBox.Show("Select a customer first."); return; }

                c.Name = txtName.Text?.Trim() ?? string.Empty;
                c.Address = txtAddress.Text?.Trim() ?? string.Empty;
                c.PhoneNumber = txtPhone.Text?.Trim() ?? string.Empty;

                bl.Customer.Update(c);
                MessageBox.Show("Customer updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCustomers();
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
                if (dgv.CurrentRow?.DataBoundItem is not Customer c) { MessageBox.Show("Select a customer first."); return; }
                var confirm = MessageBox.Show($"Delete customer {c.Name} (ID {c.Id})?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm != DialogResult.Yes) return;
                bl.Customer.Delete(c.Id);
                MessageBox.Show("Customer deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCustomers();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Delete failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}