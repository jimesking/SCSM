using Entity;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace DAL
{
    public class DigSensorDAL : BaseDal, IDAL
    {
        public int Add(object obj)
        {
            DigitalSensor sensor = (DigitalSensor)obj;

            MySqlParameter[] parms = new MySqlParameter[] {
                new MySqlParameter("@name",sensor.Name),
                new MySqlParameter("@address", sensor.Address.ToString()),
                new MySqlParameter("@description",sensor.Description),
                new MySqlParameter("@aInterval",sensor.Interval)
            };

            string cmdText = "insert into digitalSnesor(name, address, description, aInterval) values(@name, @address, @description, @aInterval);";

            return MySqlHelper.ExecuteNonQuery(cmdText, parms);
        }

        public int Delete(object obj)
        {
            DigitalSensor sensor = (DigitalSensor)obj;
            MySqlParameter[] parms = new MySqlParameter[] { new MySqlParameter("@id", sensor.Name) };

            string cmdText = "delete from digitalSnesor where name=@name";

            return this.MySqlHelper.ExecuteNonQuery(cmdText, parms);
        }

        public int ExcuteSqlStr(string strSQL, MySqlParameter[] parms)
        {
            return this.MySqlHelper.ExecuteNonQuery(strSQL, parms);
        }

        public List<object> GetAllObjs()
        {
            List<object> objs = new List<object>();

            string cmdText = "select * from digitalSnesor";

            MySqlParameter[] parms = new MySqlParameter[] { };

            MySqlDataReader reader = this.MySqlHelper.ExecuteReader(cmdText, parms);

            while (reader.Read())
            {
                DigitalSensor sensor = new DigitalSensor();
                sensor.Name = reader[0].ToString().Trim();
                sensor.Address = new SensorAddress(reader[1].ToString().Trim());
                sensor.Description = reader[2].ToString().Trim();

                sensor.Interval = int.Parse(reader[2].ToString().Trim());
                objs.Add(sensor);
            }
            this.mySqlHelper.CloseConn();

            return objs;
        }

        public object GetObjById(string id)
        {
            DigitalSensor anaSensor = new DigitalSensor();

            string cmdText = "select * from digitalSnesor where name=@id";

            MySqlParameter[] parms = new MySqlParameter[] { new MySqlParameter("@id", id) };

            MySqlDataReader reader = this.MySqlHelper.ExecuteReader(cmdText, parms);

            while (reader.Read())
            {
                anaSensor.Name = reader[0].ToString().Trim();
                anaSensor.Address = new SensorAddress(reader[1].ToString().Trim());
                anaSensor.Description = reader[2].ToString();
                anaSensor.Interval = int.Parse(reader[3].ToString().Trim());
            }
            this.mySqlHelper.CloseConn();
            return anaSensor;
        }

        public List<object> GetObjsBySQL(string strSQL, MySqlParameter[] parms)
        {
            List<object> objs = new List<object>();

            MySqlDataReader reader = this.MySqlHelper.ExecuteReader(strSQL, parms);

            while (reader.Read())
            {
                DigitalSensor anaSensor = new DigitalSensor();

                anaSensor.Name = reader[0].ToString().Trim();
                anaSensor.Address = new SensorAddress(reader[1].ToString().Trim());
                anaSensor.Description = reader[2].ToString();
                anaSensor.Interval = int.Parse(reader[3].ToString().Trim());

                objs.Add(anaSensor);
            }
            this.mySqlHelper.CloseConn();

            return objs;
        }

        public int Modify(object oldObj, object newObj)
        {
            DigitalSensor oldSensor = (DigitalSensor)oldObj;
            DigitalSensor newSensor = (DigitalSensor)newObj;

            MySqlParameter[] parms = new MySqlParameter[] {
                new MySqlParameter("@name",oldSensor.Name),

                new MySqlParameter("@address",oldSensor.Address.ToString()),
                new MySqlParameter("@description", oldSensor.Description),
                new MySqlParameter("@interval",oldSensor.Interval) };

            string cmdText = "update digitalSnesor set address=@address,description=@description,interval=@interval where name = @name";

            return this.MySqlHelper.ExecuteNonQuery(cmdText, parms);
        }
    }
}
