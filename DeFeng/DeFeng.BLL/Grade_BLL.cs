using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.DAL;

namespace DeFeng.BLL
{
    public class Grade_BLL
    {
        Grade_DAL dal = new Grade_DAL();
        public List<Grade> LoadGrade()
        {
            List<Grade> list = new List<Grade>();
            try
            {
                list = dal.LoadGrade();
            }
            catch (Exception ex)
            {

            }
            return list;
        }
    }
}
