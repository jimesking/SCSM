using Entity;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace DAL
{
    public class ModuleDAL : BaseDal, IDAL
    {
        public int Add(object obj)
        {
            Module module = (Module)obj;

            MySqlParameter[] parms = new MySqlParameter[] {
                new MySqlParameter("@name",module.Name),
                new MySqlParameter("@address", module.Address.ToString()),
                new MySqlParameter("@description",module.Description),
                new MySqlParameter("@anaSensorCount", module.AnaSensorCount),
                new MySqlParameter("@digSensorCount",module.DigSensorCount)
            };

            string cmdText = "insert into module (name,address,description,anaSensorCount,digSensorCount) values(@name,@address,@description,@anaSensorCount,@digSensorCount);";

            return MySqlHelper.ExecuteNonQuery(cmdText, parms);
        }

        public int Delete(object obj)
        {
            Module module = (Module)obj;
            MySqlParameter[] parms = new MySqlParameter[] { new MySqlParameter("@address", module.Address) };

            string cmdText = "delete from module where address=@address";

            return this.MySqlHelper.ExecuteNonQuery(cmdText, parms);
        }

        public int ExcuteSqlStr(string strSQL, MySqlParameter[] parms)
        {
            return this.MySqlHelper.ExecuteNonQuery(strSQL, parms);
        }

        public List<object> GetAllObjs()
        {
            List<object> objs = new List<object>();

            string cmdText = "select * from module";

            MySqlParameter[] parms = new MySqlParameter[] { };

            MySqlDataReader reader = this.MySqlHelper.ExecuteReader(cmdText, parms);

            while (reader.Read())
            {
                Module module = new Module();
                module.Name = reader[0].ToString().Trim();
                module.Address = new SensorAddress( reader[1].ToString().Trim());
                module.Description = reader[2].ToString().Trim();
                module.AnaSensorCount = int.Parse(reader[3].ToString().Trim());
                module.DigSensorCount = int.Parse(reader[4].ToString().Trim());

                objs.Add(module);
            }
            this.mySqlHelper.CloseConn();

            return objs;
        }
        /// <summary>
        /// 模块中只有地址是唯一的，地址做为ID使用
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public object GetObjById(string id)
        {

            Module module = new Module();

            string cmdText = "select * from module where address=@id";

            MySqlParameter[] parms = new MySqlParameter[] { new MySqlParameter("@address", module.Address.ToString()) };

            MySqlDataReader reader = this.MySqlHelper.ExecuteReader(cmdText, parms);

            while (reader.Read())
            {
                module.Name = reader[0].ToString().Trim();
                module.Address = new SensorAddress( reader[1].ToString().Trim());
                module.Description = reader[2].ToString();
                module.AnaSensorCount = int.Parse(reader[3].ToString().Trim());
                module.DigSensorCount = int.Parse(reader[4].ToString().Trim());
            }
            this.mySqlHelper.CloseConn();
            return module;
        }

        public List<object> GetObjsBySQL(string strSQL, MySqlParameter[] parms)
        {
            List<object> objs = new List<object>();

            MySqlDataReader reader = this.MySqlHelper.ExecuteReader(strSQL, parms);

            while (reader.Read())
            {
                Module module = new Module();
                module.Name = reader[0].ToString().Trim();
                module.Address = new SensorAddress( reader[1].ToString().Trim());
                module.Description = reader[2].ToString().Trim();
                module.AnaSensorCount = int.Parse(reader[3].ToString().Trim());
                module.DigSensorCount = int.Parse(reader[4].ToString().Trim());
                objs.Add(module);
            }
            this.mySqlHelper.CloseConn();

            return objs;
        }

        public int Modify(object oldObj, object newObj)
        {
            Module oldModule = (Module)oldObj;
            Module newModule = (Module)newObj;

            MySqlParameter[] parms = new MySqlParameter[] {
                new MySqlParameter("@oldAddress",oldModule.Address.ToString()),
                new MySqlParameter("@name", newModule.Name),
                new MySqlParameter("@address",newModule.Address.ToString()),
                new MySqlParameter("@description",newModule.Description),
                new MySqlParameter("@anaSensorCount",newModule.AnaSensorCount),
                new MySqlParameter("@digSensorCount",newModule.DigSensorCount)
            };

            string cmdText = "update module set name=@name,address=@address,description=@description,anaSensorCount=@anaSensorCount ,digSensorCount=@digSensorCount  where address = @oldAddress";

            return this.MySqlHelper.ExecuteNonQuery(cmdText, parms);
        }
    }
}
