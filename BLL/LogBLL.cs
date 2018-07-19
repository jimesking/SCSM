using DAL;
using Entity;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class LogBLL : IBLL
    {
        private static LogDAL logDal = new LogDAL();
        public int Add(object obj)
        {
            return logDal.Add(obj);
        }

        public int Delete(object obj)
        {
            return logDal.Delete(obj);
        }

        public List<object> GetAllObjs()
        {
            return logDal.GetAllObjs();
        }

        public object GetObjById(string id)
        {
            return logDal.GetObjById(id);
        }

        public List<object> GetObjsBySQL(string strSQL, MySqlParameter[] parms)
        {
            return logDal.GetObjsBySQL(strSQL,parms);
        }

        public int Modify(object oldObj, object newObj)
        {
            return logDal.Modify(oldObj,newObj);
        }

        public int ExcuteSqlStr(string strSQL)
        {
            MySqlParameter[] parms = new MySqlParameter[] { };
            return logDal.ExcuteSqlStr(strSQL,parms);
        }
    }
}
