using BlApi;
using BO;
using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UI_
{
    public partial class Cashier : Form
    {
        IBl bl = Factory.Get();
        private BO.Order? currentOrder = null;
        private BO.Client? currentClient = null;

        public Cashier()
        {
            InitializeComponent();
            panelDetails.Visible = false;
            panelOrder.Visible = false;

        }

        private void Cashier_Load(object sender, EventArgs e)
        {
            try
            {
                panelDetails.Visible = false;
                panelOrder.Visible = false;
                panelOpen.Visible = true;
                var products = bl.IProduct.GetAll();
                comboProducts.DataSource = products.ToList();
                comboProducts.DisplayMember = "Name";
                comboProducts.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load products: {ex.Message}");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void comboProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboProducts.SelectedItem is BO.Product p)
            {
                productIdTextBox.Text = p.Id.ToString();
                UpdateDetails();
            }
        }

        private void quantityUpDown_ValueChanged(object sender, EventArgs e)
        {
            UpdateDetails();
        }

        private void UpdateDetails()
        {
            try
            {
                if (!int.TryParse(productIdTextBox.Text, out var productId))
                {
                    lblDetailName.Text = "Name:";
                    lblDetailUnit.Text = "Unit price:";
                    lblDetailQty.Text = "Quantity:";
                    lblDetailSalesCount.Text = "Active sales: 0";
                    return;
                }

                var product = bl.IProduct.Get(productId);
                if (product == null)
                {
                    lblDetailName.Text = "Name: (not found)";
                    lblDetailUnit.Text = "Unit price:";
                    lblDetailQty.Text = "Quantity:";
                    lblDetailSalesCount.Text = "Active sales: 0";
                    return;
                }

                int qty = (int)quantityUpDown.Value;
                lblDetailName.Text = $"Name: {product.Name}";
                lblDetailUnit.Text = $"Unit price: {product.Price}";
                lblDetailQty.Text = $"Quantity: {qty}";


                var pio = new BO.ProductInOrder { ProductId = product.Id, Name = product.Name, BasePrice = product.Price, Quantity_in_order = qty };
                bool isPreferred = currentClient?.IsClubMember ?? false;
                bl.IOrder.SearchSaleForProduct(pio, isPreferred);
                lblDetailSalesCount.Text = $"Active sales: {(pio.Sales?.Count ?? 0)}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating details: {ex.Message}");
            }
        }

        private void addProductButton_Click(object sender, EventArgs e)
        {
            try
            {
                int productId;
                if (!string.IsNullOrWhiteSpace(productIdTextBox.Text) && int.TryParse(productIdTextBox.Text, out productId))
                {
                }
                else if (comboProducts.SelectedItem != null)
                {
                    productId = ((BO.Product)comboProducts.SelectedItem).Id;
                }
                else
                {
                    MessageBox.Show("Select a product or enter a product id.");
                    return;
                }

                int quantity = (int)quantityUpDown.Value;
                var sales = bl.IOrder.AddProductToOrder(currentOrder, productId, quantity);
                RefreshOrderGrid();
                MessageBox.Show($"Product added. Applied sales: {sales.Count}");
            }
            catch (FormatException)
            {
                MessageBox.Show("Product id must be a valid number");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RefreshOrderGrid()
        {
        

            var list = currentOrder.Products.Select(p => new
            {
                Id = p.ProductId,
                Name = p.Name,
                Quantity = p.Quantity_in_order,
                UnitPrice = p.BasePrice,
                FinalPrice = p.FinalPrice_in_total
            }).ToList();

            dgvOrder.DataSource = null;
            dgvOrder.DataSource = list;
            lblTotal.Text = $"Total: {currentOrder.FinalPrice} ";
        }

        private void buttonShowSales_Click(object sender, EventArgs e)
        {
            try
            {
                List<SaleInProduct> list = new List<SaleInProduct>();
                currentOrder.Products.ForEach(p=>p.Sales.ForEach(s=>list.Add(s)));
                
                using var form = new SalesListForm();
                form.SetSales(list ?? new System.Collections.Generic.List<BO.SaleInProduct>());
                form.ShowDialog();
            }
            catch (FormatException)
            {
                MessageBox.Show("Product id must be a valid number");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDoOrder_Click(object sender, EventArgs e)
        {
           
            try
            {
                bl.IOrder.DoOrder(currentOrder);
                MessageBox.Show("Order completed.");
                Cashier_Load(null, null);
                currentOrder = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonManager_Click(object sender, EventArgs e)
        {
            try
            {
                var mgr = new Manager();
                mgr.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to open Manager: {ex.Message}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // parse id first
            if (!int.TryParse(customerId.Text, out var id))
            {
                MessageBox.Show("Id must be a valid number");
                return;
            }

            // check existence first to avoid exceptions
            try
            {
                if (bl.IClient.Exists(id))
                {
                    var c = bl.IClient.Get(id);
                    currentClient = c;
                    currentOrder = new BO.Order { IsPreferredClient = c.IsClubMember };
                    panelDetails.Visible = true;
                    panelOrder.Visible = true;
                    panelOpen.Visible = false;
                    RefreshOrderGrid();
                    MessageBox.Show($"Client loaded: {c.Name}. New order started.");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking client: {ex.Message}");
                return;
            }

            var dr = MessageBox.Show($"Client with ID '{id}' was not found.\nYes = create new client and start order, No = try again", "Client not found", MessageBoxButtons.YesNoCancel);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    using var form = new AddClientForm(bl, id);
                    var result = form.ShowDialog();
                    if (result == DialogResult.OK && form.CreatedClient != null)
                    {
                        currentClient = form.CreatedClient;
                        currentOrder = new BO.Order { IsPreferredClient = currentClient.IsClubMember };
                        panelDetails.Visible = true;
                        panelOrder.Visible = true;
                        panelOpen.Visible = false;
                        RefreshOrderGrid();
                        MessageBox.Show($"New client created and order started for ID {currentClient.Id}.");
                    }
                }
                catch (Exception ex2)
                {
                    MessageBox.Show($"Failed to create client: {ex2.Message}");
                }
            }
        }

        private void lblDetailQty_Click(object sender, EventArgs e)
        {

        }

        private void lblDetailUnit_Click(object sender, EventArgs e)
        {
        }


        private void lblTotal_Click(object sender, EventArgs e)
        {

        }

        private void panelOpen_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
