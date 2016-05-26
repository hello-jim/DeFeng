using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.Common;

namespace DeFeng.DAL
{
    public class EntrustOverDate_DAL
    {
        string sqlConn = CommonClass.GetSysConfig("DeFengDBConStr");
        public List<EntrustOverDate> LoadEntrustOverDate()
        {
            var list = new List<EntrustOverDate>();
            try
            {
                var sql = "SELECT [ID],[name],[createStaff],[createDate],[lastUpdateStaff],[lastUpdateDate] FROM EntrustOverDate";
                var read = SqlHelper.ExecuteReader(sqlConn, System.Data.CommandType.Text, sql);
                while (read.Read())
                {
                    var obj = new EntrustOverDate();
                    obj.ID = Convert.ToInt32(read["ID"]);
                    obj.Name = Convert.IsDBNull(read["name"]) ? "" : Convert.ToString(read["name"]);
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
