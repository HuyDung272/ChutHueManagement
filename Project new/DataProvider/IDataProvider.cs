using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

namespace ChutHueManagement.DataProvider
{
    public interface IDataProvider
    {
        IDataReader ExecuteReader(string query);
        IDataReader ExecuteReader(string StoredProcidure, List<DbParameter> parameters);

        int ExecuteNonQuery(string query);
        int ExecuteNonQuery(string StoredProcidure, List<DbParameter> parameters);


        object ExecuteScalar(string query);
        object ExecuteScalar(string StoredProcidure, List<DbParameter> parameters);

        DataSet FillDataSet(string query);
        DataSet FillDataSet(string StoredProcidure, List<DbParameter> parameters);

        DataTable FillDataTable(string query);
        DataTable FillDataTable(string StoredProcidure, List<DbParameter> parameters);

        DataTable RetrieveSchema(string query);
        DataTable RetrieveSchema(string tbaleName, string columnName);

        DbConnector GetConnector();

        DbTransaction CreateTransaction(DbConnector conn);

        int ExecuteNonQuery(string StoredProcidure, List<System.Data.Common.DbParameter> parameters, DbConnector conn, DbTransaction tran);

        void CommitTransaction(DbConnector conn, DbTransaction tran);

        int ExecuteNonQueryGetID(string StoredProcidure, List<System.Data.Common.DbParameter> parameters);

        int ExecuteNonQueryGetID(string StoredProcidure, List<System.Data.Common.DbParameter> parameters, DbConnector conn, DbTransaction tran);

    }

    public abstract class ParameterBuilder
    {
        protected List<DbParameter> parameters;

        public List<DbParameter> Parameters
        {
            get { return parameters; }
        }

        protected abstract DbParameter CreateParameter(string ParamName, object paramValue);

        public void AddParameter(string paramName, object paramValue)
        {
            DbParameter ts = CreateParameter(paramName, paramValue);
            parameters.Add(ts);
        }
    }

    internal abstract class AdoSupporter
    {
        protected DbConnector connector;

        protected virtual void Addparameters(DbCommand command, List<DbParameter> parameters)
        {
            command.Parameters.Clear();

            if ((parameters != null) && (parameters.Count > 0))
            {
                foreach (DbParameter ts in parameters)
                {
                    command.Parameters.Add(ts);
                }
            }
        }

        internal abstract ParameterBuilder CreateParamBuilder();
    }
}
