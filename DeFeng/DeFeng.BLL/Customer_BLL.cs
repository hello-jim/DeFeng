using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.Model.Global;
using DeFeng.DAL;
using DeFeng.Common;
namespace DeFeng.BLL
{
    public class Customer_BLL
    {
        private static int customerMaxCount = Convert.ToInt32(CommonClass.GetSysConfig("customerMaxCount"));
        Customer_DAL dal = new Customer_DAL();
        public List<Customer> Search(Customer customer)
        {
            List<Customer> customerList = new List<Customer>();
            try
            {
                customerList = dal.Search(customer);
                customerList[0].TotalCustomerCount = customerList[0].TotalCustomerCount + ((customer.PageIndex - 1) * customerMaxCount);
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.Msg = ex.StackTrace;
                log.Type = LogType.Error;
                GlobalQueue.LogGlobalQueue.Enqueue(log);
            }
            return customerList;
        }

        public int AddCutomer(Customer customer)
        {
            var result = 0;
            try
            {
                result= dal.AddCutomer(customer);
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public int UpdateCustomer(Customer customer)
        {
            var result = 0;
            try
            {
                result = dal.UpdateCustomer(customer);
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public bool DeleteCustomer(List<int> idArr)
        {
            Customer_DAL dal = new Customer_DAL();
            var result = false;
            try
            {
                result = dal.DeleteCustomer(idArr);
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }
    }
}
