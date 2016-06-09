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
        public bool AddStaffPermission(int staffID, int createStaffID, List<int> permissionIDList)
        {
            var result = false;
            try
            {
                result= dal.AddStaffPermission(staffID,createStaffID,permissionIDList);
            }
            catch (Exception ex)
            {

                 
            }
            return result;
        }
    }
}
