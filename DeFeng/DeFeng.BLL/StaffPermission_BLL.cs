using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.DAL;

namespace DeFeng.BLL
{
    public class StaffPermission_BLL
    {
        StaffPermission_DAL dal = new StaffPermission_DAL();
        public bool AddStaffPermission(int staffID, int loginStaffID, List<int> permissionIDList)
        {
            var result = false;
            try
            {
                result = dal.AddStaffPermission(staffID, loginStaffID, permissionIDList);
            }
            catch (Exception ex)
            {


            }
            return result;
        }

        public List<int> GetPermissionByStaff(int staffID)
        {
            var list = new List<int>();
            try
            {
                list = dal.GetPermissionByStaff(staffID);
            }
            catch (Exception ex)
            {

            }
            return list;
        }
    }
}
