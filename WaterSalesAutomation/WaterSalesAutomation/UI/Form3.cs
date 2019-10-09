using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WaterSalesAutomation.BLL;
using WaterSalesAutomation.DAL;
using WaterSalesAutomation.UI;

namespace WaterSalesAutomation
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            bool result = Class1.control(Form3.ActiveForm);
            if (result)
            {
                Sales sales = new Sales()
                {
                    SalesStatus = OrderStatus.beklemede.ToString(),
                    SalesAmount = Convert.ToInt32(textBox4.Text),
                    CustomerID = Class1.getcustomerid,
                    Date = DateTime.Now,
                    AdminID = Class1.AdminID
                };
                bool m = HelperSales.CUD(System.Data.Entity.EntityState.Added, sales);
                MessageBox.Show(m == true ? "Satış oluşturuldu, takipte kalın." : "Satış oluşturulamadı.");
                Form1 form1 = new Form1();
                form1.salesgridshow();
                this.Hide();
                form1.Show();
            }
            else
                MessageBox.Show("Boş alanları doldurunuz...", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }
    }
}
