using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChutHueManagement.DataProvider
{
    public class DBFactory
    {
        private static IDataProvider _database = null;

        public static IDataProvider Database
        {
            get
            {
                if (_database == null)
                {
                    _database = new SqlDataProvider();
                }
                return _database;
            }
        }

        public static ParameterBuilder CreateParamBuilder()
        {
            AdoSupporter supporter = Database as AdoSupporter;
            return supporter.CreateParamBuilder();
        }

    }
}

