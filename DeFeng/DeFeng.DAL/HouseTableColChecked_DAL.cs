using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DeFeng.Model;
using DeFeng.Common;

namespace DeFeng.DAL
{
    public class HouseTableColChecked_DAL
    {
        string dbConn = CommonClass.GetSysConfig("DeFengDBConStr");
        public List<HouseTableColChecked> LoadHouseTableColChecked()
        {
            List<HouseTableColChecked> list = new List<HouseTableColChecked>();
            try
            {
                var sql = "SELECT [ID],[colName],[col],[checkedStatus] FROM HouseTableColChecked";
                var result = SqlHelper.ExecuteReader(dbConn, System.Data.CommandType.Text, sql);
                while (result.Read())
                {
                    var obj = new HouseTableColChecked();
                    obj.ID = Convert.ToInt32(result["ID"]);
                    obj.ColName = Convert.ToString(result["colName"]);
                    obj.Col = Convert.ToString(result["col"]);
                    obj.CheckedStatus = Convert.ToBoolean(result["checkedStatus"]);
                    list.Add(obj);
                }
            }
            catch (Exception ex)
            {

            }
            return list;
        }

        public int ChangeHouseTableColStatus(HouseTableColChecked col)
        {
            var result = 0;
            try
            {
                var sql = "UPDATE HouseTableColChecked SET checkedStatus=@status WHERE ID=@ID";
                var sqlPars = new List<SqlParameter>();
                sqlPars.Add(new SqlParameter("@status", col.CheckedStatus));
                sqlPars.Add(new SqlParameter("@ID", col.ID));
                result = SqlHelper.ExecuteNonQuery(dbConn, System.Data.CommandType.Text, sql, sqlPars.ToArray());
            }
            catch (Exception ex)
            {

            }
            return result;
        }
    }
}
