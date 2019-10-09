using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterSalesAutomation.DAL
{
    class HelperAdmin
    {
        public static Admin GetAdmin(string username, string password)
        {
            using (WaterSalesDBEntities context=new WaterSalesDBEntities())
            {
                return context.Admin.Where(x => x.Username == username && x.Password == password).FirstOrDefault();
            }
        }
    }
}
