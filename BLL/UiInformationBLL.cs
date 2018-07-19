using DAL;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Entity;

namespace BLL
{
    public class UiInformationBLL:IBLL
    {
        public static UiInformationDAL dal = new UiInformationDAL();

        public int Add(object obj)
        {
            return dal.Add(obj);
        }

        public int Delete(object obj)
        {
            return dal.Delete(obj);
        }

        public List<object> GetAllObjs()
        {
            return dal.GetAllObjs();
        }

        public object GetObjById(string id)
        {
            return dal.GetObjById(id);
        }

        public List<object> GetObjsBySQL(string strSQL, MySqlParameter[] parms)
        {
            return dal.GetObjsBySQL(strSQL, parms);
        }

        public int Modify(object oldObj, object newObj)
        {
            return dal.Modify(oldObj, newObj);
        }

        public int ExcuteSqlStr(string strSQL)
        {
            MySqlParameter[] parms = new MySqlParameter[] { };
            return dal.ExcuteSqlStr(strSQL,parms);
        }

        public UIInfomation GetUiInformationByUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
