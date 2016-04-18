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
    public class Image_DAL
    {
        string sqlConn = Common.CommonClass.GetSysConfig("DeFengDBConStr");
        public int AddImage(Image img)
        {
            var result = 0;
            try
            {
                var sql = "INSERT INTO Image(houseID,fileName,createStaff,createDate,lastUpdateDate,lastUpdateStaff) VALUES(@houseID,@fileName,@createStaff,@createDate,@lastUpdateDate,@lastUpdateStaff) SELECT @@IDENTITY";
                var sqlPars = new List<SqlParameter>();
                sqlPars.Add(new SqlParameter("@houseID", img.HouseID));
                sqlPars.Add(new SqlParameter("@fileName", img.FileName));
                sqlPars.Add(new SqlParameter("@createStaff", img.CreateStaff != null ? img.CreateStaff.ID : 0));
                sqlPars.Add(new SqlParameter("@createDate", DateTime.Now));
                sqlPars.Add(new SqlParameter("@lastUpdateDate", DateTime.Now));
                sqlPars.Add(new SqlParameter("@lastUpdateStaff", img.LastUpdateStaff != null ? img.LastUpdateStaff.ID : 0));
                result = Convert.ToInt32(SqlHelper.ExecuteScalar(sqlConn, System.Data.CommandType.Text, sql, sqlPars.ToArray()));
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public List<Image> LoadHouseImages(int houseID)
        {
            var images = new List<Image>();
            try
            {
                var sql = "SELECT [ID],[houseID],[fileName] FROM Image WHERE [houseID]=@houseID";
                var sqlPars = new List<SqlParameter>();
                sqlPars.Add(new SqlParameter("@houseID", houseID));
                var result = SqlHelper.ExecuteReader(sqlConn, System.Data.CommandType.Text, sql, sqlPars.ToArray());
                while (result.Read())
                {
                    var obj = new Image();
                    obj.ID = Convert.ToInt32(result["ID"]);
                    obj.HouseID = Convert.ToInt32(result["houseID"]);
                    obj.FileName = Convert.ToString(result["fileName"]);
                    images.Add(obj);
                }
            }
            catch (Exception ex)
            {

            }
            return images;
        }

        public bool DeleteHouseImage(int imgID)
        {
            var result = false;
            try
            {
                var sql = "DELETE FROM Image WHERE ID = @ID";
                var sqlPars = new List<SqlParameter>();
                sqlPars.Add(new SqlParameter("@ID", imgID));
                result = SqlHelper.ExecuteNonQuery(sqlConn, System.Data.CommandType.Text, sql, sqlPars.ToArray()) > 0;
            }
            catch (Exception ex)
            {

            }
            return result;
        }
    }
}
