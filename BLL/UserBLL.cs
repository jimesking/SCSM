using DAL;
using System.Collections.Generic;
using System;
using Entity;
using MySql.Data.MySqlClient;

namespace BLL
{
    public class UserBLL:IBLL
    {
        public static UserDAL userDAL = new UserDAL();

        public User GetUserByNameAndPassword(string name,string password) {
            return userDAL.GetUserByNameAndPassword(name, password);
        }

        public int Add(object obj)
        {
            return userDAL.Add(obj);
        }

        public int Delete(object obj)
        {
            return userDAL.Delete(obj);
        }

        public List<object> GetAllObjs()
        {
            return userDAL.GetAllObjs();
        }

        public object GetObjById(string id)
        {
            return userDAL.GetObjById(id);
        }

        public List<object> GetObjsBySQL(string strSQL, MySqlParameter[] parms)
        {
            return userDAL.GetObjsBySQL(strSQL,parms);
        }

        public int Modify(object oldObj, object newObj)
        {
            return userDAL.Modify(oldObj,newObj);
        }

        public int ExcuteSqlStr(string strSQL)
        {
            throw new NotImplementedException();
        }
    }
}
