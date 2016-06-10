using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.Common;

namespace DeFeng.DAL
{
    public class StaffPermission_DAL
    {
        string sqlConn = CommonClass.GetSysConfig("DeFengDBConStr");
        public bool AddStaffPermission(int staffID,int createStaffID,List<int> permissionIDList)
        {
            var result = false;
            DataTable dt = new DataTable();
            dt.Columns.Add("staffID");
            dt.Columns.Add("permissionID");
            dt.Columns.Add("createStaff");
            dt.Columns.Add("createDate");
            dt.Columns.Add("lastUpdateDate");
            dt.Columns.Add("lastUpdateStaff");
            for (int i = 0; i < permissionIDList.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = staffID;
                dr[1] = permissionIDList[i];
                dr[2] = createStaffID;
                dr[3] = DateTime.Now;
                dr[4] = DateTime.Now;
                dr[5] = createStaffID;             
                dt.Rows.Add(dr);
            }

            using (SqlConnection conn = new SqlConnection(sqlConn))
            {
                using (SqlBulkCopy sqlbulkcopy = new SqlBulkCopy(sqlConn, SqlBulkCopyOptions.UseInternalTransaction))
                {
                    try
                    {
                        sqlbulkcopy.DestinationTableName = "AnnouncementRead";
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            sqlbulkcopy.ColumnMappings.Add(dt.Columns[i].ColumnName, dt.Columns[i].ColumnName);
                        }
                        sqlbulkcopy.WriteToServer(dt);
                    }
                    catch (System.Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            return result;
        }
    }
}
