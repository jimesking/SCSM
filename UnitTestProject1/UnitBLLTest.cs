using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using Entity;
using DAL;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace UnitTestProject
{
    [TestClass]
    public class UnitBLLTest
    {
        [TestMethod]
        public void TestAlarmBLL()
        {

            AlarmBLL bll = new AlarmBLL(new AlarmDAL());

            Alarm alarm = new Alarm(2, "testAddress", "dectription33333");
            bll.Add(alarm);

            bll.Delete(alarm);

            bll.Modify(new Alarm(4), new Alarm(2, "modify address", ""));

            int a = 2;
            Alarm alarm2 = (Alarm)bll.GetObjById(a.ToString());

            List<object> objs1 = bll.GetAllObjs();

            List<object> objs2 = bll.GetObjsBySQL("select * from alarm", null);

            int b = bll.ExcuteSqlStr("select * from alarm where id = 1");
        }
            
        [TestMethod]
        public void TestAnaSensorBLL() {
            AnaSensorBLL bll = new AnaSensorBLL(new AnaSensorDAL());

            AnalogSensor anaSensor = new AnalogSensor();
            anaSensor.Address = new SensorAddress("userA.stationA.moduleA.7");
            anaSensor.Name = "U2CSP020AM";
            anaSensor.Md = 0;
            anaSensor.Mu = 110;
            anaSensor.Ut = "MPa";
            anaSensor.Format = "8.2";
            bll.Add(anaSensor);

            AnalogSensor anaSensorB = new AnalogSensor();
            anaSensorB.Name = "U2CSP008AM";
            bll.Delete(anaSensorB);

            AnalogSensor anaSensorOld = new AnalogSensor();
            anaSensorOld.Name = "U2CSP001AM";
            AnalogSensor anaSensorNew = new AnalogSensor();
            anaSensorNew.Name = "U2CSP001AM";
            anaSensorNew.Address = new SensorAddress("aa.bb");
            anaSensorNew.Mu = 15;
            bll.Modify(anaSensorOld, anaSensorNew);

            AnalogSensor analogSensorC = (AnalogSensor)bll.GetObjById("U2CSP001AM");

            List<object> list1 =  bll.GetAllObjs();

            List<object> list2 = bll.GetObjsBySQL("select * from analogSensor where name = 'U2CSP001AM'", null);

        }

        [TestMethod]
        public void TestAnaSensorDataBLL() {
            AnaSensorDataBLL bll = new AnaSensorDataBLL(new AnaSensorDataDAL());

            AnaSensorData data1 = new AnaSensorData(0,"U2SYS001AM",false,1.2);
            bll.Add(data1);

            AnaSensorData data2 = new AnaSensorData();
            data2.Id = 2;
            bll.Delete(data2);

            AnaSensorData data3 = new AnaSensorData();
            data3.Id = 1;          
            AnaSensorData data4 = new AnaSensorData();
            data4.Id = 3;
            data4.Av = 1.5;
            bll.Modify(data1,data4);

            AnaSensorData data5 = (AnaSensorData)bll.GetObjById(1.ToString());

            List<object> objs2 = bll.GetAllObjs();

            string strSQL = "select * from anaSensorData";
            MySqlParameter[] parms = new MySqlParameter[] {
                //new MySqlParameter("","")
            };
            List<object> objs1 = bll.GetObjsBySQL(strSQL, parms);

        }

        [TestMethod]
        public void TestDigSensorBLL() {
            DigSensorBLL bll = new DigSensorBLL(new DigSensorDAL());

            DigitalSensor sensor1 = new DigitalSensor("U2CCV004DM","AA.BB","description1",61);
            DigitalSensor sensor2 = new DigitalSensor("U2CCV005DM", "AA.BB", "description1", 61);
            //bll.Add(sensor1);
            //bll.Add(sensor2);

            bll.Delete(sensor1);

            DigitalSensor sensor3 = new DigitalSensor("U2CCV002DM", "AA.BB.CC", "description1", 61);

            bll.Modify(sensor2, sensor3);

            DigitalSensor sensor4 = (DigitalSensor)bll.GetObjById("U2CCV002DM");

            int ret = bll.ExcuteSqlStr("select * from digitalSensor");

            List<object> list1 = bll.GetAllObjs();

            List<object> list2 = bll.GetObjsBySQL("select * from digitalSensor", null);
            
        }

        [TestMethod]
        public void TestDigSensorDataBLL() {
            DigSensorDataBLL bll = new DigSensorDataBLL(new DigSensorDataDAL());

            DigSensorData data1 = new DigSensorData(0, "U2CCV001DM", false, true);
            bll.Add(data1);

            DigSensorData data2 = new DigSensorData();
            data2.Id = 1;
            bll.Delete(data2);

            DigSensorData data3 = new DigSensorData(1, "U2CCV001DM", false, true);
            DigSensorData data4 = new DigSensorData(1, "U2CCV001DM", false, false);
            bll.Modify(data3, data4);

            DigSensorData data5 = (DigSensorData)bll.GetObjById(1.ToString());

            int a = bll.ExcuteSqlStr("select * from digSensorData");

            List<object> list1 =  bll.GetAllObjs();

            List<object> list2 = bll.GetObjsBySQL("select * from digSensorData", null);           

        }

        [TestMethod]
        public void TestLogBLL() {
            LogBLL bll = new LogBLL(new LogDAL());

            Log log1 = new Log(0, 1, new SensorAddress("aa.bb"), "description1");
            bll.Add(log1);

            Log log2 = new Log(0, 1, new SensorAddress("aa.bb"), "description1");
            bll.Delete(log2);

            Log log3 = new Log(0, 1, new SensorAddress("aa.bb"), "description1");
            Log log4 = new Log(0, 1, new SensorAddress("aa.bb.cc"), "description1mm");
            bll.Modify(log3, log4);

            Log log5 = (Log)bll.GetObjById(1.ToString());

            List<object> list1 = bll.GetAllObjs();

            List<object> list2 = bll.GetObjsBySQL("select * from logInfo",null);

            int ret = bll.ExcuteSqlStr("select * from logInfo");
        }

        [TestMethod]
        public void TestModuleBLL() {
            ModuleBLL bll = new ModuleBLL(new ModuleDAL());

            Module module11 = new Module("stationA",new SensorAddress("aa.bb"),"des1",2,3);
            bll.Add(module11);

            Module module12 = new Module("stationB", new SensorAddress("aa.bb"), "des1", 2, 3);
            bll.Delete(module12);

            Module module13 = new Module("stationA", new SensorAddress("aa.bb"), "des1", 2, 3);
            Module module14= new Module("stationA", new SensorAddress("aa.CC"), "des1", 2, 3);
            bll.Modify(module13, module14);

            int ret = bll.ExcuteSqlStr("select * from module");

            List<object> list1 = bll.GetAllObjs();

            List<object> list2 = bll.GetObjsBySQL("select * from module", null);
            
        }

        [TestMethod]
        public void TestStationBLL() {
            StationBLL bll = new StationBLL(new StationsDAL());

            Station station1 = new Station("stationA1",new SensorAddress("aa.bb1"),"description",3);

            bll.Add(station1);

            bll.Delete(station1);

            Station station2 = new Station("stationB3", new SensorAddress("aa.bb7"), "description", 3);
            Station station3 = new Station("stationB3", new SensorAddress("aa.bb8"), "description", 3);

            bll.Add(station2);
            bll.Modify(station2,station3);

            bll.Delete(station3);
            Station station4 = (Station)bll.GetObjById(station3.Name);

            bll.ExcuteSqlStr("select * from station");

            List<object> list1 = bll.GetAllObjs();

            List<object> list2 = bll.GetObjsBySQL("select * from station", null);

            List<Station> list3 = bll.GetStationsByUser(new User("aa"));
        }

        [TestMethod]
        public void TestUiInformationBLL() {
            UiInformationBLL bll = new UiInformationBLL(new UiInformationDAL());

            UIInfomation info1 = new UIInfomation(0, "user1", "caption1", "title1");

            bll.Add(info1);

            bll.Delete(info1);

            UIInfomation info2 = new UIInfomation(0, "user2", "caption2", "title2");

            bll.Add(info1);
            bll.Modify(info1, info2);

            bll.GetObjById(1.ToString());

            bll.ExcuteSqlStr("select * from UIInfomation");

            List<object> list1 = bll.GetAllObjs();

            List<object> list2 = bll.GetObjsBySQL("select * from UIInfomation", null);

            User user = new User("aa");
            List<UIInfomation> uiInfos = bll.GetUiInformationsByUser(user);

        }

        [TestMethod]
        public void TestUserBLL() {
            UserBLL bll = new UserBLL(new UserDAL());
            User user1 = new User("user1","1111",1);
            bll.Add(user1);

            bll.Delete(user1);

            bll.Add(user1);

            User user2 = new User("user2", "2222", 2);
            bll.Modify(user1, user2);

            bll.GetObjById(user2.Name);

            int ret = bll.ExcuteSqlStr("select * from userInfo");

            List<object> objs1 = bll.GetAllObjs();

            List<object> objs2 = bll.GetObjsBySQL("select * from userInfo",null);

            User user = bll.GetUserByNameAndPassword("aaaa", "1111");
        }
    }
}
