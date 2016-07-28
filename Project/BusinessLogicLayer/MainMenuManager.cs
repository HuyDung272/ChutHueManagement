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
    public class MainMenuManager
    {

        private static MainMenuDA adapter = null;

        static MainMenuManager()
        {
            if (adapter == null)
                adapter = new MainMenuDA();
        }


        public static int Insert(MainMenuEntity entity)
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

        public static int Insert(MainMenuEntity entity, ref string errormessage)
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


        public static bool UpDate(MainMenuEntity entity)
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

        public static bool UpDate(MainMenuEntity entity, ref string errormessage)
        {
            try
            {
                return adapter.UpDate(entity);
            }
            catch (Exception ex)
            {
                errormessage = ex.Message;
                Logger.Write(ex);
                return false;
            }
        }

        public static DataTable GetAll()
        {
            try
            {
                return adapter.GetAll();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                return null;
            }
        }




        public static List<MainMenuEntity> ConvertToList(DataTable dt)
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

