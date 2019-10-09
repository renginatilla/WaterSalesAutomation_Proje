using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WaterSalesAutomation.DAL;
using WaterSalesAutomation.BLL;

namespace WaterSalesAutomation.UI
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            bool cntrl=control();
            if (cntrl)
            {
                var admin = HelperAdmin.GetAdmin(textBox1.Text, textBox2.Text);
                if( admin != null)
                {
                    Class1.AdminID = admin.AdminID;
                    Class1.AdminName = admin.Username;
                    Form1 form = new Form1();
                    form.Show();
                    this.Hide();
                }
                else
                    MessageBox.Show("Hatalı giriş", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
                MessageBox.Show("Boş alanları doldurunuz...","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }
        public bool control()
        {
            bool m=true;
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    if (item.Text == "")
                    {
                        m= false;
                        break;
                    }                   
                }  
            }
            return m;
        }
    }
}
