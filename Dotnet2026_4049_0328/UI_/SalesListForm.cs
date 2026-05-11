using System;
using System.Linq;
using System.Windows.Forms;
using BlApi;

namespace UI_
{
    public partial class SalesListForm : Form
    {
        public SalesListForm()
        {
            InitializeComponent();
        }

        public void SetSales(System.Collections.Generic.IEnumerable<BO.SaleInProduct> sales)
        {
           
            dgvSales.DataSource = null;
            dgvSales.DataSource = sales;
            // hide SaleId column (kept for reference)
            if (dgvSales.Columns.Contains("SaleId"))
                dgvSales.Columns["SaleId"].Visible = false;
        }
    }
}
