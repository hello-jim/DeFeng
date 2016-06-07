using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.DAL;
namespace DeFeng.BLL
{
    public class Attachment_BLL
    {
        Attachment_DAL dal = new Attachment_DAL();
        public int AddAttachment(Attachment attachment)
        {
            var id = 0;
            try
            {
                id = dal.AddAttachment(attachment);
            }
            catch (Exception ex)
            {

            }
            return id;
        }

        public List<Attachment> LoadAttachment(AttachmentType type,int ofID)
        {
            var list = new List<Attachment>();
            try
            {
                list = dal.LoadAttachment(type, ofID);
            }
            catch (Exception ex)
            {

            }
            return list;
        }
    }
}
