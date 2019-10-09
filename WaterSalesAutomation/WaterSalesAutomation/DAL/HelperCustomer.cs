using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterSalesAutomation.Model;

namespace WaterSalesAutomation.DAL
{
    class HelperCustomer
    {
        public static bool CUD(EntityState state, Customer customer)
        {
            using (WaterSalesDBEntities context=new WaterSalesDBEntities())
            {
                context.Entry(customer).State = state;
                if (context.SaveChanges() > 0)
                    return true;
                else
                    return false;
            }
        }
        public static List<Customer> GetCustomers()
        {
            using (WaterSalesDBEntities context=new WaterSalesDBEntities())
            {
                return context.Customer.ToList();
            }
        }
        public static Customer GetCustomer(int customerid)
        {
            using (WaterSalesDBEntities context=new WaterSalesDBEntities())
            {
                return context.Customer.Where(x => x.customerID == customerid).FirstOrDefault();
            }
        }
        public static List<Customer> GetCustomersByName(string name, string surname)
        {
            using (WaterSalesDBEntities context=new WaterSalesDBEntities())
            {
                return context.Customer.Where(x => x.customerName == name && x.customerSurname == surname).ToList();
            }
        }
        
    }
}
