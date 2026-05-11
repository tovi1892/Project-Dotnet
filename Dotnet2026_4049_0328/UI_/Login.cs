namespace UI_
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Manager form2 = new Manager();
            form2.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cashier form3 = new Cashier();
            form3.ShowDialog();
        }
    }
}
