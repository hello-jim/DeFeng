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
                var sql = "SELECT [ID],[departmentName],[level],[parent],[lastUpdateDate],[lastUpdateStaff],[createDate],[createStaff] FROM [Department]";
                var result = SqlHelper.ExecuteReader(sqlConn, System.Data.CommandType.Text, sql);
                while (result.Read())
                {
                    Department obj = new Department();
                    obj.ID = Convert.ToInt32(result["ID"]);
                    obj.Parent = Convert.IsDBNull(result["parent"]) ? 0 : Convert.ToInt32(result["parent"]);
                    obj.DepartmentName = Convert.IsDBNull(result["departmentName"]) ? "" : Convert.ToString(result["departmentName"]);
                    obj.Level = Convert.IsDBNull(result["level"]) ? 0 : Convert.ToInt32(result["level"]);
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



        public bool AddDepartment(Department department)
        {
            var result = false;
            try
            {
                var sql = "INSERT INTO FROM Department([departmentName],[level],[parent],[lastUpdateDate],[lastUpdateStaff],[createDate],[createStaff]) VALUES(@departmentName,@level,@parent,@lastUpdateDate,@lastUpdateStaff,@createDate,@createStaff)";
                List<SqlParameter> sqlParsList = new List<SqlParameter>();
                var sqlPars = new List<SqlParameter>();
                sqlPars.Add(new SqlParameter("@departmentName", department.DepartmentName));
                sqlPars.Add(new SqlParameter("@level", department.Level));
                sqlPars.Add(new SqlParameter("@parent", department.Parent));
                sqlPars.Add(new SqlParameter("@lastUpdateDate", DateTime.Now));
                sqlPars.Add(new SqlParameter("@lastUpdateStaff", department.LastUpdateStaff.ID));
                sqlPars.Add(new SqlParameter("@createDate", DateTime.Now));
                sqlPars.Add(new SqlParameter("@createStaff", department.CreateStaff.ID));
                result = SqlHelper.ExecuteNonQuery(sqlConn, System.Data.CommandType.Text, sql, sqlPars.ToArray()) > 0;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.Msg = ex.StackTrace;
                log.Type = LogType.Error;
                GlobalQueue.LogGlobalQueue.Enqueue(log);
            }
            return result;
        }

        public bool UpdateDepartment(Department department)
        {
            var result = false;
            try
            {
                var sql = "UPDATE FROM Department SET [departmentName]=@departmentName,[lastUpdateDate]=@lastUpdateDate,[lastUpdateStaff]=@lastUpdateStaff";
                var sqlPars = new List<SqlParameter>();
                sqlPars.Add(new SqlParameter("@departmentName", department.DepartmentName));
                sqlPars.Add(new SqlParameter("@lastUpdateDate", DateTime.Now));
                sqlPars.Add(new SqlParameter("@lastUpdateStaff", department.LastUpdateStaff.ID));
                result = SqlHelper.ExecuteNonQuery(sqlConn, System.Data.CommandType.Text, sql, sqlPars.ToArray()) > 0;
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public bool DeleteDepartment(int id)
        {
            var result = false;
            try
            {
                var sql = "DELETE FROM [Department] WHERE ID=@ID";
                var sqlPars = new List<SqlParameter>();
                sqlPars.Add(new SqlParameter("@ID", id));
                result = SqlHelper.ExecuteNonQuery(sqlConn, System.Data.CommandType.Text, sql, sqlPars.ToArray()) > 0;
            }
            catch (Exception ex)
            {

            }
            return result;
        }
    }
}
