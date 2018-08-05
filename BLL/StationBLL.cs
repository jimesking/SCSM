using DAL;
using Entity;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace BLL
{
    public class StationBLL : BaseBLL
    {
        public StationBLL(IDAL dal) : base(dal)
        {
        }
        public List<Station> GetStationsByUser(User user) {
            MySqlParameter[] parms = new MySqlParameter[] {
                new MySqlParameter("@userName",user.Name)
            };
            string strSQL = "select * from station where address like @userName";

            List<object> objs = base.Dal.GetObjsBySQL(strSQL, parms);
            List<Station> stations = new List<Station>();

            foreach (object obj in objs) {
                stations.Add((Station)obj);
            }

            return stations;
        }
    }
}
