using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.Common;

namespace DeFeng.DAL
{
    public class HouseDocumentType_DAL
    {
        string dbConn = CommonClass.GetSysConfig("DeFengDBConStr");
        public List<HouseDocumentType> LoadHouseDocumentType()
        {
            List<HouseDocumentType> list = new List<HouseDocumentType>();
            try
            {
                var sql = "SELECT [ID],[typeName] FROM HouseDocumentType";
                var result = SqlHelper.ExecuteReader(dbConn, System.Data.CommandType.Text, sql);
                while (result.Read())
                {
                    var obj = new HouseDocumentType();
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
