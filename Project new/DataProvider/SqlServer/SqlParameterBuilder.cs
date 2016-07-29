using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChutHueManagement.DataProvider
{
    internal sealed class SqlParameterBuilder : ParameterBuilder
    {
        public SqlParameterBuilder()
        {
            parameters = new List<DbParameter>();
        }

        protected override DbParameter CreateParameter(string ParamName, object paramValue)
        {
            DbParameter parameter = new SqlParameter("@" + ParamName, paramValue);
            return parameter;
        }
    }
}

