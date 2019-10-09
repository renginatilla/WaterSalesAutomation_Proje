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
using WaterSalesAutomation.UI;

namespace WaterSalesAutomation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            this.Hide();
            Class1.updateoradd = true;
            form2.Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            form2.textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            form2.maskedTextBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            form2.textBox3.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            Class1.updateoradd = false;
            this.Hide();
            form2.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            customergridshow();
            salesgridshow();
            dataGridView2.MultiSelect = true;
        }
        public void customergridshow()
        {
            dataGridView1.Rows.Clear();
            var customerlist = HelperCustomer.GetCustomers();
            foreach (var item in customerlist)
            {
                dataGridView1.Rows.Add(item.customerID, item.customerName, item.customerSurname, item.customerPhone, item.customerAddress);
            }
        }
        public void salesgridshow()
        {
            dataGridView2.Rows.Clear();
            var saleslist = HelperSales.GetSalesModels();
            foreach (var item in saleslist)
            {
                dataGridView2.Rows.Add(item.SalesID, item.SalesStatus, item.Customer.customerName + " " + item.Customer.customerSurname, item.Customer.customerAddress, item.SalesAmount, item.Date);
            }
        }

        private void DataGridView1_Click(object sender, EventArgs e)
        {
            Class1.getcustomerid = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
           
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            var customer = HelperCustomer.GetCustomer(Class1.getcustomerid);
            bool result = HelperCustomer.CUD(System.Data.Entity.EntityState.Deleted,customer);
            MessageBox.Show(result == true ? "Müşteri silindi." : "Müşteri silinemedi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            customergridshow();
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            int SelectedCustomer = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            if  (SelectedCustomer == 0)
            {
                MessageBox.Show("Müşteri seçimini yapın!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {                
                Form3 form3 = new Form3();
                form3.textBox3.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                form3.textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                form3.textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                this.Hide();
                form3.Show();
            }
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            int SelectedSales = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value);
            var sales = HelperSales.GetSales(SelectedSales);
            sales.SalesStatus = OrderStatus.yolda.ToString();
            bool result = HelperSales.CUD(System.Data.Entity.EntityState.Modified, sales);
            MessageBox.Show(result == true ? "Satış güncellendi." : "Satış güncellenmedi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            salesgridshow();
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            int SelectedSales = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value);
            var sales = HelperSales.GetSales(SelectedSales);
            sales.SalesStatus = OrderStatus.teslim.ToString();
            bool result = HelperSales.CUD(System.Data.Entity.EntityState.Modified, sales);
            MessageBox.Show(result == true ? "Satış güncellendi." : "Satış güncellenmedi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            salesgridshow();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            var saleslist = HelperSales.GetSalesByDate(DateTime.Now.Date);
            foreach (var item in saleslist)
            {
                dataGridView2.Rows.Add(item.SalesID, item.SalesStatus, item.Customer.customerName + " " + item.Customer.customerSurname, item.Customer.customerAddress, item.SalesAmount, item.Date);
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            int selectedsales = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value);
            var sales = HelperSales.GetSales(selectedsales);
            bool result = HelperSales.CUD(System.Data.Entity.EntityState.Deleted, sales);
            MessageBox.Show(result == true ? "Seçili satış silindi." : "Seçili satış silinemedi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            salesgridshow();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var list = HelperCustomer.GetCustomersByName(textBox1.Text, textBox2.Text);
            foreach (var item in list)
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Rows.Add(item.customerID, item.customerName, item.customerSurname, item.customerPhone, item.customerAddress);
            }

        }

        private void Button6_Click(object sender, EventArgs e)
        {
            bool result = HelperSales.DeleteAllSales();
            MessageBox.Show(result == true ? "Tüm satışlar silindi." : "Satışlar silinemedi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            salesgridshow();
        }
    }
}
