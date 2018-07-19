using Entity;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class AlarmDAL:BaseDal,IDAL
    {
        public int Add(object obj)
        {
            Alarm alarm = (Alarm)obj;

            MySqlParameter[] parms = new MySqlParameter[] {new MySqlParameter("@aType",alarm.Type),
                new MySqlParameter("@address", alarm.Address.ToString()),new MySqlParameter("@description",alarm.Description)};

            string cmdText = "insert into alarm (aType,address,description) values(@aType,@address,@description);";

            return MySqlHelper.ExecuteNonQuery(cmdText, parms);
            
        }

        public int Delete(object obj)
        {
            Alarm alarm = (Alarm)obj;
            MySqlParameter[] parms = new MySqlParameter[] { new MySqlParameter("@id",alarm.Id)};

            string cmdText = "delete from alarm where id=@id";

            return this.MySqlHelper.ExecuteNonQuery(cmdText,parms);
        }

        public int Modify(object oldObj, object newObj)
        {
            Alarm oldAlarm = (Alarm)oldObj;
            Alarm newAlarm = (Alarm)newObj;

            MySqlParameter[] parms = new MySqlParameter[] {
                new MySqlParameter("@oldId",oldAlarm.Id),
                new MySqlParameter("@aType", newAlarm.Type),
                new MySqlParameter("@address",newAlarm.Address),
                new MySqlParameter("@description",newAlarm.Description)};

            string cmdText = "update alarm set aType=@aType,address=@address,description=@description where id = @oldId";

            return this.MySqlHelper.ExecuteNonQuery(cmdText,parms);
        }

        public object GetObjById(string id)
        {
            int iId = int.Parse(id);

            Alarm alarm = new Alarm(iId);

            string cmdText = "select aType,address,description from alarm where id=@id";

            MySqlParameter[] parms = new MySqlParameter[] { new MySqlParameter("@id",alarm.Id)};

            MySqlDataReader reader = this.MySqlHelper.ExecuteReader(cmdText, parms);

            while(reader.Read()){
                alarm.Type = int.Parse(reader[0].ToString().Trim());
                alarm.Address = reader[1].ToString().Trim();
                alarm.Time = DateTime.Parse(reader[2].ToString());
                alarm.Description = reader[3].ToString().Trim();
            }
            this.mySqlHelper.CloseConn();
            return alarm;
        }

        public List<object> GetAllObjs()
        {
            List<object> objs = new List<object>();

            string cmdText = "select aType,address,description from alarm";

            MySqlParameter[] parms = new MySqlParameter[] { };

            MySqlDataReader reader = this.MySqlHelper.ExecuteReader(cmdText, parms);

            while (reader.Read())
            {
                Alarm alarm = new Alarm();
                alarm.Type = int.Parse(reader[0].ToString().Trim());
                alarm.Address = reader[1].ToString().Trim();
                alarm.Time = DateTime.Parse(reader[2].ToString().Trim());
                alarm.Description = reader[3].ToString().Trim();

                objs.Add(alarm);
            }
            this.mySqlHelper.CloseConn();

            return objs;
        }

        public List<object> GetObjsBySQL(string strSQL, MySqlParameter[] parms)
        {
            List<object> objs = new List<object>();

            MySqlDataReader reader = this.MySqlHelper.ExecuteReader(strSQL, parms);

            while (reader.Read())
            {
                Alarm alarm = new Alarm();
                alarm.Type = int.Parse(reader[0].ToString().Trim());
                alarm.Address = reader[1].ToString().Trim();
                alarm.Time = DateTime.Parse(reader[2].ToString().Trim());
                alarm.Description = reader[3].ToString().Trim();

                objs.Add(alarm);
            }
            this.mySqlHelper.CloseConn();

            return objs;
        }

        public int ExcuteSqlStr(string strSQL,MySqlParameter[] parms)
        {
            return this.MySqlHelper.ExecuteNonQuery(strSQL, parms);
        }
    }
}
