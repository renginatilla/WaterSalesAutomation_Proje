using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterSalesAutomation.Model
{
    class SalesModel
    {
        public int SalesID { get; set; }
        public string SalesStatus { get; set; }
        public Nullable<double> SalesAmount { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<int> AdminID { get; set; }

        public Admin Admin = new Admin();
        public Customer Customer = new Customer();
    }
}
