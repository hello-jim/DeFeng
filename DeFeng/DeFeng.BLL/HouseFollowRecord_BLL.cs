using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.DAL;

namespace DeFeng.BLL
{
    public class HouseFollowRecord_BLL
    {

        HouseFollowRecord_DAL dal = new HouseFollowRecord_DAL();
        public List<HouseFollowRecord> LoadHouseFollowRecord(int houseID)
        {
            List<HouseFollowRecord> list = new List<HouseFollowRecord>();
            try
            {
                list = dal.LoadHouseFollowRecord(houseID);
            }
            catch (Exception ex)
            {

            }
            return list;
        }

        public bool AddHouseFollowRecord(HouseFollowRecord record)
        {
            var result = false;
            try
            {
                result = dal.AddHouseFollowRecord(record);
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public bool DeleteHouseFollowRecord(int id)
        {
            var result = false;
            try
            {
                result = dal.DeleteHouseFollowRecord(id);
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public bool UpdateHouseFollowRecord(HouseFollowRecord record)
        {
            var result = false;
            try
            {
                result = dal.UpdateHouseFollowRecord(record);
            }
            catch (Exception ex)
            {

            }
            return result;
        }
    }
}
