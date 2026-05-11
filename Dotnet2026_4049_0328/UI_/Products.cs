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
    public partial class Products : Form
    {
        IBl bl = Factory.Get();

        public Products()
        {
            InitializeComponent();
            panel1.Visible = false;
            panelID.Visible = false;
            panelUpdate.Visible = false;
            panelDelete.Visible = false;
            panelShowAll.Visible = false;
            LoadCategories();
        }

        private void LoadCategories()
        {
            categoryComboBox.DataSource = Enum.GetValues(typeof(ElectricalApplianceCategory));
            categoryComboBox.SelectedIndex = 0;

            categoryComboBoxUpdate.DataSource = Enum.GetValues(typeof(ElectricalApplianceCategory));
            categoryComboBoxUpdate.SelectedIndex = 0;

            categoryFilterComboBox.DataSource = Enum.GetValues(typeof(ElectricalApplianceCategory));
            categoryFilterComboBox.SelectedIndex = 0;
        }

        private void Products_Load(object sender, EventArgs e)
        {

        }

        private void createProduct_Click(object sender, EventArgs e)
        {
            ClearCreatePanel();
            panel1.Visible = true;
        }

        private void confirmCreate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nameTextBox.Text) || string.IsNullOrEmpty(priceTextBox.Text) || string.IsNullOrEmpty(stockTextBox.Text))
            {
                MessageBox.Show("Please fill in all fields");
            }
            else
            {
                try
                {
                    int price = int.Parse(priceTextBox.Text);
                    int stock = int.Parse(stockTextBox.Text);

                    if (price < 0 || stock < 0)
                    {
                        MessageBox.Show("Price and Stock must be non-negative");
                        return;
                    }

                    bl.IProduct.Create(new BO.Product
                    {
                        Name = nameTextBox.Text,
                        category = (ElectricalApplianceCategory)categoryComboBox.SelectedItem,
                        Price = price,
                        Stock = stock
                    });
                    MessageBox.Show("New product created successfully!");
                    panel1.Visible = false;
                    ClearCreatePanel();
                }
                catch (FormatException)
                {
                    MessageBox.Show("Price and Stock must be valid numbers");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error creating product: {ex.Message}");
                }
            }
        }

        private void showProduct_Click(object sender, EventArgs e)
        {
            idTextBox.Text = "";
            panelID.Visible = true;
            idTextBox.Focus();
        }

        private void confirmAction_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(idTextBox.Text))
            {
                MessageBox.Show("Please enter product ID");
            }
            else
            {
                try
                {
                    int id = int.Parse(idTextBox.Text);
                    var product = bl.IProduct.Get(id);

                    if (product == null)
                    {
                        MessageBox.Show($"Product with ID {id} not found");
                        return;
                    }

                    MessageBox.Show($"Product Details:\n\nName: {product.Name}\nCategory: {product.category}\nPrice: {product.Price}\nStock: {product.Stock}");
                    panelID.Visible = false;
                }
                catch (FormatException)
                {
                    MessageBox.Show("ID must be a valid number");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error retrieving product: {ex.Message}");
                }
            }
        }

        private void updateProduct_Click(object sender, EventArgs e)
        {
            ClearUpdatePanel();
            panelUpdate.Visible = true;
        }

        private void deleteProduct_Click(object sender, EventArgs e)
        {
            panelDelete.Visible = true;
        }

        private void showAllProducts_Click(object sender, EventArgs e)
        {
            try
            {
                var allProducts = bl.IProduct.GetAll().ToList();

                if (!allProducts.Any())
                {
                    MessageBox.Show("No products found");
                    return;
                }

                dataGridViewProducts.DataSource = null;
                dataGridViewProducts.DataSource = allProducts;

                panelShowAll.Visible = true;
                filterTextBox.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving products: {ex.Message}");
            }
        }

        private void ClearCreatePanel()
        {
            nameTextBox.Text = "";
            priceTextBox.Text = "";
            stockTextBox.Text = "";
            categoryComboBox.SelectedIndex = 0;
            nameTextBox.Focus();
        }

        private void ClearUpdatePanel()
        {
            upIdTextBox.Text = "";
            upNameTextBox.Text = "";
            upPriceTextBox.Text = "";
            upStockTextBox.Text = "";
            categoryComboBoxUpdate.SelectedIndex = 0;
            upIdTextBox.Focus();
        }

        private void UpdateConfirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(upIdTextBox.Text) || string.IsNullOrWhiteSpace(upNameTextBox.Text) ||
       string.IsNullOrEmpty(upPriceTextBox.Text) || string.IsNullOrEmpty(upStockTextBox.Text))
            {
                MessageBox.Show("Please fill in all fields");
            }
            else
            {
                try
                {
                    int id = int.Parse(upIdTextBox.Text);
                    int price = int.Parse(upPriceTextBox.Text);
                    int stock = int.Parse(upStockTextBox.Text);

                    if (price < 0 || stock < 0)
                    {
                        MessageBox.Show("Price and Stock must be non-negative");
                        return;
                    }

                    bl.IProduct.Update(new BO.Product
                    {
                        Id = id,
                        Name = upNameTextBox.Text,
                        category = (ElectricalApplianceCategory)categoryComboBoxUpdate.SelectedItem,
                        Price = price,
                        Stock = stock
                    });
                    MessageBox.Show("Product updated successfully!");
                    panelUpdate.Visible = false;
                    ClearUpdatePanel();
                }
                catch (FormatException)
                {
                    MessageBox.Show("ID, Price and Stock must be valid numbers");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating product: {ex.Message}");
                }
            }
        }

        private void DeleteConfirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(idDeleteTextBox.Text))
            {
                MessageBox.Show("Please enter product ID");
            }
            else
            {
                try
                {
                    int id = int.Parse(idDeleteTextBox.Text);
                    bl.IProduct.Delete(id);
                    MessageBox.Show($"Product with ID {id} deleted successfully");
                    idDeleteTextBox.Text = "";
                    panelDelete.Visible = false;
                }
                catch (FormatException)
                {
                    MessageBox.Show("ID must be a valid number");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting product: {ex.Message}");
                }
            }
        }

        private void filterTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var allProducts = bl.IProduct.GetAll().ToList();
                string filterText = filterTextBox.Text.ToLower();

                if (string.IsNullOrWhiteSpace(filterText))
                {
                    dataGridViewProducts.DataSource = allProducts;
                }
                else
                {
                    var filteredProducts = allProducts
                      .Where(p => p.Name.ToLower().Contains(filterText))
               .ToList();
                    dataGridViewProducts.DataSource = filteredProducts;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error filtering products: {ex.Message}");
            }
        }

        private void closeShowAll_Click(object sender, EventArgs e)
        {
            panelShowAll.Visible = false;
        }

        private void filterByCategory_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedCategory = categoryFilterComboBox.SelectedItem;
                if (selectedCategory is ElectricalApplianceCategory category)
                {
                    Func<Product, bool> filter = p => p.category == category;
                    var filteredProducts = bl.IProduct.GetAll(filter).ToList();
                    dataGridViewProducts.DataSource = filteredProducts;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error filtering products: {ex.Message}");
            }
        }

        private void categoryFilterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
