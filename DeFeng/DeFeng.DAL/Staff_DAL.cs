using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.Common;
using System.Data.SqlClient;
using System.Data;

namespace DeFeng.DAL
{
    public class Staff_DAL
    {
        string sqlConn = CommonClass.GetSysConfig("DeFengDBConStr");

       //注册
        public int Register(Staff staff)
        {
            var result = 0;
            try
            {
                var sql = "INSERT INTO staff (account,password,phone) VALUES (@account,@password,@phone)";
                var sqlPars = new List<SqlParameter>();
                //sqlPars.Add(new SqlParameter("@ID", staff.ID));
                sqlPars.Add(new SqlParameter("@account", staff.Account));
                sqlPars.Add(new SqlParameter("@password", staff.Password));
                //sqlPars.Add(new SqlParameter("@idCard", staff.IdCard));
                sqlPars.Add(new SqlParameter("@phone", staff.Phone));
                result = Convert.ToInt32(SqlHelper.ExecuteNonQuery(sqlConn, System.Data.CommandType.Text, sql, sqlPars.ToArray()));
            }
            catch (Exception ex)
            {

            }
            return result;
        }


        //个人信息
        public int Information(Staff staff)
        {
            var result = 0;
            try
            {
                var sql = "INSERT INTO Staff (staffNumber,staffName,birthdayType,idCard,submitHouseDate,sex,age,birthday,marital,education,major,bloodType,entry_time,entry_status,probation,height,probation_salary,salary,politics,title,nation,email,tel,officTel,accountType,accountAddress,place_origin,address,application_method,family_members,family_relationship,family_occupation,family_company,family_contact,entry_unit,entry_department,entry_position,leader,part_time_job,part_time_position,branch_manager,site_manager,hr_clerk,hr_manager,general_manager,login_name,access_authority) VALUES (@staffNumber,@staffName,@birthdayType,@idCard,@submitHouseDate,@sex,@age,@birthday,@marital,@education,@major,@bloodType,@entry_time,@entry_status,@probation,@height,@probation_salary,@salary,@politics,@title,@nation,@email,@tel,@officTel,@accountType,@accountAddress,@place_origin,@address,@application_method,@family_members,@family_relationship,@family_occupation,@family_company,@family_contact,@entry_unit,@entry_department,@entry_position,@leader,@part_time_job,@part_time_position,@branch_manager,@site_manager,@hr_clerk,@hr_manager,@general_manager,@login_name,@access_authority)";
                var sqlPars = new List<SqlParameter>();
                //sqlPars.Add(new SqlParameter("@ID", staff.ID));
                sqlPars.Add(new SqlParameter("@staffNumber", staff.StaffNumber));
                sqlPars.Add(new SqlParameter("@staffName", staff.StaffName));
                sqlPars.Add(new SqlParameter("@birthdayType", staff.BirthdayType));
                sqlPars.Add(new SqlParameter("@idCard", staff.IdCard));
                sqlPars.Add(new SqlParameter("@submitHouseDate", staff.SubmitHouseDate));
                sqlPars.Add(new SqlParameter("@sex", staff.Sex));
                sqlPars.Add(new SqlParameter("@age", staff.Age));
                sqlPars.Add(new SqlParameter("@birthday", staff.Birthday));
                sqlPars.Add(new SqlParameter("@marital", staff.Marital));
                sqlPars.Add(new SqlParameter("@education", staff.Education));
                sqlPars.Add(new SqlParameter("@major", staff.Major));
                sqlPars.Add(new SqlParameter("@bloodType", staff.BloodType));
                sqlPars.Add(new SqlParameter("@entry_time", staff.Entry_time));
                sqlPars.Add(new SqlParameter("@entry_status", staff.Entry_status));
                sqlPars.Add(new SqlParameter("@probation", staff.Probation));
                sqlPars.Add(new SqlParameter("@height", staff.Height));
                sqlPars.Add(new SqlParameter("@probation_salary", staff.Probation_salary));
                sqlPars.Add(new SqlParameter("@salary", staff.Salary));
                sqlPars.Add(new SqlParameter("@politics", staff.Politics));
                sqlPars.Add(new SqlParameter("@title", staff.Title));
                sqlPars.Add(new SqlParameter("@nation", staff.Nation));
                sqlPars.Add(new SqlParameter("@email", staff.Email));
                sqlPars.Add(new SqlParameter("@tel", staff.Tel));
                sqlPars.Add(new SqlParameter("@officTel", staff.OfficTel));
                sqlPars.Add(new SqlParameter("@accountType", staff.AccountType));
                sqlPars.Add(new SqlParameter("@accountAddress", staff.AccountAddress));
                sqlPars.Add(new SqlParameter("@place_origin", staff.Place_origin));
                sqlPars.Add(new SqlParameter("@address", staff.Address));
                sqlPars.Add(new SqlParameter("@application_method", staff.Application_method));
                sqlPars.Add(new SqlParameter("@family_members", staff.Family_members));
                sqlPars.Add(new SqlParameter("@family_relationship", staff.Family_relationship));
                sqlPars.Add(new SqlParameter("@family_occupation", staff.Family_occupation));
                sqlPars.Add(new SqlParameter("@family_company", staff.Family_company));
                sqlPars.Add(new SqlParameter("@family_contact", staff.Family_contact));
                sqlPars.Add(new SqlParameter("@entry_unit", staff.Entry_unit));
                sqlPars.Add(new SqlParameter("@entry_department", staff.Entry_department));
                sqlPars.Add(new SqlParameter("@entry_position", staff.Entry_position));
                sqlPars.Add(new SqlParameter("@leader", staff.Leader));
                sqlPars.Add(new SqlParameter("@part_time_job", staff.Part_time_job));
                sqlPars.Add(new SqlParameter("@part_time_position", staff.Part_time_position));
                sqlPars.Add(new SqlParameter("@branch_manager", staff.Branch_manager));
                sqlPars.Add(new SqlParameter("@site_manager", staff.Site_manager));
                sqlPars.Add(new SqlParameter("@hr_clerk", staff.Hr_clerk));
                sqlPars.Add(new SqlParameter("@hr_manager", staff.Hr_manager));
                sqlPars.Add(new SqlParameter("@general_manager", staff.General_manager));
                sqlPars.Add(new SqlParameter("@login_name", staff.Login_name));
                sqlPars.Add(new SqlParameter("@access_authority", staff.Access_authority));
                result = Convert.ToInt32(SqlHelper.ExecuteNonQuery(sqlConn, System.Data.CommandType.Text, sql, sqlPars.ToArray()));
            }
            catch (Exception ex)
            {

            }
            return result;
        }
        //用户登录
        public int UserLogin(Staff staff)
        {


            var count = 0;
            try
            {
                var sql = "SELECT [account],[password] FROM Staff WHERE [account]=@account AND [password]=@password";
                var sqlPars = new List<SqlParameter>();
                sqlPars.Add(new SqlParameter("@ID", staff.ID));
                sqlPars.Add(new SqlParameter("@account", staff.Account));
                sqlPars.Add(new SqlParameter("@password", staff.Password));
                var result = SqlHelper.ExecuteReader(sqlConn, System.Data.CommandType.Text, sql, sqlPars.ToArray());

                while (result.Read())
                {
                    var list = new List<Staff>();
                    var obj = new Staff();
                    obj.Account = Convert.ToString(result["id"]);
                    obj.Account = Convert.ToString(result["account"]);
                    obj.Password = Convert.ToString(result["password"]);
                    list.Add(obj);
                    return 1;
                }

            }
            catch (Exception ex)
            {

            }
            return count;

        }


        //登录查用户是否已存在
        public int CheckStaff(string account) {
                var count = 0;
                try
                {
                    var sql = "select count(*) from staff where account=@account";
                    var sqlPars = new List<SqlParameter>();
                    sqlPars.Add(new SqlParameter("@account", @account));
                    var result = SqlHelper.ExecuteReader(sqlConn, System.Data.CommandType.Text, sql, sqlPars.ToArray());
                    while (result.Read())
                    {
                        count = Convert.ToInt32(result[0]);
                    }
                }
                catch (Exception ex)
                {

                }
                return count;
        }

        //查询用户是否已注册  >1已经注册
        public int CheckUserName(string account) {
            var count = 0;
            try
            {
                var sql = "SELECT count(*) FROM staff WHERE account=@account";
                var sqlPars = new List<SqlParameter>();
                //sqlpars.add(new sqlparameter("@id", staff.id));
                sqlPars.Add(new SqlParameter("@account", @account));
                var result = SqlHelper.ExecuteReader(sqlConn, System.Data.CommandType.Text, sql, sqlPars.ToArray());
                while (result.Read())
                {
                    count = Convert.ToInt32(result[0]);
                }
            }
            catch (Exception ex)
            {

            }
            return count;
        }

    }
}