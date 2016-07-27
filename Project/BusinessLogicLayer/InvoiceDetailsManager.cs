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

namespace BusinessLogicLayer
{
    public class InvoiceDetailsManager
    {
        private static InvoiceDetailsDA adapter = null;
        private InvoiceDetailsManager ()
        {
            if (adapter == null)
                adapter = new InvoiceDetailsDA();
        }
        public static int Insert(InvoiceDetailsEntity entity)
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
        public static bool UpDate(InvoiceDetailsEntity entity)
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
        public static DataTable GetByIDInvoice(int iDInvoice)
        {
            try
            {
                return adapter.GetByIDInvoice(iDInvoice);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                return null;
            }
        }
        public static DataTable GetByIDFoodMenu(int iDFoodMenu)
        {
            try
            {
                return adapter.GetByIDFoodMenu(iDFoodMenu);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                return null;
            }
        }
        public static List<InvoiceDetailsEntity> ConvertToList(DataTable dt)
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
