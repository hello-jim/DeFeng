using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.DAL;

namespace DeFeng.BLL
{
    public class Announcement_BLL
    {
        public List<Announcement> LoadAnnouncement(int staffID)
        {
            var list = new List<Announcement>();
            Announcement_DAL dal = new Announcement_DAL();
            try
            {
                list= dal.LoadAnnouncement(staffID);
            }
            catch (Exception ex)
            {

            }
            return list;
        }
    }
}
