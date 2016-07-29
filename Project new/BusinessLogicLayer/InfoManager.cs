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
    public class InfoManager
    {
        
        private static InfoDA adapter = null;

        static InfoManager()
        {
            if (adapter == null)
                adapter = new InfoDA();
        }

        
        public static int Insert(InfoEntity entity)
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

        
        public static bool UpDate(InfoEntity entity)
        {
            try
            {
                return adapter.UpDate(entity);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                return false;
            }
        }

        
        public static DataTable GetInfo()
        {
            try
            {
                return adapter.GetInfo();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                return null;
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

