using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace BLL
{
    interface IBLL
    {
        int Add(object obj);
        int Delete(object obj);
        int Modify(object oldObj, object newObj);
        object GetObjById(string id);
        List<object> GetAllObjs();
        List<object> GetObjsBySQL(string strSQL, MySqlParameter[] parms);
        int ExcuteSqlStr(string strSQL);
    }
}
