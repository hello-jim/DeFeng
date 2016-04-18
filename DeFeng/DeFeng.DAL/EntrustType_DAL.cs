using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.Common;

namespace DeFeng.DAL
{
    public class EntrustType_DAL
    {
        string dbConn = CommonClass.GetSysConfig("DeFengDBConStr");
        public List<EntrustType> LoadEntrustType()
        {
            List<EntrustType> list = new List<EntrustType>();
            try
            {
                var sql = "SELECT [ID],[typeName] FROM EntrustType";
                var result = SqlHelper.ExecuteReader(dbConn, System.Data.CommandType.Text, sql);
                while (result.Read())
                {
                    var obj = new EntrustType();
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
