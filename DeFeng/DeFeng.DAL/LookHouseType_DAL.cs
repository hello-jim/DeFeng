﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.Common;

namespace DeFeng.DAL
{
    public class LookHouseType_DAL
    {
        string dbConn = CommonClass.GetSysConfig("DeFengDBConStr");
        public List<LookHouseType> LoadLookHouseType()
        {
            List<LookHouseType> list = new List<LookHouseType>();
            try
            {
                var sql = "SELECT [ID],[typeName] FROM LookHouseType";
                var result = SqlHelper.ExecuteReader(dbConn, System.Data.CommandType.Text, sql);
                while (result.Read())
                {
                    var obj = new LookHouseType();
                    obj.ID = Convert.ToInt32(result["ID"]);
                    obj.TypeName = Convert.ToString(result["typeName"]);
                    list.Add(obj);
                }
            }
            catch (Exception ex)
            {

            }
            return list;
        }
    }
}
