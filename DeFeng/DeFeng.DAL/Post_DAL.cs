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
    public class Post_DAL
    {
        string sqlConn = CommonClass.GetSysConfig("DeFengDBConStr");
        public List<Post> GetPostByDepartment(int departmentID)
        {
            var list = new List<Post>();
            try
            {
                var sql = "SELECT [Post].[ID],[Department].ID AS departmentID,[departmentName],[parent],[level],[postName],[department],[description],[isEnable],[postGrade],[createStaff],[createDate],[lastUpdateDate],[lastUpdateStaff FROM [Post] AS P WHERE LEFT JOIN [Department] ON p.department=[Department].ID";
                var sqlPars = new List<SqlParameter>();
                sqlPars.Add(new SqlParameter("@departmentID", departmentID));
                var result = SqlHelper.ExecuteReader(sqlConn, System.Data.CommandType.Text, sql, sqlPars.ToArray());
                while (result.Read())
                {
                    var obj = new Post();
                    obj.ID = Convert.ToInt32(result["postName"]);
                    obj.PostName = Convert.IsDBNull(result["postName"]) ? "" : Convert.ToString(result["postName"]);
                    obj.Department = new Department
                    {
                        ID = Convert.IsDBNull(result["departmentID"]) ? 0 : Convert.ToInt32(result["departmentID"]),
                        DepartmentName = Convert.IsDBNull(result["departmentName"]) ? "" : Convert.ToString(result["departmentName"]),
                        Parent = Convert.IsDBNull(result["parent"]) ? 0 : Convert.ToInt32(result["parent"]),
                        Level = Convert.IsDBNull(result["level"]) ? 0 : Convert.ToInt32(result["level"])
                    };
                    obj.Description = Convert.IsDBNull(result["description"]) ? "" : Convert.ToString(result["description"]);
                    obj.IsEnable = Convert.IsDBNull(result["isEnable"]) ? false : Convert.ToBoolean(result["isEnable"]);
                    obj.PostGrade = Convert.IsDBNull(result["postGrade"]) ? 0 : Convert.ToInt32(result["postGrade"]);
                    list.Add(obj);
                }
            }
            catch (Exception ex)
            {

            }
            return list;
        }

        public List<Post> GetPost()
        {
            var list = new List<Post>();
            try
            {
                var sql = "SELECT p.[ID],[Department].ID AS departmentID,[departmentName],[parent],Department.[level],[postName],[department],p.[description],p.[isEnable],[postGrade],p.[createStaff],p.[createDate],p.[lastUpdateDate],p.[lastUpdateStaff] FROM [Post] AS p LEFT JOIN [Department] ON p.department=[Department].ID ";
                var result = SqlHelper.ExecuteReader(sqlConn, System.Data.CommandType.Text, sql);
                while (result.Read())
                {
                    var obj = new Post();
                    obj.ID = Convert.ToInt32(result["ID"]);
                    obj.PostName = Convert.IsDBNull(result["postName"]) ? "" : Convert.ToString(result["postName"]);
                    obj.Department = new Department
                    {
                        ID = Convert.IsDBNull(result["departmentID"]) ? 0 : Convert.ToInt32(result["departmentID"]),
                        DepartmentName = Convert.IsDBNull(result["departmentName"]) ? "" : Convert.ToString(result["departmentName"]),
                        Parent = Convert.IsDBNull(result["parent"]) ? 0 : Convert.ToInt32(result["parent"]),
                        Level = Convert.IsDBNull(result["level"]) ? 0 : Convert.ToInt32(result["level"])
                    };
                    obj.Description = Convert.IsDBNull(result["description"]) ? "" : Convert.ToString(result["description"]);
                    obj.IsEnable = Convert.IsDBNull(result["isEnable"]) ? false : Convert.ToBoolean(result["isEnable"]);
                    obj.PostGrade = Convert.IsDBNull(result["postGrade"]) ? 0 : Convert.ToInt32(result["postGrade"]);
                    list.Add(obj);
                }
            }
            catch (Exception ex)
            {

            }
            return list;
        }

        public bool AddPost(Post post)
        {
            var result = false;
            try
            {
                var sql = "INSERT INTO POST([postName],[department],[description],[isEnable],[postGrade],[createStaff],[createDate],[lastUpdateDate],[lastUpdateStaff]) VALUES(@postName,@department,@description,@isEnable,@postGrade,@createStaff,@createDate,@lastUpdateDate,@lastUpdateStaff)";
                var sqlPars = new List<SqlParameter>();
                sqlPars.Add(new SqlParameter("@postName", post.PostName));
                sqlPars.Add(new SqlParameter("@description", post.Description));
                sqlPars.Add(new SqlParameter("@isEnable", post.IsEnable));
                sqlPars.Add(new SqlParameter("@createStaff", post.CreateStaff.ID));
                sqlPars.Add(new SqlParameter("@createDate", DateTime.Now));
                sqlPars.Add(new SqlParameter("@lastUpdateDate", DateTime.Now));
                sqlPars.Add(new SqlParameter("@lastUpdateStaff", post.LastUpdateStaff.ID));
                sqlPars.Add(new SqlParameter("@postGrade", post.PostGrade));
                result = SqlHelper.ExecuteNonQuery(sqlConn, System.Data.CommandType.Text, sql, sqlPars.ToArray()) > 0;
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public bool UpdatePost(Post post)
        {
            var result = false;
            try
            {
                var sql = "UPDATE POST SET [postName]=@postName,[department]=@department,[description]=@description,[isEnable]=@isEnable,[postGrade]=@postGrade,[lastUpdateDate]=@lastUpdateDate,[lastUpdateStaff]=@lastUpdateStaff WHERE ID=@ID";
                var sqlPars = new List<SqlParameter>();
                sqlPars.Add(new SqlParameter("@ID", post.ID));
                sqlPars.Add(new SqlParameter("@postName", post.PostName));
                sqlPars.Add(new SqlParameter("@description", post.Description));
                sqlPars.Add(new SqlParameter("@isEnable", post.IsEnable));
                sqlPars.Add(new SqlParameter("@lastUpdateDate", DateTime.Now));
                sqlPars.Add(new SqlParameter("@lastUpdateStaff", post.LastUpdateStaff != null ? post.LastUpdateStaff.ID : 0));
                sqlPars.Add(new SqlParameter("@postGrade", post.PostGrade));
                result = SqlHelper.ExecuteNonQuery(sqlConn, System.Data.CommandType.Text, sql, sqlPars.ToArray()) > 0;
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public bool DeletePost(List<int> idArr)
        {
            var result = false;
            try
            {
                var whereStr = new StringBuilder();
                whereStr.Append(" WHERE ");
                var sqlPars = new List<SqlParameter>();
                for (int i = 0; i < idArr.Count; i++)
                {
                    sqlPars.Add(new SqlParameter("@ID" + i, idArr[i]));
                    if ((i + 1) != idArr.Count)
                    {
                        whereStr.Append(string.Format(" ID=@ID{0} OR", i));
                    }
                    else
                    {
                        whereStr.Append(string.Format(" ID=@ID{0} ", i));
                    }
                }
                var sql = string.Format("DELETE FROM [Post] {0}", whereStr);
                result = SqlHelper.ExecuteNonQuery(sqlConn, System.Data.CommandType.Text, sql, sqlPars.ToArray()) > 0;
            }
            catch (Exception ex)
            {

            }
            return result;
        }
    }
}
