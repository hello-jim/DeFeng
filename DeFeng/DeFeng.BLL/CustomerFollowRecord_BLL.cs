using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.DAL;

namespace DeFeng.BLL
{
    public class CustomerFollowRecord_BLL
    {
        CustomerFollowRecord_DAL dal = new CustomerFollowRecord_DAL();
        public List<CustomerFollowRecord> LoadHouseFollowRecord(int houseID)
        {
            List<CustomerFollowRecord> list = new List<CustomerFollowRecord>();
            try
            {
                list = dal.LoadCustomerFollowRecord(houseID);
            }
            catch (Exception ex)
            {

            }
            return list;
        }

        public bool AddCustomerFollowRecord(CustomerFollowRecord record)
        {
            var result = false;
            try
            {
                result = dal.AddCustomerFollowRecord(record);
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public bool DeleteCustomerFollowRecord(int id)
        {
            var result = false;
            try
            {
                result = dal.DeleteCustomerFollowRecord(id);
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public bool UpdateCustomerFollowRecord(CustomerFollowRecord record)
        {
            var result = false;
            try
            {
                result = dal.UpdateCustomerFollowRecord(record);
            }
            catch (Exception ex)
            {

            }
            return result;
        }
    }
}
