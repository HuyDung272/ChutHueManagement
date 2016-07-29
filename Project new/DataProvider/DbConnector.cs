using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;

namespace ChutHueManagement.DataProvider
{
    public abstract class DbConnector
    {
        protected DbConnection _connection;

        public DbConnection Connection
        {
            get { return _connection; }
        }

        public virtual DbCommand CreateCommand()
        {
            return _connection.CreateCommand();
        }

        public virtual DbCommand CreateCommand(string query)
        {
            return CreateCommand(query, false);
        }

        public virtual DbCommand CreateCommand(string query, bool isStoreProcedure)
        {
            DbCommand command = _connection.CreateCommand();
            command.CommandText = query;

            if (isStoreProcedure)
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
            }
            return command;
        }

        public virtual bool OpenConnection()
        {
            try
            {
                if (_connection.State != System.Data.ConnectionState.Open)
                    _connection.Open();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public virtual void CloseConnection()
        {
            try
            {
                if (_connection.State != System.Data.ConnectionState.Closed)
                    _connection.Close();
            }
            catch (Exception)
            {
            }
        }
    }
}
