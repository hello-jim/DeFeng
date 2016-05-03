using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.DAL;

namespace DeFeng.BLL
{
    public class CustomerType_BLL
    {
        CustomerType_DAL dal = new CustomerType_DAL();
        public List<CustomerType> LoadCustomerType()
        {
            List<CustomerType> list = new List<CustomerType>();
            try
            {
                list = dal.LoadCustomerType();
            }
            catch (Exception ex)
            {

            }
            return list;
        }
    }
}
