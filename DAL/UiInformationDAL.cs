using Entity;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace DAL
{
    public class UiInformationDAL: BaseDal,IDAL
    {
        public int Add(object obj)
        {
            UIInfomation ui = (UIInfomation)obj;

            MySqlParameter[] parms = new MySqlParameter[] {
                new MySqlParameter("@userName",ui.UserName),
                new MySqlParameter("@title", ui.Title),
                new MySqlParameter("@caption",ui.Caption)
            };

            string cmdText = "insert into UIInfomation (userName,caption,title) values(@userName,@title,@caption);";

            return MySqlHelper.ExecuteNonQuery(cmdText, parms);
        }

        public int Delete(object obj)
        {
            UIInfomation ui = (UIInfomation)obj;
            MySqlParameter[] parms = new MySqlParameter[] { new MySqlParameter("@id", ui.Id) };

            string cmdText = "delete from UIInfomation where id=@id";

            return this.MySqlHelper.ExecuteNonQuery(cmdText, parms);
        }

        public int ExcuteSqlStr(string strSQL, MySqlParameter[] parms)
        {
            return this.MySqlHelper.ExecuteNonQuery(strSQL, parms);
        }

        public List<object> GetAllObjs()
        {
            List<object> objs = new List<object>();

            string cmdText = "select * from UIInfomation";

            MySqlParameter[] parms = new MySqlParameter[] { };

            MySqlDataReader reader = this.MySqlHelper.ExecuteReader(cmdText, parms);

            while (reader.Read())
            {
                UIInfomation ui = new UIInfomation();
                ui.Id = int.Parse(reader[0].ToString().Trim());
                ui.UserName = reader[1].ToString().Trim();
                ui.Title = reader[2].ToString().Trim();
                ui.Caption = reader[3].ToString().Trim();

                objs.Add(ui);
            }
            this.mySqlHelper.CloseConn();

            return objs;
        }

        public object GetObjById(string id)
        {
            int iId = int.Parse(id);

            UIInfomation ui = new UIInfomation();

            string cmdText = "select * from UIInfomation where id=@Id";

            MySqlParameter[] parms = new MySqlParameter[] { new MySqlParameter("@id", iId) };

            MySqlDataReader reader = this.MySqlHelper.ExecuteReader(cmdText, parms);

            while (reader.Read())
            {
                ui.Id = iId;
                ui.UserName = reader[1].ToString().Trim();
                ui.Title = reader[2].ToString();
                ui.Caption = reader[3].ToString().Trim();
            }
            this.mySqlHelper.CloseConn();
            return ui;
        }

        public List<object> GetObjsBySQL(string strSQL, MySqlParameter[] parms)
        {
            List<object> objs = new List<object>();

            MySqlDataReader reader = this.MySqlHelper.ExecuteReader(strSQL, parms);

            while (reader.Read())
            {
                UIInfomation ui = new UIInfomation();
                ui.Id = int.Parse(reader[0].ToString().Trim());
                ui.UserName = reader[1].ToString().Trim();
                ui.Title = reader[2].ToString().Trim();
                ui.Caption = reader[3].ToString().Trim();

                objs.Add(ui);
            }
            this.mySqlHelper.CloseConn();

            return objs;
        }

        public int Modify(object oldObj, object newObj)
        {
            UIInfomation oldUi = (UIInfomation)oldObj;
            UIInfomation newUi = (UIInfomation)newObj;

            MySqlParameter[] parms = new MySqlParameter[] {
                new MySqlParameter("@oldId",oldUi.Id),
                new MySqlParameter("@userName", newUi.UserName),
                new MySqlParameter("@title",newUi.Title),
                new MySqlParameter("@caption",newUi.Caption)};

            string cmdText = "update UIInfomation set userName=@userName,title=@title,caption=@caption where id = @oldId";

            return this.MySqlHelper.ExecuteNonQuery(cmdText, parms);
        }
    }
}
