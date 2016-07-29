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
    public class FoodMenuManager
    {
        private static FoodMenuDA adapter = null;
        static FoodMenuManager()
        {
            if (adapter == null)
                adapter = new FoodMenuDA();
        }
        public static int Insert(FoodMenuEntity entity)
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

        public static int Insert(FoodMenuEntity entity, ref string errormessage)
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


        public static bool UpDate(FoodMenuEntity entity)
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

        public static bool UpDate(FoodMenuEntity entity, ref string errormessage)
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
        public static DataTable GetByID(int ID)
        {

            try
            {
                return adapter.GetByID(ID);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                return null;
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

        public static DataTable GetByIDMainMenu(int idMainMenu)
        {
            try
            {
                return adapter.GetByIDMainMenu(idMainMenu);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                return null;
            }
        }

        public static List<FoodMenuEntity> ConvertToList(DataTable dt)
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

        public static bool Delete(int id, ref string error)
        {
            try
            {
                return adapter.Delete(id);
            }
            catch (Exception ex)
            {
                error = ex.Message;
                Logger.Write(ex);
                return false;
            }
        }
    }
}
