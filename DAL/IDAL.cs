using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace DAL
{
    public interface IDAL
    {        
        int Add(object obj);
        int Delete(object obj);
        int Modify(object oldObj, object newObj);
        object GetObjById(string id);
        List<object> GetAllObjs();
        List<object> GetObjsBySQL(string strSQL, MySqlParameter[] parms);
        int ExcuteSqlStr(string strSQL, MySqlParameter[] parms);
    }
}
