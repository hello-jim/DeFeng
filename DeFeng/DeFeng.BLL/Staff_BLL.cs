using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.DAL;
using System.Security.Principal;
using DeFeng.Model;

namespace DeFeng.BLL
{
    public class Staff_BLL
    {
        Staff_DAL dal = new Staff_DAL();

        public int Register(Staff staff)
        {
            var result = 0;
            try
            {

                if ((CheckUserName(staff.Account)) > 0)
                {
                    return -1;
                }
                else
                {

                    result = dal.Register(staff);

                }

            }
            catch (Exception ex)
            {

            }
            return result;
        }



        public int Information(Staff staff)
        {
            var result = 0;
            try
            {
                result = dal.Information(staff);
            }
            catch (Exception ex)
            {

            }
            return result;
        }
        //0用户不存在 2密码正确
        public int UserLogin(Staff staff)
        {
            var result = 0;
            try
            {

                if (CheckStaff(staff.Account) < 1)
                {
                    return 0;
                }
                else
                {
                    if ((result = dal.UserLogin(staff)) > 0)
                    {
                        return 2;
                    }
                }

            }
            catch (Exception ex)
            {

            }
            return 1;
        }

        public int CheckStaff(string account)
        {
            var result = 0;
            try
            {
                result = dal.CheckStaff(@account);

            }
            catch (Exception ex)
            {

            }
            return result;
        }

        //验证用户名是否已存在
        public int CheckUserName(string account)
        {
            var result = 0;
            try
            {

                result = dal.CheckUserName(@account);
            }
            catch (Exception ex)
            {

            }
            return result;

        }

        public List<Staff> GetStaff()
        {
            var list = new List<Staff>();
            Staff_DAL bll = new Staff_DAL();
            try
            {
                list = bll.GetStaff();
                bll = null;
            }
            catch (Exception ex)
            {
                bll = null;
            }
            return list;
        }

        public List<Staff> GetStaffByDepartment(int departmentID)
        {
            var list = new List<Staff>();
            try
            {
                list = dal.GetStaffByDepartment(departmentID);
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
                list = dal.GetStaffIDByDepartment(depIDArr);
                dal = null;
            }
            catch (Exception ex)
            {
                dal = null;
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
            Staff_DAL dal = new Staff_DAL();
            try
            {
                list = dal.GetStaffIDByPost(postIDArr);
                dal = null;
            }
            catch (Exception ex)
            {
                dal = null;
            }
            return list;
        }

        public bool DeleteStaff(List<int> idArr)
        {
            var result = false;
            Staff_DAL dal = new Staff_DAL();
            try
            {
                result = dal.DeleteStaff(idArr);
                dal = null;
            }
            catch (Exception ex)
            {
                dal = null;
            }
            return result;
        }
    }
}


