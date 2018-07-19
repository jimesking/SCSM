using DAL;

namespace BLL
{
    public class AlarmBLL : BaseBLL
    {
        public AlarmBLL(IDAL dal) : base(dal)
        {

        }
        //private static AlarmDAL dal = new AlarmDAL();
        //public int Add(object alarm)
        //{
        //    return dal.Add(alarm);
        //}

        //public int Delete(object alarm)
        //{
        //    return dal.Delete(alarm);
        //}

        //public List<object> GetAllObjs()
        //{
        //    return dal.GetAllObjs();
        //}

        //public object GetObjById(string id)
        //{
        //    return dal.GetObjById(id);
        //}

        //public List<object> GetObjsBySQL(string strSQL, MySqlParameter[] parms)
        //{
        //    return dal.GetObjsBySQL(strSQL,parms);
        //}
        //public int Modify(object oldObj, object newObj)
        //{
        //    return dal.Modify(oldObj, newObj);
        //}

        //public int ExcuteSqlStr(string strSQL)
        //{
        //    MySqlParameter[] parms = new MySqlParameter[] { };
        //    return dal.ExcuteSqlStr(strSQL,parms);
        //}

    }
}
