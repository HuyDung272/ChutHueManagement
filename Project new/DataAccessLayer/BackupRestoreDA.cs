using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChutHueManagement.BusinessEntities;
using ChutHueManagement.Utilities;
using ChutHueManagement.DataProvider;
using System.Data;
using System.Data.SqlClient;


namespace ChutHueManagement.DataAccessLayer
{

    public class BackupRestoreDA
    {
        public BackupRestoreDA()
        {

        }


        public bool Backup(string strFileName)
        {

            try
            {
                ParameterBuilder pb = DBFactory.CreateParamBuilder();

                pb.AddParameter("strFileName", strFileName);

                return DBFactory.Database.ExecuteNonQueryGetID("BackupDatabase", pb.Parameters) == 1;

                
            }
            catch (Exception ex)
            {
                Logger.Write(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public bool Restore(string paths)
        {

            try
            {
                ParameterBuilder pb = DBFactory.CreateParamBuilder();

                pb.AddParameter("paths", paths);

                return DBFactory.Database.ExecuteNonQueryGetID("RestoreDatabase", pb.Parameters) == 1;            
            }
            catch (Exception ex)
            {
                Logger.Write(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        


    }
}
