using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChutHueManagement.DataAccessLayer;
using ChutHueManagement.BusinessEntities;
using ChutHueManagement.Utilities;
using System.Data;

namespace ChutHueManagement.BusinessLogicLayer
{
    public class LogBackupRestoreManager
    {
        private static LogBackupRestoreDA adapter = null;

        static LogBackupRestoreManager()
        {
            if (adapter == null)
                adapter = new LogBackupRestoreDA();
        }

        
        public static int Insert(LogBackupRestoreEntity entity)
        {
            try
            {
                return adapter.Insert(entity);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                return 0;
            }
        }

        public static int InsertGetID(LogBackupRestoreEntity entity)
        {
            try
            {
                return adapter.InsertGetID(entity);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                return 0;
            }
        }

        public static DataTable GetAll(bool dk)
        {
            try
            {
                return adapter.GetAll(dk);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                return null;
            }
        }

        public static bool Delete(int id)
        {
            try
            {
                return adapter.Delete(id);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                return false;
            }
        }
    }
}
