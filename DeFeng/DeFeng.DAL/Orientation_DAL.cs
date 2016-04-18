using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.Common;

namespace DeFeng.DAL
{
   public class Orientation_DAL
    {
        string dbConn = CommonClass.GetSysConfig("DeFengDBConStr");
        public List<Orientation> LoadOrientation()
        {
            List<Orientation> list = new List<Orientation>();
            try
            {
                var sql = "SELECT [ID],[orientationName] FROM Orientation";
                var result = SqlHelper.ExecuteReader(dbConn, System.Data.CommandType.Text, sql);
                while (result.Read())
                {
                    var obj = new Orientation();
                    obj.ID = Convert.ToInt32(result["ID"]);
                    obj.OrientationName = Convert.ToString(result["orientationName"]);
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
