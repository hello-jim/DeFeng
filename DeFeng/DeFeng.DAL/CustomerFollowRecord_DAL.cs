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
    public class CustomerFollowRecord_DAL
    {
        string dbConn = CommonClass.GetSysConfig("DeFengDBConStr");

        public List<CustomerFollowRecord> LoadCustomerFollowRecord(int customerID)
        {
            List<CustomerFollowRecord> list = new List<CustomerFollowRecord>();
            try
            {
                var sql = "SELECT f.ID,[followType],[followContent],f.createStaff,f.createDate,FollowType.ID AS followTypeID,typeName FROM CustomerFollowRecord AS f LEFT JOIN FollowType ON f.followType=FollowType.ID WHERE customerID=@customerID";
                var sqlPars = new List<SqlParameter>();
                sqlPars.Add(new SqlParameter("@customerID", customerID));
                var result = SqlHelper.ExecuteReader(dbConn, System.Data.CommandType.Text, sql, sqlPars.ToArray());
                while (result.Read())
                {
                    var obj = new CustomerFollowRecord();
                    obj.ID = Convert.ToInt32(result["ID"]);
                    obj.FollowType = new FollowType
                    {
                        ID = Convert.ToInt32(result["followTypeID"]),
                        TypeName = Convert.ToString(result["typeName"])
                    };
                    obj.FollowContent = Convert.ToString(result["followContent"]);
                    obj.CreateDate = Convert.ToDateTime(result["createDate"]);
                    obj.CreateStaff = new Staff();
                    list.Add(obj);
                }
            }
            catch (Exception ex)
            {

            }
            return list;
        }

        public bool AddCustomerFollowRecord(CustomerFollowRecord record)
        {
            var result = false;
            try
            {
                var sql = "INSERT INTO CustomerFollowRecord(customerID,followType,followContent,createStaff,createDate,lastUpdateStaff,lastUpdateDate) VALUES(@customerID,@followType,@followContent,@createStaff,GETDATE(),@lastUpdateStaff,GETDATE())";
                var sqlPars = new List<SqlParameter>();
                sqlPars.Add(new SqlParameter("@customerID", record.CustomerID));
                sqlPars.Add(new SqlParameter("@followType", record.FollowType.ID));
                sqlPars.Add(new SqlParameter("@followContent", record.FollowContent));
                sqlPars.Add(new SqlParameter("@createStaff", 1));
                sqlPars.Add(new SqlParameter("@lastUpdateStaff", 1));
                result = SqlHelper.ExecuteNonQuery(dbConn, System.Data.CommandType.Text, sql, sqlPars.ToArray()) > 0;
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public bool DeleteCustomerFollowRecord(int id)
        {
            var result = false;
            try
            {
                var sql = "DELETE FROM CustomerFollowRecord WHERE ID=@ID";
                var sqlPars = new List<SqlParameter>();
                sqlPars.Add(new SqlParameter("@ID", id));
                result = SqlHelper.ExecuteNonQuery(dbConn, System.Data.CommandType.Text, sql, sqlPars.ToArray()) > 0;
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public bool UpdateCustomerFollowRecord(CustomerFollowRecord record)
        {
            var result = false;
            try
            {
                var sql = "UPDATE CustomerFollowRecord SET followType=@followType,followContent=@followContent WHERE ID=@ID";
                var sqlPars = new List<SqlParameter>();
                sqlPars.Add(new SqlParameter("@followType", record.FollowType.ID));
                sqlPars.Add(new SqlParameter("@followContent", record.FollowContent));
                sqlPars.Add(new SqlParameter("@ID", record.ID));
                result = SqlHelper.ExecuteNonQuery(dbConn, System.Data.CommandType.Text, sql, sqlPars.ToArray()) > 0;
            }
            catch (Exception ex)
            {

            }
            return result;
        }
    }
}
