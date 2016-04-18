using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.Common;

namespace DeFeng.DAL
{
    public class HousingLetter_DAL
    {
        string dbConn = CommonClass.GetSysConfig("DeFengDBConStr");
        public List<HousingLetter> LoadHousingLetter()
        {
            List<HousingLetter> list = new List<HousingLetter>();
            try
            {
                var sql = "SELECT [ID],[letterName] FROM HousingLetter";
                var result = SqlHelper.ExecuteReader(dbConn, System.Data.CommandType.Text, sql);
                while (result.Read())
                {
                    var obj = new HousingLetter();
                    obj.ID = Convert.ToInt32(result["ID"]);
                    obj.LetterName = Convert.ToString(result["letterName"]);
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
