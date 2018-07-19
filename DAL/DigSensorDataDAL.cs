using Entity;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace DAL
{
    class DigSensorDataDAL : BaseDal, IDAL
    {
        public int Add(object obj)
        {
            DigSensorData data = (DigSensorData)obj;
            MySqlParameter[] parms = new MySqlParameter[] {
                new MySqlParameter("@name",data.Name),
                new MySqlParameter("@q",data.Q),
                new MySqlParameter("@dv",data.Dv)
            };
            string cmdText = "insert into digSensorData(name,q,dv) values (@name,@q,@dv);";
            return base.MySqlHelper.ExecuteNonQuery(cmdText, parms);
        }
        /// <summary>
        /// 删除指定传感器数据
        /// </summary>
        /// <param name="obj">传感器</param>
        /// <returns>受影响的行数</returns>
        public int Delete(object obj)
        {
            DigitalSensor sensor = (DigitalSensor)obj;
            MySqlParameter[] parms = new MySqlParameter[] {
                new MySqlParameter(",name",sensor.Name)
            };
            string cmdText = "delete from digSensorData where name=@name";
            return base.MySqlHelper.ExecuteNonQuery(cmdText, parms);
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
            throw new NotImplementedException();
        }

        public int Modify(object oldObj, object newObj)
        {
            throw new NotImplementedException();
        }
    }
}
