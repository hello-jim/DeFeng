using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.Common;

namespace DeFeng.DAL
{
    public class Grade_DAL
    {
        string dbConn = CommonClass.GetSysConfig("DeFengDBConStr");
        public List<Grade> LoadGrade()
        {
            List<Grade> list = new List<Grade>();
            try
            {
                var sql = "SELECT [ID],[gradeName] FROM Grade";
                var result = SqlHelper.ExecuteReader(dbConn, System.Data.CommandType.Text, sql);
                while (result.Read())
                {
                    var obj = new Grade();
                    obj.ID = Convert.ToInt32(result["ID"]);
                    obj.GradeName = Convert.ToString(result["gradeName"]);
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
