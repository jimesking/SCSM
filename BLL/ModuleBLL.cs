using DAL;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace BLL
{
    public class ModuleBLL:IBLL
    {
        private static ModuleDAL dal = new ModuleDAL();

        public int Add(object obj)
        {
            return dal.Add(obj);
        }

        public int Delete(object obj)
        {
            return dal.Delete(obj);
        }

        public int ExcuteSqlStr(string strSQL)
        {
            MySqlParameter[] parms = new MySqlParameter[] { };
            return dal.ExcuteSqlStr(strSQL,parms);
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
            return dal.GetObjsBySQL(strSQL,parms);
        }

        public int Modify(object oldObj, object newObj)
        {
            return dal.Modify(oldObj,newObj);
        }
    }
}
