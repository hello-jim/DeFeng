using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.DAL;
using DeFeng.Model.Global;
namespace DeFeng.BLL
{
    public class Department_BLL
    {
        Department_DAL dal = new Department_DAL();
        public List<Department> LoadDepartment()
        {
            List<Department> departmentList = new List<Department>();
            try
            {
                departmentList = dal.LoadDepartment();
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.Msg = ex.StackTrace;
                log.Type = LogType.Error;
                GlobalQueue.LogGlobalQueue.Enqueue(log);
            }
            return departmentList;
        }


    }
}
