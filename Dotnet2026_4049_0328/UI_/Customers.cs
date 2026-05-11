using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using BlApi;

namespace UI_
{
    public partial class Customers : Form
    {
        IBl bl = Factory.Get();

        public Customers()
        {
            InitializeComponent();
            panel1.Visible = false;
            panelID.Visible = false;
            panelUpdate.Visible = false;
            panelDelete.Visible = false;
            panelShowAll.Visible = false;
        }

        private void Customers_Load(object sender, EventArgs e)
        {

        }

        private void createCustomer_Click(object sender, EventArgs e)
        {
            ClearCreatePanel();
            panel1.Visible = true;

        }


        private void confirmCreate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameTextBox.Text) || string.IsNullOrWhiteSpace(Phone.Text) || string.IsNullOrEmpty(Adress.Text) || string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Please fill in all fields");
            }
            else
            {
                try
                {
                    int id = int.Parse(textBox1.Text);

                    bl.IClient.Create(new BO.Client
                    {
                        Id = id,
                        Name = NameTextBox.Text,
                        Phone = Phone.Text,
                        Address = Adress.Text,
                        IsClubMember = checkBox1.Checked
                    });
                    MessageBox.Show("New client created successfully!");
                    panel1.Visible = false;
                    ClearCreatePanel();
                }
                catch (FormatException)
                {
                    MessageBox.Show("ID must be a valid number");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error creating client: {ex.Message}");
                }
            }
        }

        private void showCustomer_Click(object sender, EventArgs e)
        {
            ID.Text = "";
            panelID.Visible = true;

            ID.Focus();
        }

        //show client confirmation button
        private void confirmAction_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ID.Text))
            {
                MessageBox.Show("Please enter client ID");
            }
            else
            {
                try
                {
                    int id = int.Parse(ID.Text);
                    var client = bl.IClient.Get(id);

                    if (client == null)
                    {
                        MessageBox.Show($"Client with ID {id} not found");
                        return;
                    }

                    MessageBox.Show($"Client Details:\n\nName: {client.Name}\nPhone: {client.Phone}\nAddress: {client.Address}\nClub Member: {(client.IsClubMember ? "Yes" : "No")}");
                    panelID.Visible = false;
                }
                catch (FormatException)
                {
                    MessageBox.Show("ID must be a valid number");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error retrieving client: {ex.Message}");
                }
            }
        }

        private void updateCustomer_Click(object sender, EventArgs e)
        {
            ClearUpdatePanel();
            panelUpdate.Visible = true;
        }

        private void deleteCustomer_Click(object sender, EventArgs e)
        {
            panelDelete.Visible = true;
        }

        private void showAllCustomers_Click(object sender, EventArgs e)
        {
            try
            {
                var allClients = bl.IClient.GetAll().ToList();

                if (!allClients.Any())
                {
                    MessageBox.Show("No clients found");
                    return;
                }

                dataGridViewCustomers.DataSource = null;
                dataGridViewCustomers.DataSource = allClients;

                panelShowAll.Visible = true;
                filterTextBox.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving clients: {ex.Message}");
            }
        }

        private void ClearCreatePanel()
        {
            NameTextBox.Text = "";
            Phone.Text = "";
            Adress.Text = "";
            textBox1.Text = "";
            checkBox1.Checked = false;
            NameTextBox.Focus();
        }

        private void ClearUpdatePanel()
        {
            UpName.Text = "";
            UpPhone.Text = "";
            UpAdress.Text = "";
            UpID.Text = "";
            checkBox2.Checked = false;
            UpName.Focus();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void UpdateConfirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(UpName.Text) || string.IsNullOrWhiteSpace(UpPhone.Text) || string.IsNullOrEmpty(UpAdress.Text) || string.IsNullOrEmpty(UpID.Text))
            {
                MessageBox.Show("Please fill in all fields");
            }
            else
            {
                try
                {
                    int id = int.Parse(UpID.Text);

                    bl.IClient.Update(new BO.Client
                    {
                        Id = id,
                        Name = UpName.Text,
                        Phone = UpPhone.Text,
                        Address = UpAdress.Text,
                        IsClubMember = checkBox2.Checked
                    });
                    MessageBox.Show("Client updated successfully!");
                    panelUpdate.Visible = false;
                    ClearUpdatePanel();
                }
                catch (FormatException)
                {
                    MessageBox.Show("ID must be a valid number");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating client: {ex.Message}");
                }

            }
        }

        private void panelUpdate_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DeleteConfirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(IDdelete.Text))
            {
                MessageBox.Show("Please enter client ID");
            }
            else
            {
                try
                {
                    int id = int.Parse(IDdelete.Text);
                    bl.IClient.Delete(id);
                    MessageBox.Show($"Client with ID {id} deleted successfully");
                    IDdelete.Text = "";
                    panelDelete.Visible = false;
                }
                catch (FormatException)
                {
                    MessageBox.Show("ID must be a valid number");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting client: {ex.Message}");
                }
            }
        }

        private void filterTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var allClients = bl.IClient.GetAll().ToList();
                string filterText = filterTextBox.Text.ToLower();

                if (string.IsNullOrWhiteSpace(filterText))
                {
                    dataGridViewCustomers.DataSource = allClients;
                }
                else
                {
                    var filteredClients = allClients
                        .Where(c => c.Name.ToLower().Contains(filterText))
                        .ToList();
                    dataGridViewCustomers.DataSource = filteredClients;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error filtering clients: {ex.Message}");
            }
        }

        private void closeShowAll_Click(object sender, EventArgs e)
        {
            panelShowAll.Visible = false;
        }

        private void panelShowAll_Paint(object sender, PaintEventArgs e)
        {

        }

        private void filterByClub_Click(object sender, EventArgs e)
        {
            try
            {
                Func<BO.Client, bool> clubMemberFilter = c => c.IsClubMember;
                var allClients = bl.IClient.GetAll(clubMemberFilter).ToList();
                var filteredClients = allClients
                    .Where(c => c.IsClubMember)
                    .ToList();
                dataGridViewCustomers.DataSource = filteredClients;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error filtering clients: {ex.Message}");
            }
        }
    }
}
