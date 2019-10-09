using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterSalesAutomation.Model;

namespace WaterSalesAutomation.DAL
{
    class HelperSales
    {
        public static List<SalesModel> GetSalesModels()
        {
            using (WaterSalesDBEntities context = new WaterSalesDBEntities())
            {
                var list = context.Sales.ToList();
                List<SalesModel> sml = new List<SalesModel>();
                foreach (var item in list)
                {
                    SalesModel model = new SalesModel();
                    model.SalesID = item.SalesID;
                    model.SalesStatus = item.SalesStatus;
                    model.SalesAmount = item.SalesAmount;
                    model.Date = item.Date;
                    model.Admin.Username = item.Admin.Username;
                    model.Customer.customerID = item.Customer.customerID;
                    model.Customer.customerName = item.Customer.customerName;
                    model.Customer.customerAddress = item.Customer.customerAddress;
                    model.Customer.customerSurname = item.Customer.customerSurname;
                    sml.Add(model);
                }
                return sml;
            }
        }
        public static List<SalesModel> GetSalesModels(List<Sales> sales)
        {
            using (WaterSalesDBEntities context = new WaterSalesDBEntities())
            {
                List<SalesModel> sml = new List<SalesModel>();
                foreach (var item in sales)
                {
                    SalesModel model = new SalesModel();
                    model.SalesID = item.SalesID;
                    model.SalesStatus = item.SalesStatus;
                    model.SalesAmount = item.SalesAmount;
                    model.Date = item.Date;
                    model.Admin = item.Admin;
                    model.Admin.Username = item.Admin.Username;
                    model.Customer.customerID = item.Customer.customerID;
                    model.Customer.customerName = item.Customer.customerName;
                    model.Customer.customerAddress = item.Customer.customerAddress;
                    model.Customer.customerSurname = item.Customer.customerSurname;
                    sml.Add(model);
                }
                return sml;
            }
        }
        public static bool CUD(EntityState state, Sales sales)
        {
            using (WaterSalesDBEntities context = new WaterSalesDBEntities())
            {
                context.Entry(sales).State = state;
                if (context.SaveChanges() > 0)
                {
                    return true;
                }
                else
                    return false;
            }
        }
        public static Sales GetSales(int salesid)
        {
            using (WaterSalesDBEntities context = new WaterSalesDBEntities())
            {
                return context.Sales.Where(x => x.SalesID == salesid).FirstOrDefault();
            }
        }
        public static List<SalesModel> GetSalesByDate(DateTime date)
        {
            List<Sales> saless = new List<Sales>();
            using (WaterSalesDBEntities context = new WaterSalesDBEntities())
            {
                saless = context.Sales.Where(x => x.Date == date || x.Date > date).ToList();
                return GetSalesModels(saless);
            }

        }
        public static bool DeleteAllSales()
        {
            using (WaterSalesDBEntities context = new WaterSalesDBEntities())
            {
                var list = context.Sales.ToList();
                context.Sales.RemoveRange(list);
                if (context.SaveChanges() > 0)
                {
                    return true;
                }
                else
                    return false;
            }
        }
    }
}
