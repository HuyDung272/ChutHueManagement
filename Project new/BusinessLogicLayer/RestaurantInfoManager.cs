using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChutHueManagement.Utilities;
using ChutHueManagement.DataProvider;
using ChutHueManagement.BusinessEntities;
using ChutHueManagement.DataAccessLayer;
using System.Data;

namespace ChutHueManagement.BusinessLogicLayer
{
    public class RestaurantInfoManager
    {
        private static RestaurantInfoDA adapter = null;
        static RestaurantInfoManager()
        {
            if (adapter == null)
                adapter = new RestaurantInfoDA();
        }
        public static int Insert(RestaurantInfoEntity entity)
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
        public static bool UpDate(RestaurantInfoEntity entity)
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
        public static DataTable GetByID(int iD)
        {
            try
            {
                return adapter.GetByID(iD);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                return null;
            }
        }
        public static List<RestaurantInfoEntity> ConvertToList(DataTable dt)
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
