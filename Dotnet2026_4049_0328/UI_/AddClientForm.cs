using System;
using System.Windows.Forms;
using BL.BlApi;
using BO;

namespace UI_
{
    public partial class AddClientForm : Form
    {
        private readonly IBl _bl;
        public BO.Customer? CreatedClient { get; private set; }

        public AddClientForm(IBl bl, int? suggestedId = null)
        {
            _bl = bl;
            InitializeComponent();
            if (suggestedId != null)
                textBoxId.Text = suggestedId.Value.ToString();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            try
            {
                var id = int.Parse(textBoxId.Text);
                var name = textBoxName.Text.Trim();
                var phone = textBoxPhone.Text.Trim();
                var address = textBoxAddress.Text.Trim();
                var isClub = checkBoxClub.Checked;

                var client = new BO.Customer { Id = id, Name = name, PhoneNumber = phone, Address = address, IsClubMember = isClub };
                // create via BL
                _bl.Customer.Create(client);
                CreatedClient = _bl.Customer.Read(id);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Id must be a number");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to create client: {ex.Message}");
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
