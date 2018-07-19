using Entity;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace DAL
{
    public class LogDAL : BaseDal, IDAL
    {
        public int Add(object obj)
        {
            return 0 ;
        }

        public int Delete(object obj)
        {
            return 0;
        }

        public int ExcuteSqlStr(string strSQL, MySqlParameter[] parms)
        {
            throw new NotImplementedException();
        }

        public List<object> GetAllObjs()
        {
            throw new NotImplementedException();
        }

        public object GetObjById(string id)
        {
            throw new NotImplementedException();
        }

        public List<object> GetObjsBySQL(string strSQL, MySqlParameter[] parms)
        {
            List<object> logs = new List<object>();
            for (int i = 0; i < 20; i++)
            {
                Log log = new Log( i, new SensorAddress(), DateTime.Now, "description" + i.ToString());
                log.Id = i;
                logs.Add(log);
            }

            return logs;
        }

        public int Modify(object oldObj, object newObj)
        {
            //此方法不需要实现
            throw new NotImplementedException();
        }
    }
}
