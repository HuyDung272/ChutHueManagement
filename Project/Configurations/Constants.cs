using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChutHueManagement.Configurations
{
    public class Constants
    {
        public static readonly bool AllowDelete = true;

        public static readonly string PROVIDER_SQL = "SQL";
        public static readonly string PROVIDER_OLEDB = "QLEDB";
        public static readonly string PROVIDER_ODBC = "ODBC";
    }

    public class Configs
    {
        public static readonly string ConnectionString;
        public static readonly string ImageFileType;
        public static readonly string ProviderTypes;

        static Configs()
        {
            ImageFileType = ConfigurationManager.AppSettings["ImageFileTypes"];
            ProviderTypes = ConfigurationManager.AppSettings["ProviderType"];
            ConnectionString = ConfigurationManager.ConnectionStrings["DbPassport"].ConnectionString;
        }
    }
}
