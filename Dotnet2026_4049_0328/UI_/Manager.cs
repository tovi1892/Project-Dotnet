namespace UI_
{
    public partial class Manager : Form
    {
        public Manager()
        {
            InitializeComponent();
            ThemeHelper.Apply(this); // זה יחיל את העיצוב על הטופס הנוכחי וכל מה שבתוכו
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Customers customers = new Customers();
            customers.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Products products = new Products();
            products.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Sales sales = new Sales();
            sales.ShowDialog();
        }

        private void Manager_Load(object sender, EventArgs e)
        {

        }
    }
}
