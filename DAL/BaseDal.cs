using Util;

namespace DAL
{
    public class BaseDal
    {       
        protected MySqlHelper mySqlHelper = new MySqlHelper();
        public BaseDal()
        {
            //this.mySqlHelper = new MySqlHelper();
        }

        public MySqlHelper MySqlHelper
        {
            get
            {
                return mySqlHelper;
            }

        }
    }
}
