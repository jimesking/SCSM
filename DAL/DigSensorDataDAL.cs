using Entity;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace DAL
{
    public class DigSensorDataDAL : BaseDal, IDAL
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
            DigSensorData data = (DigSensorData)obj;
            
            MySqlParameter[] parms = new MySqlParameter[] {
                new MySqlParameter("id",data.Id)
            };
            string cmdText = "delete from digSensorData where id=@id";
            return base.MySqlHelper.ExecuteNonQuery(cmdText, parms);
        }

        public int ExcuteSqlStr(string strSQL, MySqlParameter[] parms)
        {
            return this.MySqlHelper.ExecuteNonQuery(strSQL, parms);
        }

        /// <summary>
        /// 不实现该方法
        /// </summary>
        /// <returns></returns>
        public List<object> GetAllObjs()
        {
            return null;
        }

        public object GetObjById(string id)
        {
            long LId;
            LId = long.Parse(id);
            DigSensorData digData = new DigSensorData();

            string cmdText = "select * from digSensorData where id=@id";

            MySqlParameter[] parms = new MySqlParameter[] { new MySqlParameter("@id", id) };

            MySqlDataReader reader = this.MySqlHelper.ExecuteReader(cmdText, parms);

            while (reader.Read())
            {
                digData.Id = long.Parse(id);    
                digData.Name = reader[0].ToString().Trim();
                digData.Time = DateTime.Parse(reader[1].ToString().Trim());
                digData.Q = bool.Parse(reader[2].ToString().Trim());
                digData.Dv = bool.Parse(reader[2].ToString().Trim());
            }
            this.mySqlHelper.CloseConn();

            return digData;
        }

        public List<object> GetObjsBySQL(string strSQL, MySqlParameter[] parms)
        {
            List<object> objs = new List<object>();

            MySqlDataReader reader = this.MySqlHelper.ExecuteReader(strSQL, parms);

            while (reader.Read())
            {
                DigSensorData digData = new DigSensorData();
                digData.Id = long.Parse(reader[0].ToString().Trim());
                digData.Name = reader[1].ToString().Trim();
                digData.Time = DateTime.Parse(reader[2].ToString().Trim());

                if ("0"==reader[3].ToString().Trim())
                    digData.Q = false;
                else
                    digData.Dv = true;

                objs.Add(digData);
            }
            this.mySqlHelper.CloseConn();

            return objs;
        }
        /// <summary>
        /// 不实现该方法，数据不允许修改
        /// </summary>
        /// <param name="oldObj"></param>
        /// <param name="newObj"></param>
        /// <returns></returns>
        public int Modify(object oldObj, object newObj)
        {
            return 0;
        }
    }
}
