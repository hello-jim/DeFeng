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

        public List<Department> LoadDepartment()
        {
            List<Department> departmentList = new List<Department>();
            Department_DAL dal = new Department_DAL();
            try
            {
                departmentList = dal.LoadDepartment();
                dal = null;
            }
            catch (Exception ex)
            {
                dal = null;
                Log log = new Log();
                log.Msg = ex.StackTrace;
                log.Type = LogType.Error;
                GlobalQueue.LogGlobalQueue.Enqueue(log);
            }
            return departmentList;
        }

        public bool AddDepartment(Department department)
        {
            var result = false;
            Department_DAL dal = new Department_DAL();
            try
            {
                result = dal.AddDepartment(department);
                dal = null;
            }
            catch (Exception ex)
            {
                dal = null;
                Log log = new Log();
                log.Msg = ex.StackTrace;
                log.Type = LogType.Error;
                GlobalQueue.LogGlobalQueue.Enqueue(log);
            }
            return result;
        }

        public bool UpdateDepartment(Department department)
        {
            var result = false;
            Department_DAL dal = new Department_DAL();
            try
            {
                result = dal.UpdateDepartment(department);
                dal = null;
            }
            catch (Exception ex)
            {
                dal = null;
            }
            return result;
        }

        public bool DeleteDepartment(List<int> id)
        {
            var result = false;
            Department_DAL dal = new Department_DAL();
            try
            {
                result = dal.DeleteDepartment(id);
                dal = null;
            }
            catch (Exception ex)
            {
                dal = null;
            }
            return result;
        }
    }
}
