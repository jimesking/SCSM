
using Entity;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace DAL
{
    public class UserDAL: BaseDal,IDAL
    {
        public int Add(object obj)
        {
            User user = (User)obj;

            MySqlParameter[] parms = new MySqlParameter[] {
                new MySqlParameter("@name",user.Name),
                new MySqlParameter("@password", user.Password),
                new MySqlParameter("@role",user.Role)};

            string cmdText = "insert into userInfo (name,password,role) values(@name,@password,@role);";

            return base.MySqlHelper.ExecuteNonQuery(cmdText, parms);
        }

        public int Delete(object obj)
        {
            User user = (User)obj;

            MySqlParameter[] parms = new MySqlParameter[] {
                new MySqlParameter("@name",user.Name)
            };

            string cmdText = "delete from userInfo where name=@name";

            return base.MySqlHelper.ExecuteNonQuery(cmdText, parms);
        }
        public int Modify(object oldObj, object newObj)
        {
            User oldUser = (User)oldObj;
            User newUser = (User)newObj;

            MySqlParameter[] parms = new MySqlParameter[] {
                new MySqlParameter("@oldName",oldUser.Name),
                new MySqlParameter("@name", newUser.Name),
                new MySqlParameter("@password",newUser.Password),
                new MySqlParameter("@role",newUser.Role)};

            string cmdText = "update userInfo set name=@name,password=@password,role=@role where name = @oldName";

            return base.MySqlHelper.ExecuteNonQuery(cmdText, parms);
        }
        public List<object> GetAllObjs()
        {
            List<object> objs = new List<object>();

            string cmdText = "select * from userInfo";

            MySqlParameter[] parms = new MySqlParameter[] { };

            MySqlDataReader reader = this.MySqlHelper.ExecuteReader(cmdText, parms);

            while (reader.Read())
            {
                User user = new User();
                user.Name = reader[0].ToString().Trim();
                user.Password = reader[1].ToString().Trim();
                user.Role = int.Parse(reader[2].ToString().Trim());
                objs.Add(user);
            }
            this.mySqlHelper.CloseConn();

            return objs;
        }

        public object GetObjById(string id)
        {
            User user = new User(id);

            string cmdText = "select * from userInfo where name=@id";

            MySqlParameter[] parms = new MySqlParameter[] { new MySqlParameter("@id", id) };

            MySqlDataReader reader = this.MySqlHelper.ExecuteReader(cmdText, parms);

            while (reader.Read())
            {
                user.Name = reader[0].ToString().Trim();
                user.Password = reader[1].ToString().Trim();
                user.Role = int.Parse(reader[2].ToString().Trim());
            }
            this.mySqlHelper.CloseConn();

            return user;
        }

        public List<object> GetObjsBySQL(string strSQL, MySqlParameter[] parms)
        {
            return new List<object>();
        }

        public int ExcuteSqlStr(string strSQL, MySqlParameter[] parms)
        {
            return this.MySqlHelper.ExecuteNonQuery(strSQL, parms);
        }
    }
}
