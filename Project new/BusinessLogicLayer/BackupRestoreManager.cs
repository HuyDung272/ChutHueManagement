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
    public class BackupRestoreManager
    {
        private static BackupRestoreDA adapter = null;

        static BackupRestoreManager()
        {
            if (adapter == null)
                adapter = new BackupRestoreDA();
        }

     
        public static bool Backup(string strFileName)
        {
            try
            {
                return adapter.Backup(strFileName);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                return false;
            }
        }
      
        public static bool Backup(string strFileName, ref string errormessage)
        {
            try
            {
                return adapter.Backup(strFileName);
            }
            catch (Exception ex)
            {
                errormessage = ex.Message;
                Logger.Write(ex);
                return false;
            }
        }

        public static bool Restore(string strPath)
        {
            try
            {
                return adapter.Restore(strPath);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                return false;
            }
        }

        public static bool Restore(string strPath, ref string errormessage)
        {
            try
            {
                return adapter.Restore(strPath);
            }
            catch (Exception ex)
            {
                errormessage = ex.Message;
                Logger.Write(ex);
                return false;
            }
        }
    }
}
