using DAL;
using System;
using Entity;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace BLL
{
    public class UiInformationBLL:BaseBLL
    {
        public UiInformationBLL(IDAL dal) : base(dal)
        {
        }

        public List<UIInfomation> GetUiInformationsByUser(User user)
        {
            MySqlParameter[] parms = new MySqlParameter[] {
                new MySqlParameter("@userName",user.Name)
            };

            List<object> list =  base.Dal.GetObjsBySQL("select * from UIInfomation where userName = @userName", parms);

            List<UIInfomation> uis = new List<UIInfomation>();
            foreach (object obj in list) {
                uis.Add((UIInfomation)obj);
            }
            return uis;
        }
    }
}
