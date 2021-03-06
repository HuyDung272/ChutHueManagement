﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChutHueManagement.BusinessEntities;
using ChutHueManagement.DataProvider;
using ChutHueManagement.Utilities;
using System.Data;

namespace ChutHueManagement.DataAccessLayer
{
    public class LogBackupRestoreDA
    {
        public LogBackupRestoreDA()
        {

        }
        
        public int Insert(LogBackupRestoreEntity entity)
        {
            try
            {
                ParameterBuilder pb = DBFactory.CreateParamBuilder();

                pb.AddParameter("Name", entity.Name);
                pb.AddParameter("DateTime", entity.Date);
                pb.AddParameter("IsBackup", entity.IsBackup);
                pb.AddParameter("Path", entity.Path);
                pb.AddParameter("Note", entity.Note);

                return (int)DBFactory.Database.ExecuteNonQuery("LogBackupRestore_Insert", pb.Parameters);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                return 0;
            }
        }

       
        //public DataTable Find(bool gt)
        //{
        //    try
        //    {
        //        ParameterBuilder pd = DBFactory.CreateParamBuilder();
        //        if (gt)
        //            pd.AddParameter("BK_RS", 1);
        //        else
        //            pd.AddParameter("BK_RS", 0);
        //        DataTable dt = new DataTable();
        //        dt = DBFactory.Database.FillDataTable("LogBackupRestore_GetAll", pd.Parameters);
        //        return dt;
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.Write(ex);
        //        return null;
        //    }
        //}

    }
}

