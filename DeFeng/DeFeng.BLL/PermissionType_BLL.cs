using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.DAL;

namespace DeFeng.BLL
{
   
    public class PermissionType_BLL
    {
        PermissionType_DAL dal = new PermissionType_DAL();

        public List<PermissionType> GetPermissionType()
        {
            var list = new List<PermissionType>();
            try
            {
                list = dal.GetPermissionType();
            }
            catch (Exception ex)
            {

            }
            return list;
        }
    }
}
