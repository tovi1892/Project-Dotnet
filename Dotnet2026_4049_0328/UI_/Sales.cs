using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlApi;
using BO;

namespace UI_
{
    public partial class Sales : Form
    {
        IBl bl = Factory.Get();

        public Sales()
        {
            InitializeComponent();
            panel1.Visible = false;
            panelID.Visible = false;
            panelUpdate.Visible = false;
            panelDelete.Visible = false;
            panelShowAll.Visible = false;
            LoadProductsToComboBox();
        }

        private void LoadProductsToComboBox()
        {
            try
            {
                var products = bl.IProduct.GetAll().ToList();
                productComboBox.DataSource = products;
                productComboBox.DisplayMember = "Name";
                productComboBox.ValueMember = "Id";
                productComboBox.SelectedIndex = -1;

                productComboBoxUpdate.DataSource = new List<Product>(products);
                productComboBoxUpdate.DisplayMember = "Name";
                productComboBoxUpdate.ValueMember = "Id";
                productComboBoxUpdate.SelectedIndex = -1;

                productFilterComboBox.DataSource = new List<Product>(products);
                productFilterComboBox.DisplayMember = "Name";
                productFilterComboBox.ValueMember = "Id";
                productFilterComboBox.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading products: {ex.Message}");
            }
        }

        private void Sales_Load(object sender, EventArgs e)
        {

        }

        private void createSale_Click(object sender, EventArgs e)
        {
            ClearCreatePanel();
            panel1.Visible = true;
        }

        private void confirmCreate_Click(object sender, EventArgs e)
        {
            if (productComboBox.SelectedIndex == -1 || string.IsNullOrEmpty(amountTextBox.Text) ||
                string.IsNullOrEmpty(costTextBox.Text) || startDatePicker.Value == null || endDatePicker.Value == null)
            {
                MessageBox.Show("Please fill in all fields");
            }
            else
            {
                try
                {
                    int productId = (int)productComboBox.SelectedValue;
                    int amount = int.Parse(amountTextBox.Text);
                    int cost = int.Parse(costTextBox.Text);
                    bool toClub = clubCheckBox.Checked;
                    DateTime startDate = startDatePicker.Value;
                    DateTime endDate = endDatePicker.Value;

                    if (amount <= 0 || cost <= 0)
                    {
                        MessageBox.Show("Amount and Cost must be positive numbers");
                        return;
                    }

                    if (startDate >= endDate)
                    {
                        MessageBox.Show("Start date must be before end date");
                        return;
                    }

                    bl.ISale.Create(new BO.Sale
                    {
                        ProductId = productId,
                        amount_to_sale = amount,
                        cost_per_one = cost,
                        to_club = toClub,
                        start_date = startDate,
                        end_date = endDate
                    });
                    MessageBox.Show("New sale created successfully!");
                    panel1.Visible = false;
                    ClearCreatePanel();
                }
                catch (FormatException)
                {
                    MessageBox.Show("Amount and Cost must be valid numbers");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error creating sale: {ex.Message}");
                }
            }
        }

        private void showSale_Click(object sender, EventArgs e)
        {
            idTextBox.Text = "";
            panelID.Visible = true;
            idTextBox.Focus();
        }

