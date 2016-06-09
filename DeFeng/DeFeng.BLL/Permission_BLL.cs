using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.DAL;

namespace DeFeng.BLL
{
    public class Permission_BLL
    {
        Permission_DAL dal = new Permission_DAL();

        public List<Permission> LoadPermission()
        {
            var list = new List<Permission>();
            try
            {
                list = dal.LoadPermission();
            }
            catch (Exception ex)
            {

            }
            return list;
        }

        public List<Permission> GetPermissionByStaff(int staffID)
        {
            var list = new List<Permission>();
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
