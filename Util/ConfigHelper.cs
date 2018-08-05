using System.Configuration;


namespace Util
{
    public class ConfigHelper
    {
        public static string GetConnectionStr(string connName) {

            return ConfigurationManager.ConnectionStrings[connName].ConnectionString;
                                  
        }
    }
}
