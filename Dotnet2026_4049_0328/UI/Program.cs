using UI.Forms;

namespace UI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
    public class MainForm : Form
    {
        Button btnManager, btnCashier;

        public MainForm()
        {
            Text = "Jewelry Store - Main Hub";
            WindowState = FormWindowState.Maximized;
            Font = new Font("Segoe UI", 10F);
            BackColor = Color.FromArgb(10, 25, 40);

            var root = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, RowCount = 1, Padding = new Padding(40) };
            root.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            root.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));

            // Manager Dashboard
            var managerPanel = new Panel { Dock = DockStyle.Fill, BackColor = Color.FromArgb(20, 40, 60), Padding = new Padding(24) };
            btnManager = new Button { Text = "Manager Dashboard", Dock = DockStyle.Fill, Height = 80, Font = new Font(Font, FontStyle.Bold) };
            btnManager.Click += (s, e) => new ManagerDashboardForm().ShowDialog();
            managerPanel.Controls.Add(btnManager);

            // Cashier Station
            var cashierPanel = new Panel { Dock = DockStyle.Fill, BackColor = Color.FromArgb(20, 40, 60), Padding = new Padding(24) };
            btnCashier = new Button { Text = "Cashier Station", Dock = DockStyle.Fill, Height = 80, Font = new Font(Font, FontStyle.Bold) };
            btnCashier.Click += (s, e) => new CashierForm().ShowDialog();
            cashierPanel.Controls.Add(btnCashier);

            root.Controls.Add(managerPanel, 0, 0);
            root.Controls.Add(cashierPanel, 1, 0);

            Controls.Add(root);
        }
    }
    public class ProductManagementForm : Form
    {
        readonly IBl bl = Factory.Get;
        DataGridView dgv = new();
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

            dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "ID", DataPropertyName = "Id", Width = 100 });
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