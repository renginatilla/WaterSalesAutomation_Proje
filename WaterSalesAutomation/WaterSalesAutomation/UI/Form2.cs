using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WaterSalesAutomation.UI;
using WaterSalesAutomation.BLL;
using WaterSalesAutomation.DAL;

namespace WaterSalesAutomation
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            bool result = Class1.control(Form2.ActiveForm);
            if (Class1.updateoradd==true)
            {
                if (result)
                {
                    Customer customer = new Customer()
                    {
                        customerName = textBox1.Text,
                        customerSurname = textBox2.Text,
                        customerAddress = textBox3.Text,
                        customerPhone = maskedTextBox1.Text
                    };
                    bool success = HelperCustomer.CUD(System.Data.Entity.EntityState.Added, customer);
                    MessageBox.Show(success == true ? "Müşteri eklendi" : "Müşteri eklenemedi", "Sonuç", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Form1 form1 = new Form1();
                    this.Hide();
                    form1.customergridshow();
                    form1.Show();

                }
                else
                    MessageBox.Show("Boş alanları doldurunuz...", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (result)
                {
                    var custom = HelperCustomer.GetCustomer(Class1.getcustomerid);
                    custom.customerName = textBox1.Text;
                    custom.customerSurname = textBox2.Text;
                    custom.customerAddress = textBox3.Text;
                    custom.customerPhone = maskedTextBox1.Text;
                    bool success2 = HelperCustomer.CUD(System.Data.Entity.EntityState.Modified, custom);
                    MessageBox.Show(success2 == true ? "Müşteri güncellendi" : "Müşteri güncellenemedi", "Sonuç", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Form1 form1 = new Form1();
                    this.Hide();
                    form1.customergridshow();
                    form1.Show();                    
                }
                else
                    MessageBox.Show("Boş alanları doldurunuz...", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }


        }
    }
}
