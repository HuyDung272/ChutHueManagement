using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChutHueManagement.Utilities;
using ChutHueManagement.DataProvider;
using ChutHueManagement.BusinessEntities;
using ChutHueManagement.DataAccessLayer;
using System.Data;

namespace ChutHueManagement.BusinessLogicLayer
{
    public class LogSystemManager
    {

        private static LogSystemDA adapter = null;

        static LogSystemManager()
        {
            if (adapter == null)
                adapter = new LogSystemDA();
        }


        public static int Insert(LogSystemEntity entity)
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

        public static int Insert(LogSystemEntity entity, ref string errormessage)
        {
            try
            {
                return adapter.Insert(entity);
            }
            catch (Exception ex)
            {
                errormessage = ex.Message;
                Logger.Write(ex);
                return 0;
            }
        }


        public static List<InfoEntity> ConvertToList(DataTable dt)
        {
            try
            {
                return adapter.ConvertToList(dt);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                return null;
            }

        }
    }
}


