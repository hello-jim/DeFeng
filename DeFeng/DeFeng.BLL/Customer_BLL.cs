using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.Model.Global;
using DeFeng.DAL;
namespace DeFeng.BLL
{
    public class Customer_BLL
    {
        Customer_DAL dal = new Customer_DAL();
        public List<Customer> Search(Customer customer)
        {
            List<Customer> customerList = new List<Customer>();
            try
            {
                customerList = dal.Search(customer);
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

        public List<Customer> CustomerDistributionCustomer(Customer customer)
        {
            List<Customer> customerList = new List<Customer>();
            try
            {
                customerList = dal.Search(customer);
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
    }
}
