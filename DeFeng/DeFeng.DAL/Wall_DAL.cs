using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.Common;

namespace DeFeng.DAL
{
    public class Wall_DAL
    {
        string dbConn = CommonClass.GetSysConfig("DeFengDBConStr");
        public List<Wall> LoadWall()
        {
            List<Wall> list = new List<Wall>();
            try
            {
                var sql = "SELECT [ID],[item] FROM Wall";
                var result = SqlHelper.ExecuteReader(dbConn, System.Data.CommandType.Text, sql);
                while (result.Read())
                {
                    var obj = new Wall();
                    obj.ID = Convert.ToInt32(result["ID"]);
                    obj.Item = Convert.ToString(result["item"]);
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
