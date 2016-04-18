using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.Common;

namespace DeFeng.DAL
{
    public class PropertyOwn_DAL
    {
        string dbConn = CommonClass.GetSysConfig("DeFengDBConStr");
        public List<PropertyOwn> LoadPropertyOwn()
        {
            List<PropertyOwn> list = new List<PropertyOwn>();
            try
            {
                var sql = "SELECT [ID],[propertyName] FROM PropertyOwn";
                var result = SqlHelper.ExecuteReader(dbConn, System.Data.CommandType.Text, sql);
                while (result.Read())
                {
                    var obj = new PropertyOwn();
                    obj.ID = Convert.ToInt32(result["ID"]);
                    obj.PropertyName = Convert.ToString(result["propertyName"]);
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
