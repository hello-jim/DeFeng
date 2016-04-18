using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.Common;

namespace DeFeng.DAL
{
    public class TransactionType_DAL
    {
        string dbConn = CommonClass.GetSysConfig("DeFengDBConStr");
        public List<TransactionType> LoadTransactionType()
        {
            List<TransactionType> list = new List<TransactionType>();
            try
            {
                var sql = "SELECT [ID],[transactionTypeName] FROM TransactionType";
                var result = SqlHelper.ExecuteReader(dbConn, System.Data.CommandType.Text, sql);
                while (result.Read())
                {
                    var obj = new TransactionType();
                    obj.ID = Convert.ToInt32(result["ID"]);
                    obj.TransactionTypeName = Convert.ToString(result["transactionTypeName"]);
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
