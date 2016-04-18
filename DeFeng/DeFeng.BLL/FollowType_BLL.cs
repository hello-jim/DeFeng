using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.DAL;
using DeFeng.Model;

namespace DeFeng.BLL
{
    public class FollowType_BLL
    {
        FollowType_DAL dal = new FollowType_DAL();
        public List<FollowType> LoadFollowType()
        {
            var list = new List<FollowType>();
            try
            {
                list = dal.LoadFollowType();
            }
            catch (Exception ex)
            {

            }
            return list;
        }
    }
}
