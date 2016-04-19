using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.DAL;
using DeFeng.Model;
using DeFeng.Model.Global;
using DeFeng.Common;
namespace DeFeng.BLL
{
    public class House_BLL
    {

        /// <summary>
        /// 按条件筛选客源
        /// </summary>
        /// <param name="house"></param>
        /// <returns></returns>
        public List<House> SearchHouse(House house)
        {
            House_DAL dal = new House_DAL();
            List<House> houseList = new List<House>();
            try
            {
                var houseMaxCount = Convert.ToInt32(CommonClass.GetSysConfig("houseMaxCount"));
                houseList = dal.SearchHouse(house);
                houseList[0].TotalHouseCount = houseList[0].TotalHouseCount + ((house.PageIndex - 1) * houseMaxCount);
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.Msg = ex.StackTrace;
                log.Type = LogType.Error;
                GlobalQueue.LogGlobalQueue.Enqueue(log);
            }
            return houseList;
        }

        public bool AddHouse(House house)
        {
            House_DAL dal = new House_DAL();
            var result = false;
            try
            {
                result = dal.AddHouse(house);
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.Msg = ex.StackTrace;
                log.Type = LogType.Error;
                GlobalQueue.LogGlobalQueue.Enqueue(log);
            }
            return result;
        }

        public bool UpdateHouse(House house)
        {
            House_DAL dal = new House_DAL();
            var result = false;
            try
            {
                result = dal.UpdateHouse(house);
            }
            catch (Exception ex) { }
            return result;
        }

        public bool DeleteHouse(List<int> idArr)
        {
            House_DAL dal = new House_DAL();
            var result = false;
            try
            {
                result = dal.DeleteHouse(idArr);
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

        /// <summary>
        /// 房配客
        /// </summary>
        /// <returns></returns>
        public List<House> HouseDistributionCustomer(House house)
        {
            House_DAL dal = new House_DAL();
            List<House> houseList = new List<House>();
            try
            {
                houseList = dal.HouseDistributionCustomer(house);
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.Msg = ex.StackTrace;
                log.Type = LogType.Error;
                GlobalQueue.LogGlobalQueue.Enqueue(log);
            }
            return houseList;
        }
    }
}
