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

        
    }
}
