using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WaterSalesAutomation.UI;

namespace WaterSalesAutomation.BLL
{
    class Class1
    {
        public static int AdminID { get; set; }
        public static string AdminName { get; set; }
        public static int getcustomerid { get; set; }
        public static bool updateoradd { get; set; }


        public static bool control(Form form)
        {
            bool m = true;
            foreach (Control item in form.Controls)
            {
                if (item is TextBox)
                {
                    if (item.Text == "")
                    {
                        m = false;
                        break;
                    }
                }
            }
            return m;
        }
    }
    public enum OrderStatus
    {
        beklemede,
        yolda,
        teslim
    }
}
