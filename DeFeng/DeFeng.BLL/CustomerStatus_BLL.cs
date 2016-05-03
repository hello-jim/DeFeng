using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.DAL;

namespace DeFeng.BLL
{
    public class CustomerStatus_BLL
    {
        CustomerStatus_DAL dal = new CustomerStatus_DAL();
        public List<CustomerStatus> LoadCustomerStatus()
        {
            List<CustomerStatus> list = new List<CustomerStatus>();
            try
            {
                list = dal.LoadCustomerStatus();
            }
            catch (Exception ex)
            {

            }
            return list;
        }
    }
}
