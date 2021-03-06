﻿using Entity;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace DAL
{
    public class AnaSensorDAL :BaseDal, IDAL
    {
        public int Add(object obj)
        {
            AnalogSensor anaSensor = (AnalogSensor)obj;

            MySqlParameter[] parms = new MySqlParameter[] {
                new MySqlParameter("@name", anaSensor.Name),
                new MySqlParameter("@address",anaSensor.Address.ToString()),
                new MySqlParameter("@description",anaSensor.Description),
                new MySqlParameter("@interval",anaSensor.Interval),
                new MySqlParameter("@format",anaSensor.Format),

                new MySqlParameter("@md",anaSensor.Md),
                new MySqlParameter("@mu",anaSensor.Mu),
                new MySqlParameter("@ut",anaSensor.Ut),

                new MySqlParameter("@h4l",anaSensor.H4l),
                new MySqlParameter("@h3l",anaSensor.H3l),
                new MySqlParameter("@h2l",anaSensor.H2l),
                new MySqlParameter("@h1l",anaSensor.H1l),

                new MySqlParameter("@l1l",anaSensor.L1l),
                new MySqlParameter("@l2l",anaSensor.L2l),
                new MySqlParameter("@l3l",anaSensor.L3l),
                new MySqlParameter("@l4l",anaSensor.L4l)
            };

            string cmdText = "insert into analogSensor (name,address,description,aInterval,aFormat,aMd,aMu,ut,h4l,h3l,h2l,h1l,l1l,l2l,l3l,l4l)"+
                " values (@name,@address,@description,@interval,@format,@md,@mu,@ut,@h4l,@h3l,@h2l,@h1l,@l1l,@l2l,@l3l,@l4l);";

            return base.MySqlHelper.ExecuteNonQuery(cmdText, parms);
        }

        public int Delete(object obj)
        {
            AnalogSensor sensor = (AnalogSensor)obj;

            MySqlParameter[] parms = new MySqlParameter[] {
                new MySqlParameter("@name",sensor.Name)
            };

            string cmdText = "delete from userInfo where name=@name";

            return base.MySqlHelper.ExecuteNonQuery(cmdText, parms);
        }

        public int ExcuteSqlStr(string strSQL, MySqlParameter[] parms)
        {
            return this.MySqlHelper.ExecuteNonQuery(strSQL, parms);
        }

        public List<object> GetAllObjs()
        {
            List<object> objs = new List<object>();

            string cmdText = "select * from analogSensor";

            MySqlParameter[] parms = new MySqlParameter[] { };

            MySqlDataReader reader = this.MySqlHelper.ExecuteReader(cmdText, parms);

            while (reader.Read())
            {
                AnalogSensor sensor = new AnalogSensor();
                sensor.Name = reader[0].ToString().Trim();
                sensor.Address = new SensorAddress( reader[1].ToString().Trim());
                sensor.Description = reader[2].ToString().Trim();

                sensor.Interval = int.Parse(reader[3].ToString().Trim());
                sensor.Format = reader[4].ToString().Trim();

                sensor.Md = double.Parse(reader[5].ToString().Trim());
                sensor.Mu = double.Parse(reader[6].ToString().Trim());
                sensor.Ut = reader[7].ToString().Trim();

                sensor.H4l = double.Parse(reader[8].ToString().Trim());
                sensor.H3l = double.Parse(reader[9].ToString().Trim());
                sensor.H2l = double.Parse(reader[10].ToString().Trim());
                sensor.H1l = double.Parse(reader[11].ToString().Trim());

                sensor.L1l = double.Parse(reader[12].ToString().Trim());
                sensor.L2l = double.Parse(reader[13].ToString().Trim());
                sensor.L3l = double.Parse(reader[14].ToString().Trim());
                sensor.L4l = double.Parse(reader[15].ToString().Trim());

                objs.Add(sensor);
            }
            this.mySqlHelper.CloseConn();

            return objs;
        }

        public object GetObjById(string id)
        {

            AnalogSensor anaSensor = new AnalogSensor();

            string cmdText = "select * from analogSensor where name=@id";

            MySqlParameter[] parms = new MySqlParameter[] { new MySqlParameter("@id", id) };

            MySqlDataReader reader = this.MySqlHelper.ExecuteReader(cmdText, parms);

            while (reader.Read())
            {
                anaSensor.Name = reader[0].ToString().Trim();
                anaSensor.Address = new SensorAddress( reader[1].ToString().Trim());
                anaSensor.Description = reader[2].ToString();
                anaSensor.Interval = int.Parse(reader[3].ToString().Trim());

                anaSensor.Format = reader[4].ToString().Trim();

                anaSensor.Md = double.Parse(reader[5].ToString().Trim());
                anaSensor.Mu = double.Parse(reader[6].ToString().Trim());

                anaSensor.Ut = reader[7].ToString().Trim();

                anaSensor.H4l = double.Parse(reader[8].ToString().Trim());
                anaSensor.H3l = double.Parse(reader[9].ToString().Trim());
                anaSensor.H2l = double.Parse(reader[10].ToString().Trim());
                anaSensor.H1l = double.Parse(reader[11].ToString().Trim());

                anaSensor.L1l = double.Parse(reader[12].ToString().Trim());
                anaSensor.L2l = double.Parse(reader[13].ToString().Trim());
                anaSensor.L3l = double.Parse(reader[14].ToString().Trim());
                anaSensor.L4l = double.Parse(reader[15].ToString().Trim());
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
                AnalogSensor anaSensor = new AnalogSensor();

                anaSensor.Name = reader[0].ToString().Trim();
                anaSensor.Address = new SensorAddress(reader[1].ToString().Trim());
                anaSensor.Description = reader[2].ToString();
                anaSensor.Interval = int.Parse(reader[3].ToString().Trim());

                anaSensor.Format = reader[4].ToString().Trim();

                anaSensor.Md = double.Parse(reader[5].ToString().Trim());
                anaSensor.Mu = double.Parse(reader[6].ToString().Trim());

                anaSensor.Ut = reader[7].ToString().Trim();

                anaSensor.H4l = double.Parse(reader[8].ToString().Trim());
                anaSensor.H3l = double.Parse(reader[9].ToString().Trim());
                anaSensor.H2l = double.Parse(reader[10].ToString().Trim());
                anaSensor.H1l = double.Parse(reader[11].ToString().Trim());

                anaSensor.L1l = double.Parse(reader[12].ToString().Trim());
                anaSensor.L2l = double.Parse(reader[13].ToString().Trim());
                anaSensor.L3l = double.Parse(reader[14].ToString().Trim());
                anaSensor.L4l = double.Parse(reader[15].ToString().Trim());

                objs.Add(anaSensor);
            }
            this.mySqlHelper.CloseConn();

            return objs;
        }

        public int Modify(object oldObj, object newObj)
        {
            try
            {
                AnalogSensor oldSensor = (AnalogSensor)oldObj;
                AnalogSensor newSensor = (AnalogSensor)newObj;

                MySqlParameter[] parms = new MySqlParameter[] {
                new MySqlParameter("@name",oldSensor.Name),

                new MySqlParameter("@address",newSensor.Address.ToString()),
                new MySqlParameter("@description", newSensor.Description),
                new MySqlParameter("@interval",newSensor.Interval),

                new MySqlParameter("@format",newSensor.Format),

                new MySqlParameter("@md", newSensor.Md),
                new MySqlParameter("@mu", newSensor.Mu),

                new MySqlParameter("@ut", newSensor.Ut),

                new MySqlParameter("@H4l", newSensor.H4l),
                new MySqlParameter("@H3l", newSensor.H3l),
                new MySqlParameter("@H2l", newSensor.H2l),
                new MySqlParameter("@H1l", newSensor.H1l),

                new MySqlParameter("@L1l", newSensor.L1l),
                new MySqlParameter("@L2l", newSensor.L2l),
                new MySqlParameter("@L3l", newSensor.L3l),
                new MySqlParameter("@L4l", newSensor.L4l)};

                string cmdText = "update analogSensor set address=@address,description=@description,aInterval=@interval" +
                    ",aFormat=@format,aMd=@md,aMu=@mu,ut=@ut,h4l=@H4l,h3l=@H3l,h2l=@H2l,h1l=@H1l," +
                    "l1l=@L1l,l2l=@L2l,l3l=@L3l,l4l=@L4l where name = @name;";

                return this.MySqlHelper.ExecuteNonQuery(cmdText, parms);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
    }
}
