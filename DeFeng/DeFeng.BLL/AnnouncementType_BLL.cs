using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.DAL;

namespace DeFeng.BLL
{
    public class AnnouncementType_BLL
    {
        public List<AnnouncementType> LoadAnnouncementType()
        {
            List<AnnouncementType> list = new List<AnnouncementType>();
            try
            {
                AnnouncementType_DAL dal = new AnnouncementType_DAL();
                list = dal.LoadAnnouncementType();
            }
            catch (Exception ex)
            {

            }
            return list;
        }
    }
}
