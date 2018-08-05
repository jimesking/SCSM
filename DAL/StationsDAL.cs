using Entity;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace DAL
{
    public class StationsDAL :BaseDal, IDAL
    {
        public int Add(object obj)
        {
            Station station = (Station)obj;

            MySqlParameter[] parms = new MySqlParameter[] {
                new MySqlParameter("@name",station.Name), 
                new MySqlParameter("@address", station.Address.ToString()),
                new MySqlParameter("@description",station.Description),
                new MySqlParameter("@moduleCount",station.ModuleCount)
            };

            string cmdText = "insert into station (name,address,description,moduleCount) values(@name,@address,@description,@moduleCount);";

            return base.MySqlHelper.ExecuteNonQuery(cmdText, parms);
        }

        public int Delete(object obj)
        {
            Station station = (Station)obj;

            MySqlParameter[] parms = new MySqlParameter[] {
                new MySqlParameter("@name",station.Name)
            };

            string cmdText = "delete from station where name=@name";

            return base.MySqlHelper.ExecuteNonQuery(cmdText, parms);
        }

        public int ExcuteSqlStr(string strSQL, MySqlParameter[] parms)
        {
            return this.MySqlHelper.ExecuteNonQuery(strSQL, parms);
        }

        public List<object> GetAllObjs()
        {
            List<object> objs = new List<object>();

            string cmdText = "select * from station";

            MySqlDataReader reader = this.MySqlHelper.ExecuteReader(cmdText, null);

            while (reader.Read())
            {
                Station station = new Station();
                station.Name = reader[0].ToString().Trim();
                station.Address = new SensorAddress(reader[1].ToString().Trim());
                station.Description = reader[2].ToString().Trim();
                station.ModuleCount = int.Parse(reader[3].ToString().Trim());
                objs.Add(station);
            }
            this.mySqlHelper.CloseConn();

            return objs;
        }

        public object GetObjById(string id)
        {
            Station station = new Station();

            string cmdText = "select * from station where name=@id";

            MySqlParameter[] parms = new MySqlParameter[] { new MySqlParameter("@id", id) };

            MySqlDataReader reader = this.MySqlHelper.ExecuteReader(cmdText, parms);

            while (reader.Read())
            {
                station.Name = reader[0].ToString().Trim();
                station.Address = new SensorAddress( reader[1].ToString().Trim());
                station.Description = reader[2].ToString().Trim();
                station.ModuleCount = int.Parse(reader[3].ToString().Trim());
            }
            this.mySqlHelper.CloseConn();

            return station;
        }

        public List<object> GetObjsBySQL(string strSQL, MySqlParameter[] parms)
        {
            List<object> objs = new List<object>();

            MySqlDataReader reader = this.MySqlHelper.ExecuteReader(strSQL, parms);

            while (reader.Read())
            {
                Station station = new Station();
                station.Name = reader[0].ToString().Trim();
                station.Address = new SensorAddress(reader[1].ToString().Trim());
                station.Description = reader[2].ToString().Trim();
                station.ModuleCount = int.Parse(reader[3].ToString().Trim());
                objs.Add(station);
            }
            this.mySqlHelper.CloseConn();

            return objs;
        }

        public int Modify(object oldObj, object newObj)
        {
            Station oldStation = (Station)oldObj;
            Station newStation = (Station)newObj;

            MySqlParameter[] parms = new MySqlParameter[] {
                new MySqlParameter("@oldName",oldStation.Name),
                new MySqlParameter("@newName", newStation.Name),
                new MySqlParameter("@address",newStation.Address.ToString()),
                new MySqlParameter("@decription",newStation.Description),
                new MySqlParameter("@moduleCount",newStation.ModuleCount)
            };

            string cmdText = "update station set name=@newName,address=@address,description=@decription,moduleCount=@moduleCount where name = @oldName";

            return base.MySqlHelper.ExecuteNonQuery(cmdText, parms);
        }
        public List<Station> GetStationsByUser(User user)
        {
            List<Station> stations = new List<Station>();

            SensorAddress address = new SensorAddress();
            address.UserName = user.Name;

            MySqlParameter[] parms = new MySqlParameter[] {
                new MySqlParameter("@address",user.Name+".%")
            };

            string cmdText = "select * from station where address like @address";

            MySqlDataReader reader = base.MySqlHelper.ExecuteReader(cmdText, parms);

            while (reader.Read())
            {
                Station station = new Station();
                station.Name = reader[0].ToString().Trim();
                station.Address = new SensorAddress( reader[1].ToString().Trim());
                station.Description = reader[2].ToString().Trim();

                stations.Add(station);
            }
            this.mySqlHelper.CloseConn();

            return stations;
        }
    }
}