        private void confirmAction_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(idTextBox.Text))
            {
                MessageBox.Show("Please enter sale ID");
            }
            else
            {
                try
                {
                    int id = int.Parse(idTextBox.Text);
                    var sale = bl.ISale.Get(id);

                    if (sale == null)
                    {
                        MessageBox.Show($"Sale with ID {id} not found");
                        return;
                    }

                    MessageBox.Show($"Sale Details:\n\nID: {sale.Id}\nProduct ID: {sale.ProductId}\n" +
                        $"Amount: {sale.amount_to_sale}\nCost per One: {sale.cost_per_one}\n" +
                        $"For Club Members: {(sale.to_club ? "Yes" : "No")}\n" +
                        $"Start Date: {sale.start_date:yyyy-MM-dd}\nEnd Date: {sale.end_date:yyyy-MM-dd}");
                    panelID.Visible = false;
                }
                catch (FormatException)
                {
                    MessageBox.Show("ID must be a valid number");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error retrieving sale: {ex.Message}");
                }
            }
        }

        private void updateSale_Click(object sender, EventArgs e)
        {
            ClearUpdatePanel();
            panelUpdate.Visible = true;
        }

        private void deleteSale_Click(object sender, EventArgs e)
        {
            panelDelete.Visible = true;
        }

        private void showAllSales_Click(object sender, EventArgs e)
        {
            try
            {
                var allSales = bl.ISale.GetAll().ToList();

                if (!allSales.Any())
                {
                    MessageBox.Show("No sales found");
                    return;
                }

                dataGridViewSales.DataSource = null;
                dataGridViewSales.DataSource = allSales;

                panelShowAll.Visible = true;
                filterTextBox.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving sales: {ex.Message}");
            }
        }

        private void ClearCreatePanel()
        {
            productComboBox.SelectedIndex = -1;
            amountTextBox.Text = "";
            costTextBox.Text = "";
            clubCheckBox.Checked = false;
            startDatePicker.Value = DateTime.Now;
            endDatePicker.Value = DateTime.Now.AddDays(7);
        }

        private void ClearUpdatePanel()
        {
            upIdTextBox.Text = "";
            productComboBoxUpdate.SelectedIndex = -1;
            upAmountTextBox.Text = "";
            upCostTextBox.Text = "";
            clubCheckBoxUpdate.Checked = false;
            upStartDatePicker.Value = DateTime.Now;
            upEndDatePicker.Value = DateTime.Now.AddDays(7);
            upIdTextBox.Focus();
        }

        private void UpdateConfirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(upIdTextBox.Text) || productComboBoxUpdate.SelectedIndex == -1 ||
                string.IsNullOrEmpty(upAmountTextBox.Text) || string.IsNullOrEmpty(upCostTextBox.Text))
            {
                MessageBox.Show("Please fill in all fields");
            }
            else
            {
                try
                {
                    int id = int.Parse(upIdTextBox.Text);
                    int productId = (int)productComboBoxUpdate.SelectedValue;
                    int amount = int.Parse(upAmountTextBox.Text);
                    int cost = int.Parse(upCostTextBox.Text);
                    bool toClub = clubCheckBoxUpdate.Checked;
                    DateTime startDate = upStartDatePicker.Value;
                    DateTime endDate = upEndDatePicker.Value;

                    if (amount <= 0 || cost <= 0)
                    {
                        MessageBox.Show("Amount and Cost must be positive numbers");
                        return;
                    }

                    if (startDate >= endDate)
                    {
                        MessageBox.Show("Start date must be before end date");
                        return;
                    }

                    bl.ISale.Update(new BO.Sale
                    {
                        Id = id,
                        ProductId = productId,
                        amount_to_sale = amount,
                        cost_per_one = cost,
                        to_club = toClub,
                        start_date = startDate,
                        end_date = endDate
                    });
                    MessageBox.Show("Sale updated successfully!");
                    panelUpdate.Visible = false;
                    ClearUpdatePanel();
                }
                catch (FormatException)
                {
                    MessageBox.Show("ID, Amount and Cost must be valid numbers");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating sale: {ex.Message}");
                }
            }
        }

        private void DeleteConfirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(idDeleteTextBox.Text))
            {
                MessageBox.Show("Please enter sale ID");
            }
            else
            {
                try
                {
                    int id = int.Parse(idDeleteTextBox.Text);
                    bl.ISale.Delete(id);
                    MessageBox.Show($"Sale with ID {id} deleted successfully");
                    idDeleteTextBox.Text = "";
                    panelDelete.Visible = false;
                }
                catch (FormatException)
                {
                    MessageBox.Show("ID must be a valid number");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting sale: {ex.Message}");
                }
            }
        }

        private void filterTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var allSales = bl.ISale.GetAll().ToList();
                string filterText = filterTextBox.Text.ToLower();

                if (string.IsNullOrWhiteSpace(filterText))
                {
                    dataGridViewSales.DataSource = allSales;
                }
                else
                {
                    var filteredSales = allSales
                        .Where(s => s.ProductId.ToString().Contains(filterText))
                        .ToList();
                    dataGridViewSales.DataSource = filteredSales;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error filtering sales: {ex.Message}");
            }
        }

        private void closeShowAll_Click(object sender, EventArgs e)
        {
            panelShowAll.Visible = false;
        }

        private void filterByClub_Click(object sender, EventArgs e)
        {
            try
            {
                var allSales = bl.ISale.GetAll().ToList();
                var filteredSales = allSales
                    .Where(s => s.to_club)
                    .ToList();
                dataGridViewSales.DataSource = filteredSales;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error filtering sales: {ex.Message}");
            }
        }

        private void filterByProduct_Click(object sender, EventArgs e)
        {
            try
            {
                if (productFilterComboBox.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a product");
                    return;
                }

                int selectedProductId = (int)productFilterComboBox.SelectedValue;
                var allSales = bl.ISale.GetAll().ToList();
                var filteredSales = allSales
                    .Where(s => s.ProductId == selectedProductId)
                    .ToList();
                dataGridViewSales.DataSource = filteredSales;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error filtering sales: {ex.Message}");
            }
        }
    }
}
