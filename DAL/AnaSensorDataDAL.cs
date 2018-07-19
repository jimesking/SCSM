using Entity;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace DAL
{
    class AnaSensorDataDAL : BaseDal, IDAL
    {
        public int Add(object obj)
        {
            AnaSensorData data = (AnaSensorData)obj;

            MySqlParameter[] parms = new MySqlParameter[] {
                new MySqlParameter("@name",data.Name),
                new MySqlParameter("@q", data.Q),
                new MySqlParameter("@av",data.Av)};

            string cmdText = "insert into anaSensorData (name,q,av) values(@name,@q,@av);";

            return base.MySqlHelper.ExecuteNonQuery(cmdText, parms);
        }

        /// <summary>
        /// 删除数据库中指定传感器的数据
        /// </summary>
        /// <param name="obj">传感器</param>
        /// <returns删除数据库中指定传感器的数据></returns>
        public int Delete(object obj)
        {
            AnalogSensor sensor = (AnalogSensor)obj;

            MySqlParameter[] parms = new MySqlParameter[] {
                new MySqlParameter("@id",sensor.Name)
            };

            string cmdText = "delete from anaSensorData where name=@name";

            return base.MySqlHelper.ExecuteNonQuery(cmdText, parms);
        }

        public int ExcuteSqlStr(string strSQL, MySqlParameter[] parms)
        {
            return this.MySqlHelper.ExecuteNonQuery(strSQL, parms);
        }

        /// <summary>
        /// 获取所有传感器数据，不实现该方法
        /// </summary>
        /// <returns></returns>
        public List<object> GetAllObjs()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 获取某个传感器的所有数据
        /// </summary>
        /// <param name="id">传感器名称</param>
        /// <returns></returns>
        public object GetObjById(string id)
        {
            AnaSensorData anaData = new AnaSensorData();

            string cmdText = "select * from userInfo where name=@id";

            MySqlParameter[] parms = new MySqlParameter[] { new MySqlParameter("@id", id) };

            MySqlDataReader reader = this.MySqlHelper.ExecuteReader(cmdText, parms);

            while (reader.Read())
            {
                anaData.Name = reader[0].ToString().Trim();
                anaData.Time = DateTime.Parse(reader[1].ToString().Trim());
                anaData.Q = bool.Parse(reader[2].ToString().Trim());
                anaData.Av = double .Parse(reader[2].ToString().Trim());
            }
            this.mySqlHelper.CloseConn();

            return anaData;
        }

        public List<object> GetObjsBySQL(string strSQL, MySqlParameter[] parms)
        {

            List<object> objs = new List<object>();

            MySqlDataReader reader = this.MySqlHelper.ExecuteReader(strSQL, parms);

            while (reader.Read())
            {
                AnaSensorData anaData = new AnaSensorData();
                anaData.Name = reader[0].ToString().Trim();
                anaData.Time = DateTime.Parse(reader[1].ToString().Trim());
                anaData.Q = bool.Parse(reader[2].ToString().Trim());
                anaData.Av = double.Parse(reader[2].ToString().Trim());

                objs.Add(anaData);
            }
            this.mySqlHelper.CloseConn();

            return objs;
        }

        public int Modify(object oldObj, object newObj)
        {
            //此方法不需要实现
            throw new NotImplementedException();
        }
    }
}
