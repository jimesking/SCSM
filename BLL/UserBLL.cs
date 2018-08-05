using DAL;
using System.Collections.Generic;
using Entity;
using MySql.Data.MySqlClient;

namespace BLL
{
    public class UserBLL:BaseBLL
    {
        public UserBLL(IDAL dal) : base(dal)
        {
        }

        public User GetUserByNameAndPassword(string name,string password) {
            string strSql = "";
            MySqlParameter[] parms = new MySqlParameter[] {
                new MySqlParameter("@name",name),
                new MySqlParameter("password",password)
            };

            List<object> list1 = this.Dal.GetObjsBySQL(strSql, parms);
            User user = new User();
            if (list1.Count > 0)
                user = (User)list1[0];
            return user;
        }

    }
}
