using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.Common;
using DeFeng.Model.Global;
using System.Data.SqlClient;

namespace DeFeng.DAL
{
    public class Department_DAL
    {
        string sqlConn = CommonClass.GetSysConfig("DeFengDBConStr");
        public List<Department> LoadDepartment()
        {
            List<Department> departmentList = new List<Department>();
            try
            {
                var sql = "SELECT [ID],[group_name],[level],[parent],[sort_no] FROM [Department]";
                var result = SqlHelper.ExecuteReader(sqlConn, System.Data.CommandType.Text, sql);
                while (result.Read())
                {
                    Department obj = new Department();
                    obj.ID = (int)result["ID"];
                    obj.Parent = (int)result["parent"];
                    obj.GroupName = (string)result["group_name"];
                    obj.SortNo = (int)result["sort_no"];
                    obj.Level = (int)result["level"];
                    departmentList.Add(obj);
                }
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.Msg = ex.StackTrace;
                log.Type = LogType.Error;
                GlobalQueue.LogGlobalQueue.Enqueue(log);
            }
            return departmentList;
        }

        public bool AddGroup(Department department)
        {
            var insertSuccess = false;
            try
            {
                var sql = "INSERT INTO([group_name],[level],[parent],[last_update_date],[last_update_staff],[create_date],[create_staff],[sort_no]) [Department] VALUES(@GroupName,@Level,@Parent,@LastUpdateDate,@LastUpdateStaff,@CreateDate,@CreateStaff,@SortNo)";
                List<SqlParameter> sqlParsList = new List<SqlParameter>();
                insertSuccess = SqlHelper.ExecuteNonQuery(sqlConn, System.Data.CommandType.Text, sql, sqlParsList.ToArray()) > 0;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.Msg = ex.StackTrace;
                log.Type = LogType.Error;
                GlobalQueue.LogGlobalQueue.Enqueue(log);
            }
            return insertSuccess;
        }
    }
}
