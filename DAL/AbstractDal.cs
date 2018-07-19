using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Util;
namespace DAL
{
    abstract class AbstractDal : IDAL
    {
        private Util.MySqlHelper mySqlHelper = new Util.MySqlHelper();

        protected Util.MySqlHelper MySqlHelper
        {
            get
            {
                return mySqlHelper;
            }

            set
            {
                mySqlHelper = value;
            }
        }

        public abstract int Add(object obj);


        public abstract int Delete(object obj);


        public abstract int ExcuteSqlStr(string strSQL, MySqlParameter[] parms);


        public abstract List<object> GetAllObjs();

        public abstract object GetObjById(string id);


        public abstract List<object> GetObjsBySQL(string strSQL, MySqlParameter[] parms);

        public abstract int Modify(object oldObj, object newObj);
    }
}
