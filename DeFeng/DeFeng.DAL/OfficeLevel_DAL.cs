using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.Common;

namespace DeFeng.DAL
{
    public class OfficeLevel_DAL
    {
        string dbConn = CommonClass.GetSysConfig("DeFengDBConStr");
        public List<OfficeLevel> LoadOfficeLevel()
        {
            List<OfficeLevel> list = new List<OfficeLevel>();
            try
            {
                var sql = "SELECT [ID],[levelName] FROM OfficeLevel";
                var result = SqlHelper.ExecuteReader(dbConn, System.Data.CommandType.Text, sql);
                while (result.Read())
                {
                    var obj = new OfficeLevel();
                    obj.ID = Convert.ToInt32(result["ID"]);
                    obj.LevelName = Convert.ToString(result["levelName"]);
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
