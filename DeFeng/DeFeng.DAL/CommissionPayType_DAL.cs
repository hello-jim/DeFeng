using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.Common;

namespace DeFeng.DAL
{
    public class CommissionPayType_DAL
    {
        string dbConn = CommonClass.GetSysConfig("DeFengDBConStr");
        public List<CommissionPayType> LoadCommissionPayType()
        {
            List<CommissionPayType> list = new List<CommissionPayType>();
            try
            {
                var sql = "SELECT [ID],[typeName] FROM CommissionPayType";
                var result = SqlHelper.ExecuteReader(dbConn, System.Data.CommandType.Text, sql);
                while (result.Read())
                {
                    var obj = new CommissionPayType();
                    obj.ID = Convert.ToInt32(result["ID"]);
                    obj.TypeName = Convert.ToString(result["typeName"]);
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
