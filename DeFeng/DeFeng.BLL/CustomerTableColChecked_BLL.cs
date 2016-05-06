using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.DAL;

namespace DeFeng.BLL
{
    public class CustomerTableColChecked_BLL
    {
        CustomerTableColChecked_DAL dal = new CustomerTableColChecked_DAL();
        public List<CustomerTableColChecked> LoadCustomerTableColChecked()
        {
            List<CustomerTableColChecked> list = new List<CustomerTableColChecked>();
            try
            {
                list = dal.LoadCustomerTableColChecked();
            }
            catch (Exception ex)
            {

            }
            return list;
        }

        public int ChangeCustomerTableColStatus(CustomerTableColChecked col)
        {
            var result = 0;
            try
            {
                result = dal.ChangeCustomerTableColStatus(col);
            }
            catch (Exception ex)
            {

            }
            return result;
        }
    }
}
