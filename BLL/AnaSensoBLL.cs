using DAL;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace BLL
{
    public class AnaSensorBLL:IBLL
    {
        public static AnaSensorDAL dal = new AnaSensorDAL();

        public int ExcuteSqlStr(string strsql) {
            MySqlParameter[] parms = new MySqlParameter[] { };
            return dal.ExcuteSqlStr(strsql, parms);
        }

        public int Add(object obj)
        {
            return dal.Add(obj);
        }

        public int Delete(object obj)
        {
            return dal.Delete(obj);
        }

        public int Modify(object oldObj, object newObj)
        {
            return dal.Modify(oldObj,newObj);
        }

        public object GetObjById(string id)
        {
            return dal.GetObjById(id);
        }

        public List<object> GetAllObjs()
        {
            return dal.GetAllObjs();
        }

        public List<object> GetObjsBySQL(string strSQL, MySqlParameter[] parms)
        {
            return dal.GetObjsBySQL(strSQL,parms);
        }
    }
}
