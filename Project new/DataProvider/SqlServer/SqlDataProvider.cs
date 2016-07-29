using ChutHueManagement.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChutHueManagement.DataProvider
{
    internal sealed class SqlDataProvider : AdoSupporter, IDataProvider
    {
        internal SqlDataProvider()
        {
            if (connector == null)
                connector = new SqlConnector();
        }

        internal override ParameterBuilder CreateParamBuilder()
        {
            return new SqlParameterBuilder();
        }

        public DbConnector GetConnector()
        {
            return connector;
        }

        public DbTransaction CreateTransaction(DbConnector conn)
        {
            if (conn.OpenConnection())
            {
                DbTransaction tran = connector.Connection.BeginTransaction();
                return tran;
            }
            else return null;
        }

        public int ExecuteNonQuery(string StoredProcidure, List<DbParameter> parameters, DbConnector conn, DbTransaction tran)
        {
            try
            {
                DbCommand command = conn.CreateCommand(StoredProcidure, true);
                this.Addparameters(command, parameters);
                command.Transaction = tran;
                return command.ExecuteNonQuery();
            }
            catch (SqlException sqlex)
            {
                Logger.Write(sqlex);
                throw new Exception(sqlex.Message, sqlex);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                throw new Exception(ex.Message, ex);
            }
        }

        public void CommitTransaction(DbConnector conn, DbTransaction tran)
        {
            tran.Commit();
            conn.CloseConnection();
        }

        public int ExecuteNonQueryGetID(string StoredProcidure, List<System.Data.Common.DbParameter> parameters)
        {
            try
            {
                DbCommand command = connector.CreateCommand(StoredProcidure, true);
                this.Addparameters(command, parameters);
                DbParameter ProcessedFileName = command.CreateParameter();
                ProcessedFileName.DbType = DbType.Int32;
                ProcessedFileName.ParameterName = "@Output";
                ProcessedFileName.Direction = ParameterDirection.ReturnValue;
                command.Parameters.Add(ProcessedFileName);
                if (connector.OpenConnection())
                {
                    int x = command.ExecuteNonQuery();
                    return (int)command.Parameters["@Output"].Value;
                }
                else
                    return 0;
            }
            catch (SqlException sqlex)
            {
                Logger.Write(sqlex);
                throw new Exception(sqlex.Message, sqlex);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                connector.CloseConnection();
            }
        }

        public int ExecuteNonQueryGetID(string StoredProcidure, List<System.Data.Common.DbParameter> parameters, DbConnector conn, DbTransaction tran)
        {
            try
            {
                DbCommand command = conn.CreateCommand(StoredProcidure, true);
                this.Addparameters(command, parameters);
                DbParameter ProcessedFileName = command.CreateParameter();
                ProcessedFileName.DbType = DbType.Int32;
                ProcessedFileName.ParameterName = "@OutPut";
                ProcessedFileName.Direction = ParameterDirection.ReturnValue;
                command.Parameters.Add(ProcessedFileName);
                command.Transaction = tran;
                command.ExecuteNonQuery();
                return (int)command.Parameters["@OutPut"].Value;
            }
            catch (SqlException sqlex)
            {
                Logger.Write(sqlex);
                throw new Exception(sqlex.Message, sqlex);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                throw new Exception(ex.Message, ex);
            }
        }



        public IDataReader ExecuteReader(string query)
        {
            try
            {
                DbCommand command = connector.CreateCommand(query);
                if (connector.OpenConnection())
                    return command.ExecuteReader(CommandBehavior.CloseConnection);
                else
                    return null;
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                return null;
            }
        }

        public IDataReader ExecuteReader(string StoredProcidure, List<System.Data.Common.DbParameter> parameters)
        {
            try
            {
                DbCommand command = connector.CreateCommand(StoredProcidure, true);
                this.Addparameters(command, parameters);

                if (connector.OpenConnection())
                    return command.ExecuteReader(CommandBehavior.CloseConnection);
                else
                    return null;
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                return null;
            }
        }

        public int ExecuteNonQuery(string query)
        {
            try
            {
                DbCommand command = connector.CreateCommand(query);
                if (connector.OpenConnection())
                    return command.ExecuteNonQuery();
                else
                    return 0;
            }
            catch (SqlException sqlex)
            {
                Logger.Write(sqlex);
                throw new Exception(sqlex.Message, sqlex);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                connector.CloseConnection();
            }
        }

        public int ExecuteNonQuery(string StoredProcidure, List<System.Data.Common.DbParameter> parameters)
        {
            try
            {
                DbCommand command = connector.CreateCommand(StoredProcidure, true);
                this.Addparameters(command, parameters);

                if (connector.OpenConnection())
                    return command.ExecuteNonQuery();
                else
                    return 0;
            }
            catch (SqlException sqlex)
            {
                Logger.Write(sqlex);
                throw new Exception(sqlex.Message, sqlex);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                connector.CloseConnection();
            }
        }

        //public int ExecuteNonQuery(string StoredProcidure, List<System.Data.Common.DbParameter> parameters, string para, ref object value)
        //{
        //    try
        //    {
        //        DbCommand command = connector.CreateCommand(StoredProcidure, true);
        //        this.Addparameters(command, parameters);
        //        command.Parameters[para].Direction = ParameterDirection.Output;
        //        if (connector.OpenConnection())
        //        {
        //            return command.ExecuteNonQuery();

        //        }
        //        else
        //            return 0;
        //    }
        //    catch (Exception)
        //    {
        //        return 0;
        //    }
        //    finally
        //    {
        //        connector.CloseConnection();
        //    }
        //}

        public object ExecuteScalar(string query)
        {
            try
            {
                DbCommand command = connector.CreateCommand(query);
                if (connector.OpenConnection())
                    return command.ExecuteScalar();
                else
                    return 0;
            }
            catch (SqlException sqlex)
            {
                Logger.Write(sqlex);
                throw new Exception(sqlex.Message, sqlex);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                connector.CloseConnection();
            }
        }

        public object ExecuteScalar(string StoredProcidure, List<System.Data.Common.DbParameter> parameters)
        {
            try
            {
                DbCommand command = connector.CreateCommand(StoredProcidure, true);
                this.Addparameters(command, parameters);
                if (connector.OpenConnection())
                    return command.ExecuteScalar();
                else
                    return null;
            }
            catch (SqlException sqlex)
            {
                Logger.Write(sqlex);
                throw new Exception(sqlex.Message, sqlex);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                connector.CloseConnection();
            }
        }

        public DataSet FillDataSet(string query)
        {
            try
            {
                DbCommand command = connector.CreateCommand(query);
                DbDataAdapter adapter = new SqlDataAdapter((SqlCommand)command);

                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                return dataSet;
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                return null;
            }
            finally
            {
                connector.CloseConnection();
            }
        }

        public DataSet FillDataSet(string StoredProcidure, List<System.Data.Common.DbParameter> parameters)
        {
            try
            {
                DbCommand command = connector.CreateCommand(StoredProcidure, true);
                DbDataAdapter adapter = new SqlDataAdapter((SqlCommand)command);
                this.Addparameters(command, parameters);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                return dataSet;
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                return null;
            }
            finally
            {
                connector.CloseConnection();
            }
        }

        public DataTable FillDataTable(string query)
        {
            try
            {
                DbCommand command = connector.CreateCommand(query);
                DbDataAdapter adapter = new SqlDataAdapter((SqlCommand)command);

                DataTable datatable = new DataTable();
                adapter.Fill(datatable);
                return datatable;
            }
            catch (SqlException sqlex)
            {
                Logger.Write(sqlex);
                throw new Exception(sqlex.Message, sqlex);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                connector.CloseConnection();
            }
        }

        public DataTable FillDataTable(string StoredProcidure, List<System.Data.Common.DbParameter> parameters)
        {
            try
            {
                DbCommand command = connector.CreateCommand(StoredProcidure, true);
                DbDataAdapter adapter = new SqlDataAdapter((SqlCommand)command);
                this.Addparameters(command, parameters);

                DataTable datatable = new DataTable();
                adapter.Fill(datatable);
                return datatable;
            }
            catch (SqlException sqlex)
            {
                Logger.Write(sqlex);
                throw new Exception(sqlex.Message, sqlex);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                connector.CloseConnection();
            }
        }

        public DataTable RetrieveSchema(string query)
        {
            try
            {
                DbCommand command = connector.CreateCommand(query);
                DbDataAdapter adapter = new SqlDataAdapter((SqlCommand)command);

                DataTable datatable = new DataTable();
                adapter.FillSchema(datatable, SchemaType.Mapped);
                return datatable;
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                return null;
            }
        }

        public DataTable RetrieveSchema(string tbaleName, string columnName)
        {
            string query = "Select " + columnName + " from " + tbaleName;
            return this.RetrieveSchema(query);
        }
    }

}
