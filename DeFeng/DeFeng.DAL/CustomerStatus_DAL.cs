using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.Common;

namespace DeFeng.DAL
{
    public class CustomerStatus_DAL
    {
        string dbConn = CommonClass.GetSysConfig("DeFengDBConStr");
        public List<CustomerStatus> LoadCustomerStatus()
        {
            List<CustomerStatus> list = new List<CustomerStatus>();
            try
            {
                var sql = "SELECT [ID],[statusName] FROM CustomerStatus";
                var result = SqlHelper.ExecuteReader(dbConn, System.Data.CommandType.Text, sql);
                while (result.Read())
                {
                    var obj = new CustomerStatus();
                    obj.ID = Convert.ToInt32(result["ID"]);
                    obj.StatusName = Convert.ToString(result["statusName"]);
                    list.Add(obj);
                }
            }
            catch (Exception ex)
            {

            }
            return list;
        }
    }
}
