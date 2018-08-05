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
            Log log = (Log)obj;

            MySqlParameter[] parms = new MySqlParameter[] {new MySqlParameter("@aType",log.Type),
                new MySqlParameter("@address", log.Address.ToString()),new MySqlParameter("@description",log.Description)};

            //string cmdText = "insert into logInfo( (aType,address,description) values(@aType,@address,@description);";
            string cmdText = "insert into logInfo(aType,address,createTime,description) values (@aType,@address,Now(),@description);";
            return MySqlHelper.ExecuteNonQuery(cmdText, parms);
        }

        public int Delete(object obj)
        {
            Log log = (Log)obj;
            MySqlParameter[] parms = new MySqlParameter[] { new MySqlParameter("@id", log.Id) };

            string cmdText = "delete from logInfo where id=@id";

            return this.MySqlHelper.ExecuteNonQuery(cmdText, parms);
        }

        public int ExcuteSqlStr(string strSQL, MySqlParameter[] parms)
        {
            return this.MySqlHelper.ExecuteNonQuery(strSQL, parms);
        }

        public List<object> GetAllObjs()
        {
            List<object> objs = new List<object>();

            string cmdText = "select * from logInfo";

            MySqlParameter[] parms = new MySqlParameter[] { };

            MySqlDataReader reader = this.MySqlHelper.ExecuteReader(cmdText, parms);

            while (reader.Read())
            {
                Log log = new Log();
                log.Id = long.Parse(reader[0].ToString().Trim());
                log.Type = int.Parse(reader[1].ToString().Trim());
                log.Address = new SensorAddress( reader[2].ToString().Trim());
                log.Time = DateTime.Parse(reader[3].ToString().Trim());
                log.Description = reader[4].ToString().Trim();

                objs.Add(log);
            }
            this.mySqlHelper.CloseConn();

            return objs;
        }

        public object GetObjById(string id)
        {
            Log log = new Log();
            log.Id = long.Parse(id);

            string cmdText = "select * from logInfo where id = @id";

            MySqlParameter[] parms = new MySqlParameter[] {new MySqlParameter("id",log.Id) };

            MySqlDataReader reader = this.MySqlHelper.ExecuteReader(cmdText, parms);

            while (reader.Read())
            {
                log.Type = int.Parse(reader[1].ToString().Trim());
                log.Address = new SensorAddress(reader[2].ToString().Trim());
                log.Time = DateTime.Parse(reader[3].ToString().Trim());
                log.Description = reader[4].ToString().Trim();
            }
            this.mySqlHelper.CloseConn();

            return log;
        }

        public List<object> GetObjsBySQL(string strSQL, MySqlParameter[] parms)
        {
            List<object> objs = new List<object>();

            MySqlDataReader reader = this.MySqlHelper.ExecuteReader(strSQL, parms);

            while (reader.Read())
            {
                Log log = new Log();
                log.Id = long.Parse(reader[0].ToString().Trim());
                log.Type = int.Parse(reader[1].ToString().Trim());
                log.Address = new SensorAddress( reader[2].ToString().Trim());
                log.Time = DateTime.Parse(reader[3].ToString().Trim());
                log.Description = reader[4].ToString().Trim();

                objs.Add(log);
            }
            this.mySqlHelper.CloseConn();

            return objs;
        }
        /// <summary>
        /// 不实现该方法，日志无需修改
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
