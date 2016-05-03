using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.DAL;
using DeFeng.Model;

namespace DeFeng.BLL
{
    public class CustomerTransactionType_BLL
    {
        CustomerTransactionType_DAL dal = new CustomerTransactionType_DAL();
        public List<CustomerTransactionType> LoadCustomerTransactionType()
        {
            List<CustomerTransactionType> list = new List<CustomerTransactionType>();
            try
            {
                list = dal.LoadCustomerTransactionType();
            }
            catch (Exception ex)
            {

            }
            return list;
        }
    }
}
