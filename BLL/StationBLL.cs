using DAL;
using Entity;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class StationBLL:IBLL
    {
        public static StationsDAL dal = new StationsDAL();

        public int Add(object obj)
        {
            return dal.Add(obj);
        }

        public int Delete(object obj)
        {
            return dal.Add(obj);
        }

        public List<object> GetAllObjs()
        {
            return dal.GetAllObjs();
        }

        public object GetObjById(string id)
        {
            return dal.GetObjById(id);
        }

        public List<object> GetObjsBySQL(string strSQL, MySqlParameter[] parms)
        {
            return dal.GetObjsBySQL(strSQL, parms);
        }

        public int Modify(object oldObj, object newObj)
        {
            return dal.Modify(oldObj, newObj);
        }

        public int ExcuteSqlStr(string strSQL)
        {
            MySqlParameter[] parms = new MySqlParameter[] { };
            return dal.ExcuteSqlStr(strSQL, parms);
        }

        public List<Station> GetStationsByUser(User user)
        {
            return dal.GetStationsByUser(user);
        }
    }
}
