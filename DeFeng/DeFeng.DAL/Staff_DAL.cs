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
                var sql = "INSERT INTO staff (account,password,IdCard,phone,isEnable,createDate) VALUES (@account,@password,@IdCard,@phone,@isEnable,@createDate)";
                var sqlPars = new List<SqlParameter>();
                sqlPars.Add(new SqlParameter("@account", staff.Account));
                sqlPars.Add(new SqlParameter("@password", staff.Password));
                sqlPars.Add(new SqlParameter("@idCard", staff.IdCard));
                sqlPars.Add(new SqlParameter("@phone", staff.Phone));
                sqlPars.Add(new SqlParameter("@isEnable", staff.IsEnable));
                sqlPars.Add(new SqlParameter("@createDate", DateTime.Now));
                result = SqlHelper.ExecuteNonQuery(sqlConn, System.Data.CommandType.Text, sql, sqlPars.ToArray());
            }
            catch (Exception ex)
            {

            }
            return result;
        }


        //修改个人信息
        public int Information(Staff staff)
        {
            var result = 0;
            try
            {
                var sql = "UPDATE Staff set account=@account,staffNumber=@staffNumber,staffName=@staffName,birthdayType=@birthdayType,idCard=@idCard,dateBirth=@dateBirth,sex=@sex,age=@age,birthday=@birthday,marital=@marital,education=@education,major=@major,bloodType=@bloodType,entryTime=@entryTime,entry_status=@entry_status,probation=@probation,height=@height,probationSalary=@probationSalary,salary=@salary,politics=@politics,title=@title,nation=@nation,email=@email,tel=@tel,officTel=@officTel,accountType=@accountType,accountAddress=@accountAddress,place_origin=@place_origin,address=@address,application_method=@application_method,family_members=@application_method,family_relationship=@family_relationship,family_occupation=@family_occupation,landscape=@landscape,family_company=@family_company,family_contact=@family_contact,entry_unit=@entry_unit,entry_department=@entry_department,entry_position=@entry_position,leader=@leader,part_time_job=@part_time_job,part_time_position=@part_time_position,branch_manager=@branch_manager,site_manager=@site_manager,hr_clerk=@hr_clerk,hr_manager=@hr_manager,general_manager=@general_manager,login_name=@login_name,access_authority=@access_authority WHERE account=@account";
                var sqlPars = new List<SqlParameter>();
                //sqlPars.Add(new SqlParameter("@ID", staff.ID));
                sqlPars.Add(new SqlParameter("@account", staff.Account));
                sqlPars.Add(new SqlParameter("@staffNumber", staff.StaffNumber));
                sqlPars.Add(new SqlParameter("@staffName", staff.StaffName));
                sqlPars.Add(new SqlParameter("@birthdayType", staff.BirthdayType));
                sqlPars.Add(new SqlParameter("@idCard", staff.IdCard));
                sqlPars.Add(new SqlParameter("@dateBirth", staff.DateBirth));
                sqlPars.Add(new SqlParameter("@sex", staff.Sex));
                sqlPars.Add(new SqlParameter("@age", staff.Age));
                sqlPars.Add(new SqlParameter("@birthday", staff.Birthday));
                sqlPars.Add(new SqlParameter("@marital", staff.Marital));
                sqlPars.Add(new SqlParameter("@education", staff.Education));
                sqlPars.Add(new SqlParameter("@major", staff.Major));
                sqlPars.Add(new SqlParameter("@bloodType", staff.BloodType));
                sqlPars.Add(new SqlParameter("@entryTime", staff.EntryTime));
                sqlPars.Add(new SqlParameter("@entry_status", staff.Entry_status));
                sqlPars.Add(new SqlParameter("@probation", staff.Probation));
                sqlPars.Add(new SqlParameter("@height", staff.Height));
                sqlPars.Add(new SqlParameter("@probationSalary", staff.ProbationSalary));
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
                sqlPars.Add(new SqlParameter("@landscape", staff.Landscape));
                sqlPars.Add(new SqlParameter("@family_company", staff.Family_company));
                sqlPars.Add(new SqlParameter("@family_contact", staff.Family_contact));
                sqlPars.Add(new SqlParameter("@entry_unit", staff.Entry_unit));
                sqlPars.Add(new SqlParameter("@department", staff.Department != null ? staff.Department.ID : 0));
                sqlPars.Add(new SqlParameter("@post", staff.Post != null ? staff.Post.ID : 0));
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
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public Staff UserLogin(Staff obj)
        {
            Staff staff = null;
            try
            {
                var sql = new StringBuilder("SELECT Department.ID AS departmentID,departmentName,Post.ID AS postID,postName,s.[ID],[account],[photo],[staffNumber],[staffName],[birthdayType],[idCard],[dateBirth],[sex],[age],[birthday],[marital],[education],[major],[bloodType],[entryTime],[entry_status],[probation],[height],[probationSalary],[salary],[politics],[title],[nation],[email],[phone],[tel],[officTel],[accountType],[accountAddress],[place_origin],[address],[application_method],[family_members],[family_relationship],[family_occupation],[landscape],[family_company],[family_contact],[entry_unit],s.[department],s.[post],[leader],[part_time_job],[part_time_position],[branch_manager],[site_manager],[hr_clerk],[hr_manager],[general_manager],[login_name],[access_authority],s.[isEnable],s.[createStaff],s.[createDate],s.[lastUpdateDate],s.[lastUpdateStaff] FROM Staff s ");
                sql.Append("LEFT JOIN [Department] ON s.department=[Department].ID ");
                sql.Append("LEFT JOIN [Post] ON s.post=[Post].ID ");
                sql.Append("WHERE [account]=@account AND [password]=@password ");
                var sqlPars = new List<SqlParameter>();
                //sqlPars.Add(new SqlParameter("@ID", staff.ID));
                sqlPars.Add(new SqlParameter("@account", obj.Account));
                sqlPars.Add(new SqlParameter("@password", obj.Password));
                var read = SqlHelper.ExecuteReader(sqlConn, System.Data.CommandType.Text, sql.ToString(), sqlPars.ToArray());

                while (read.Read())
                {
                    staff = new Staff
                    {
                        ID = Convert.ToInt32(read["ID"]),
                        Account = Convert.IsDBNull(read["account"]) ? "" : Convert.ToString(read["account"]),
                        StaffNumber = Convert.IsDBNull(read["staffNumber"]) ? "" : Convert.ToString(read["staffNumber"]),
                        StaffName = Convert.IsDBNull(read["staffName"]) ? "" : Convert.ToString(read["staffName"]),
                        IdCard = Convert.IsDBNull(read["idCard"]) ? "" : Convert.ToString(read["idCard"]),
                        DateBirth = Convert.IsDBNull(read["dateBirth"]) ? new DateTime() : Convert.ToDateTime(read["dateBirth"]),
                        Sex = Convert.IsDBNull(read["sex"]) ? 0 : Convert.ToInt32(read["sex"]),
                        Age = Convert.IsDBNull(read["age"]) ? 0 : Convert.ToInt32(read["age"]),
                        Birthday = Convert.IsDBNull(read["birthday"]) ? "" : Convert.ToString(read["birthday"]),
                        EntryTime = Convert.IsDBNull(read["entryTime"]) ? new DateTime() : Convert.ToDateTime(read["entryTime"]),
                        Height = Convert.IsDBNull(read["height"]) ? 0 : Convert.ToSingle(read["height"]),
                        Salary = Convert.IsDBNull(read["salary"]) ? 0 : Convert.ToDecimal(read["salary"]),
                        Politics = Convert.IsDBNull(read["politics"]) ? "" : Convert.ToString(read["politics"]),
                        Title = Convert.IsDBNull(read["title"]) ? "" : Convert.ToString(read["title"]),
                        Nation = Convert.IsDBNull(read["nation"]) ? "" : Convert.ToString(read["nation"]),
                        Email = Convert.IsDBNull(read["email"]) ? "" : Convert.ToString(read["email"]),
                        Phone = Convert.IsDBNull(read["phone"]) ? "" : Convert.ToString(read["phone"]),
                        Tel = Convert.IsDBNull(read["tel"]) ? "" : Convert.ToString(read["tel"]),
                        OfficTel = Convert.IsDBNull(read["officTel"]) ? "" : Convert.ToString(read["officTel"]),
                        AccountType = Convert.IsDBNull(read["accountType"]) ? "" : Convert.ToString(read["accountType"]),
                        AccountAddress = Convert.IsDBNull(read["accountAddress"]) ? "" : Convert.ToString(read["accountAddress"]),
                        Place_origin = Convert.IsDBNull(read["place_origin"]) ? "" : Convert.ToString(read["place_origin"]),
                        Address = Convert.IsDBNull(read["address"]) ? "" : Convert.ToString(read["address"]),
                        Application_method = Convert.IsDBNull(read["application_method"]) ? "" : Convert.ToString(read["application_method"]),
                        Family_members = Convert.IsDBNull(read["family_members"]) ? "" : Convert.ToString(read["family_members"]),
                        Family_relationship = Convert.IsDBNull(read["family_relationship"]) ? "" : Convert.ToString(read["family_relationship"]),
                        Family_occupation = Convert.IsDBNull(read["family_occupation"]) ? "" : Convert.ToString(read["family_occupation"]),
                        Landscape = Convert.IsDBNull(read["landscape"]) ? "" : Convert.ToString(read["landscape"]),
                        Family_company = Convert.IsDBNull(read["family_company"]) ? "" : Convert.ToString(read["family_company"]),
                        Family_contact = Convert.IsDBNull(read["family_contact"]) ? "" : Convert.ToString(read["family_contact"]),
                        Entry_unit = Convert.IsDBNull(read["entry_unit"]) ? "" : Convert.ToString(read["entry_unit"]),
                        Department = new Department
                        {
                            ID = Convert.IsDBNull(read["departmentID"]) ? 0 : Convert.ToInt32(read["departmentID"]),
                            DepartmentName = Convert.IsDBNull(read["departmentName"]) ? "" : Convert.ToString(read["departmentName"])
                        },
                        Post = new Post
                        {
                            ID = Convert.IsDBNull(read["postID"]) ? 0 : Convert.ToInt32(read["postID"]),
                            PostName = Convert.IsDBNull(read["postName"]) ? "" : Convert.ToString(read["postName"])
                        },
                        Leader = Convert.IsDBNull(read["leader"]) ? "" : Convert.ToString(read["leader"]),
                        Part_time_job = Convert.IsDBNull(read["part_time_job"]) ? "" : Convert.ToString(read["part_time_job"]),
                        Part_time_position = Convert.IsDBNull(read["part_time_position"]) ? "" : Convert.ToString(read["part_time_position"]),
                        Branch_manager = Convert.IsDBNull(read["branch_manager"]) ? "" : Convert.ToString(read["branch_manager"]),
                        Site_manager = Convert.IsDBNull(read["site_manager"]) ? "" : Convert.ToString(read["site_manager"]),
                        Hr_clerk = Convert.IsDBNull(read["hr_clerk"]) ? "" : Convert.ToString(read["hr_clerk"]),
                        Hr_manager = Convert.IsDBNull(read["hr_manager"]) ? "" : Convert.ToString(read["hr_manager"]),
                        General_manager = Convert.IsDBNull(read["general_manager"]) ? "" : Convert.ToString(read["general_manager"]),
                        Login_name = Convert.IsDBNull(read["login_name"]) ? "" : Convert.ToString(read["login_name"]),
                        Access_authority = Convert.IsDBNull(read["access_authority"]) ? "" : Convert.ToString(read["access_authority"]),
                    };
                }
            }
            catch (Exception ex)
            {

            }
            return staff;
        }


        //登录查用户是否已存在
        public int CheckStaff(string account)
        {
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
        public int CheckUserName(string account)
        {
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

        public List<Staff> GetStaff()
        {
            var list = new List<Staff>();
            try
            {
                var sql = new StringBuilder();
                sql.Append("SELECT Department.ID AS departmentID,departmentName,Post.ID AS postID,postName,s.[ID] ,[password] ,[account],[photo] ,[staffNumber] ,[staffName],[birthdayType],[idCard],[dateBirth],[sex],[age],[birthday],[marital],[education],[major] ,[bloodType],[entryTime],[entry_status],[probation],[height],[probationSalary],[salary],[politics],[title],[nation],[email],[phone],[tel],[officTel],[accountType],[accountAddress],[place_origin],[address],[application_method],[family_members],[family_relationship],[family_occupation],[landscape],[family_company],[family_contact],[entry_unit],[leader],[part_time_job],[part_time_position],[branch_manager],[site_manager],[hr_clerk],[hr_manager],[general_manager],[login_name],[access_authority] FROM Staff s ");
                sql.Append("LEFT JOIN [Department] ON s.department=[Department].ID ");
                sql.Append("LEFT JOIN [Post] ON s.post=[Post].ID ");
                var sqlPars = new List<SqlParameter>();
                var result = SqlHelper.ExecuteReader(sqlConn, CommandType.Text, sql.ToString());
                while (result.Read())
                {
                    var obj = new Staff();
                    obj.ID = Convert.ToInt32(result["ID"]);
                    obj.StaffNumber = Convert.IsDBNull(result["staffNumber"]) ? "" : Convert.ToString(result["staffNumber"]);
                    obj.StaffName = Convert.IsDBNull(result["staffName"]) ? "" : Convert.ToString(result["staffName"]);
                    obj.BirthdayType = Convert.IsDBNull(result["birthdayType"]) ? "" : Convert.ToString(result["birthdayType"]);
                    obj.IdCard = Convert.IsDBNull(result["idCard"]) ? "" : Convert.ToString(result["idCard"]);
                    obj.DateBirth = Convert.IsDBNull(result["dateBirth"]) ? new DateTime() : Convert.ToDateTime(result["dateBirth"]);
                    obj.Sex = Convert.IsDBNull(result["sex"]) ? 0 : Convert.ToInt32(result["sex"]);
                    obj.Age = Convert.IsDBNull(result["age"]) ? 0 : Convert.ToInt32(result["age"]);
                    obj.Marital = Convert.IsDBNull(result["marital"]) ? "" : Convert.ToString(result["marital"]);
                    obj.Education = Convert.IsDBNull(result["education"]) ? "" : Convert.ToString(result["education"]);
                    obj.BloodType = Convert.IsDBNull(result["bloodType"]) ? "" : Convert.ToString(result["bloodType"]);
                    obj.EntryTime = Convert.IsDBNull(result["entryTime"]) ? new DateTime() : Convert.ToDateTime(result["entryTime"]);
                    obj.Entry_status = Convert.IsDBNull(result["entry_status"]) ? "" : Convert.ToString(result["entry_status"]);
                    obj.Probation = Convert.IsDBNull(result["probation"]) ? "" : Convert.ToString(result["probation"]);
                    obj.Height = Convert.IsDBNull(result["height"]) ? 0 : Convert.ToSingle(result["height"]);
                    obj.ProbationSalary = Convert.IsDBNull(result["probationSalary"]) ? 0 : Convert.ToDecimal(result["probationSalary"]);
                    obj.Salary = Convert.IsDBNull(result["salary"]) ? 0 : Convert.ToDecimal(result["salary"]);
                    obj.Politics = Convert.IsDBNull(result["politics"]) ? "" : Convert.ToString(result["politics"]);
                    obj.Title = Convert.IsDBNull(result["title"]) ? "" : Convert.ToString(result["title"]);
                    obj.Nation = Convert.IsDBNull(result["nation"]) ? "" : Convert.ToString(result["nation"]);
                    obj.Email = Convert.IsDBNull(result["email"]) ? "" : Convert.ToString(result["email"]);
                    obj.Phone = Convert.IsDBNull(result["phone"]) ? "" : Convert.ToString(result["phone"]);
                    obj.Tel = Convert.IsDBNull(result["tel"]) ? "" : Convert.ToString(result["tel"]);
                    obj.OfficTel = Convert.IsDBNull(result["officTel"]) ? "" : Convert.ToString(result["officTel"]);
                    obj.AccountType = Convert.IsDBNull(result["accountType"]) ? "" : Convert.ToString(result["accountType"]);
                    obj.AccountAddress = Convert.IsDBNull(result["accountAddress"]) ? "" : Convert.ToString(result["accountAddress"]);
                    obj.Place_origin = Convert.IsDBNull(result["place_origin"]) ? "" : Convert.ToString(result["place_origin"]);
                    obj.Address = Convert.IsDBNull(result["address"]) ? "" : Convert.ToString(result["address"]);
                    obj.Application_method = Convert.IsDBNull(result["application_method"]) ? "" : Convert.ToString(result["application_method"]);
                    obj.Family_members = Convert.IsDBNull(result["family_members"]) ? "" : Convert.ToString(result["family_members"]);
                    obj.Family_relationship = Convert.IsDBNull(result["family_relationship"]) ? "" : Convert.ToString(result["family_relationship"]);
                    obj.Family_occupation = Convert.IsDBNull(result["family_occupation"]) ? "" : Convert.ToString(result["family_occupation"]);
                    obj.Landscape = Convert.IsDBNull(result["landscape"]) ? "" : Convert.ToString(result["landscape"]);
                    obj.Family_company = Convert.IsDBNull(result["family_company"]) ? "" : Convert.ToString(result["family_company"]);
                    obj.Family_contact = Convert.IsDBNull(result["family_contact"]) ? "" : Convert.ToString(result["family_contact"]);
                    obj.Entry_unit = Convert.IsDBNull(result["entry_unit"]) ? "" : Convert.ToString(result["entry_unit"]);
                    obj.Department = new Department
                    {
                        ID = Convert.IsDBNull(result["departmentID"]) ? 0 : Convert.ToInt32(result["departmentID"]),
                        DepartmentName = Convert.IsDBNull(result["departmentName"]) ? "" : Convert.ToString(result["departmentName"])
                    };
                    obj.Post = new Post
                    {
                        ID = Convert.IsDBNull(result["postID"]) ? 0 : Convert.ToInt32(result["postID"]),
                        PostName = Convert.IsDBNull(result["postName"]) ? "" : Convert.ToString(result["postName"])
                    };
                    obj.Leader = Convert.IsDBNull(result["leader"]) ? "" : Convert.ToString(result["leader"]);
                    obj.Part_time_job = Convert.IsDBNull(result["part_time_job"]) ? "" : Convert.ToString(result["part_time_job"]);
                    obj.Part_time_position = Convert.IsDBNull(result["part_time_position"]) ? "" : Convert.ToString(result["part_time_position"]);
                    obj.Branch_manager = Convert.IsDBNull(result["branch_manager"]) ? "" : Convert.ToString(result["branch_manager"]);
                    obj.Site_manager = Convert.IsDBNull(result["site_manager"]) ? "" : Convert.ToString(result["site_manager"]);
                    obj.Hr_clerk = Convert.IsDBNull(result["hr_clerk"]) ? "" : Convert.ToString(result["hr_clerk"]);
                    obj.Hr_manager = Convert.IsDBNull(result["hr_manager"]) ? "" : Convert.ToString(result["hr_manager"]);
                    obj.General_manager = Convert.IsDBNull(result["general_manager"]) ? "" : Convert.ToString(result["general_manager"]);
                    obj.Login_name = Convert.IsDBNull(result["login_name"]) ? "" : Convert.ToString(result["login_name"]);
                    obj.Access_authority = Convert.IsDBNull(result["access_authority"]) ? "" : Convert.ToString(result["access_authority"]);
                    list.Add(obj);
                }

            }
            catch (Exception ex)
            {

            }
            return list;
        }

        public List<Staff> GetStaffByDepartment(int departmentID)
        {
            var list = new List<Staff>();
            try
            {
                var sql = new StringBuilder();
                sql.Append("SELECT Department.ID AS departmentID,departmentName,Post.ID AS postID,postName, [ID] ,[password] ,[account],[photo] ,[staffNumber] ,[staffName],[birthdayType],[idCard],[dateBirth],[sex],[age],[birthday],[marital],[education],[major] ,[bloodType],[entryTime],[entry_status],[probation],[height],[probationSalary],[salary],[politics],[title],[nation],[email],[phone],[tel],[officTel],[accountType],[accountAddress],[place_origin],[address],[application_method],[family_members],[family_relationship],[family_occupation],[landscape],[family_company],[family_contact],[entry_unit],[leader],[part_time_job],[part_time_position],[branch_manager],[site_manager],[hr_clerk],[hr_manager],[general_manager],[login_name],[access_authority] FROM Staff s ");
                sql.Append("LEFT JOIN [Department] ON s.post=[Department].ID ");
                sql.Append("LEFT JOIN [Post] ON s.post=[Post].ID ");
                sql.Append("WHERE department=@department ");
                var sqlPars = new List<SqlParameter>();
                sqlPars.Add(new SqlParameter("@department", departmentID));
                var result = SqlHelper.ExecuteReader(sqlConn, CommandType.Text, sql.ToString(), sqlPars.ToArray());
                while (result.Read())
                {
                    var obj = new Staff();
                    obj.ID = Convert.ToInt32(result["ID"]);
                    obj.StaffNumber = Convert.IsDBNull(result["staffNumber"]) ? "" : Convert.ToString(result["staffNumber"]);
                    obj.StaffName = Convert.IsDBNull(result["staffName"]) ? "" : Convert.ToString(result["staffName"]);
                    obj.BirthdayType = Convert.IsDBNull(result["birthdayType"]) ? "" : Convert.ToString(result["birthdayType"]);
                    obj.IdCard = Convert.IsDBNull(result["idCard"]) ? "" : Convert.ToString(result["idCard"]);
                    obj.DateBirth = Convert.IsDBNull(result["dateBirth"]) ? new DateTime() : Convert.ToDateTime(result["dateBirth"]);
                    obj.Sex = Convert.IsDBNull(result["sex"]) ? 0 : Convert.ToInt32(result["sex"]);
                    obj.Age = Convert.IsDBNull(result["age"]) ? 0 : Convert.ToInt32(result["age"]);
                    obj.Marital = Convert.IsDBNull(result["marital"]) ? "" : Convert.ToString(result["marital"]);
                    obj.Education = Convert.IsDBNull(result["education"]) ? "" : Convert.ToString(result["education"]);
                    obj.BloodType = Convert.IsDBNull(result["bloodType"]) ? "" : Convert.ToString(result["bloodType"]);
                    obj.EntryTime = Convert.IsDBNull(result["entryTime"]) ? new DateTime() : Convert.ToDateTime(result["entryTime"]);
                    obj.Entry_status = Convert.IsDBNull(result["entry_status"]) ? "" : Convert.ToString(result["entry_status"]);
                    obj.Probation = Convert.IsDBNull(result["probation"]) ? "" : Convert.ToString(result["probation"]);
                    obj.Height = Convert.IsDBNull(result["height"]) ? 0 : Convert.ToSingle(result["height"]);
                    obj.ProbationSalary = Convert.IsDBNull(result["probationSalary"]) ? 0 : Convert.ToDecimal(result["probationSalary"]);
                    obj.Salary = Convert.IsDBNull(result["salary"]) ? 0 : Convert.ToDecimal(result["salary"]);
                    obj.Politics = Convert.IsDBNull(result["politics"]) ? "" : Convert.ToString(result["politics"]);
                    obj.Title = Convert.IsDBNull(result["title"]) ? "" : Convert.ToString(result["title"]);
                    obj.Nation = Convert.IsDBNull(result["nation"]) ? "" : Convert.ToString(result["nation"]);
                    obj.Email = Convert.IsDBNull(result["email"]) ? "" : Convert.ToString(result["email"]);
                    obj.Phone = Convert.IsDBNull(result["phone"]) ? "" : Convert.ToString(result["phone"]);
                    obj.Tel = Convert.IsDBNull(result["tel"]) ? "" : Convert.ToString(result["tel"]);
                    obj.OfficTel = Convert.IsDBNull(result["officTel"]) ? "" : Convert.ToString(result["officTel"]);
                    obj.AccountType = Convert.IsDBNull(result["accountType"]) ? "" : Convert.ToString(result["accountType"]);
                    obj.AccountAddress = Convert.IsDBNull(result["accountAddress"]) ? "" : Convert.ToString(result["accountAddress"]);
                    obj.Place_origin = Convert.IsDBNull(result["place_origin"]) ? "" : Convert.ToString(result["place_origin"]);
                    obj.Address = Convert.IsDBNull(result["address"]) ? "" : Convert.ToString(result["address"]);
                    obj.Application_method = Convert.IsDBNull(result["application_method"]) ? "" : Convert.ToString(result["application_method"]);
                    obj.Family_members = Convert.IsDBNull(result["family_members"]) ? "" : Convert.ToString(result["family_members"]);
                    obj.Family_relationship = Convert.IsDBNull(result["family_relationship"]) ? "" : Convert.ToString(result["family_relationship"]);
                    obj.Family_occupation = Convert.IsDBNull(result["family_occupation"]) ? "" : Convert.ToString(result["family_occupation"]);
                    obj.Landscape = Convert.IsDBNull(result["landscape"]) ? "" : Convert.ToString(result["landscape"]);
                    obj.Family_company = Convert.IsDBNull(result["family_company"]) ? "" : Convert.ToString(result["family_company"]);
                    obj.Family_contact = Convert.IsDBNull(result["family_contact"]) ? "" : Convert.ToString(result["family_contact"]);
                    obj.Entry_unit = Convert.IsDBNull(result["entry_unit"]) ? "" : Convert.ToString(result["entry_unit"]);
                    obj.Department = new Department
                    {
                        ID = Convert.IsDBNull(result["departmentID"]) ? 0 : Convert.ToInt32(result["departmentID"]),
                        DepartmentName = Convert.IsDBNull(result["departmentName"]) ? "" : Convert.ToString(result["departmentName"])
                    };
                    obj.Post = new Post
                    {
                        ID = Convert.IsDBNull(result["postID"]) ? 0 : Convert.ToInt32(result["postID"]),
                        PostName = Convert.IsDBNull(result["postName"]) ? "" : Convert.ToString(result["postName"])
                    };
                    obj.Leader = Convert.IsDBNull(result["leader"]) ? "" : Convert.ToString(result["leader"]);
                    obj.Part_time_job = Convert.IsDBNull(result["part_time_job"]) ? "" : Convert.ToString(result["part_time_job"]);
                    obj.Part_time_position = Convert.IsDBNull(result["part_time_position"]) ? "" : Convert.ToString(result["part_time_position"]);
                    obj.Branch_manager = Convert.IsDBNull(result["branch_manager"]) ? "" : Convert.ToString(result["branch_manager"]);
                    obj.Site_manager = Convert.IsDBNull(result["site_manager"]) ? "" : Convert.ToString(result["site_manager"]);
                    obj.Hr_clerk = Convert.IsDBNull(result["hr_clerk"]) ? "" : Convert.ToString(result["hr_clerk"]);
                    obj.Hr_manager = Convert.IsDBNull(result["hr_manager"]) ? "" : Convert.ToString(result["hr_manager"]);
                    obj.General_manager = Convert.IsDBNull(result["general_manager"]) ? "" : Convert.ToString(result["general_manager"]);
                    obj.Login_name = Convert.IsDBNull(result["login_name"]) ? "" : Convert.ToString(result["login_name"]);
                    obj.Access_authority = Convert.IsDBNull(result["access_authority"]) ? "" : Convert.ToString(result["access_authority"]);
                    list.Add(obj);
                }
            }
            catch (Exception ex)
            {

            }
            return list;
        }

        /// <summary>
        /// 根据部门获取员工ID
        /// </summary>
        /// <param name="depIDArr">部门ID</param>
        /// <returns></returns>
        public List<int> GetStaffIDByDepartment(List<int> depIDArr)
        {
            var list = new List<int>();
            try
            {
                var idArr = String.Join(",", depIDArr);
                var sql = new StringBuilder();
                sql.Append(string.Format("SELECT [ID] FROM Staff WHERE [department] IN({0})", idArr));
                var result = SqlHelper.ExecuteReader(sqlConn, CommandType.Text, sql.ToString());
                while (result.Read())
                {
                    list.Add(Convert.ToInt32(result["ID"]));
                }
            }
            catch (Exception ex)
            {

            }
            return list;
        }


        /// <summary>
        /// 根据岗位获取员工ID
        /// </summary>
        /// <param name="postIDArr"></param>
        /// <returns></returns>
        public List<int> GetStaffIDByPost(List<int> postIDArr)
        {
            var list = new List<int>();
            try
            {
                var idArr = String.Join(",", postIDArr);
                var sql = new StringBuilder();
                sql.Append(string.Format("SELECT [ID] FROM Staff WHERE [post] IN({0})", idArr));
                var result = SqlHelper.ExecuteReader(sqlConn, CommandType.Text, sql.ToString());
                while (result.Read())
                {
                    list.Add(Convert.ToInt32(result["ID"]));
                }
            }
            catch (Exception ex)
            {

            }
            return list;
        }

        /// <summary>
        /// 获取所有员工ID
        /// </summary>
        /// <returns></returns>
        public List<int> GetStaffID()
        {
            var list = new List<int>();
            try
            {
                var sql = "SELECT [ID] FROM Staff";
                var result = SqlHelper.ExecuteReader(sqlConn, CommandType.Text, sql);
                while (result.Read())
                {
                    list.Add(Convert.ToInt32(result["ID"]));
                }
            }
            catch (Exception ex)
            {

            }
            return list;
        }

        public bool DeleteStaff(List<int> idArr)
        {
            var result = false;
            try
            {
                var idArrStr = String.Join(",", idArr);
                var sql = string.Format("DELETE FROM [Staff] WHERE ID IN({0})", idArrStr);
                result = SqlHelper.ExecuteNonQuery(sqlConn, System.Data.CommandType.Text, sql) > 0;
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public bool UpdateStaff()
        {

            return true;
        }
    }
}