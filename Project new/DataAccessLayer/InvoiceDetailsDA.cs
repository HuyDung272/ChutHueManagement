using System;
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
    public class InvoiceDetailsDA
    {
        public InvoiceDetailsDA()
        {

        }
        public int Insert(InvoiceDetailsEntity invoiceDetail)
        {
            try
            {
                ParameterBuilder pb = DBFactory.CreateParamBuilder();
                pb.AddParameter("IDInvoice", invoiceDetail.IDInvoice);
                pb.AddParameter("IDFoodMenu", invoiceDetail.IDFoodMenu);
                pb.AddParameter("Total", invoiceDetail.Total);
                pb.AddParameter("PriceTotal", invoiceDetail.PriceTotal);
                return (int)DBFactory.Database.ExecuteNonQuery("InvoiceDetails_Insert", pb.Parameters);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                return 0;
            }
        }

        /// <summary>
        /// Insert Details có transaction
        /// </summary>
        /// <param name="invoiceDetail"></param>
        /// <param name="conn"></param>
        /// <param name="tran"></param>
        /// <returns></returns>
        public  int InsertTS(InvoiceDetailsEntity invoiceDetail, DbConnector conn, System.Data.Common.DbTransaction tran)
        {
            try
            {
                ParameterBuilder pb = DBFactory.CreateParamBuilder();

                pb.AddParameter("IDInvoice", invoiceDetail.IDInvoice);
                pb.AddParameter("IDFoodMenu", invoiceDetail.IDFoodMenu);
                pb.AddParameter("Total", invoiceDetail.Total);
                pb.AddParameter("PriceTotal", invoiceDetail.PriceTotal);
                return (int)DBFactory.Database.ExecuteNonQuery("InvoiceDetails_Insert", pb.Parameters, conn, tran);
               // return (int)DBFactory.Database.ExecuteNonQueryGetID("MatHang_Insert", pb.Parameters, conn, tran);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                throw new Exception(ex.Message);
            }
        }

        public  int InsertTS(InvoiceDetailsEntity invoiceDetail, DbConnector conn, System.Data.Common.DbTransaction tran, ref string errormessage)
        {
            try
            {
                return InsertTS(invoiceDetail, conn, tran);
            }
            catch (Exception ex)
            {
                errormessage = ex.Message;
                Logger.Write(ex);
                throw new Exception(ex.Message);
            }
        }

        public bool UpDate(InvoiceDetailsEntity invoiceDetail)
        {
            try
            {
                ParameterBuilder pb = DBFactory.CreateParamBuilder();
                pb.AddParameter("ID", invoiceDetail.ID);
                pb.AddParameter("IDInvoice", invoiceDetail.IDInvoice);
                pb.AddParameter("IDFoodMenu", invoiceDetail.IDFoodMenu);
                pb.AddParameter("Total", invoiceDetail.Total);
                pb.AddParameter("PriceTotal", invoiceDetail.PriceTotal);
                return DBFactory.Database.ExecuteNonQuery("InvoiceDetails_UpDate", pb.Parameters)>0;
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                return false;
            }
        }

        public DataTable GetByID(int iD)
        {
            try
            {
                DataTable dt = new DataTable();
                ParameterBuilder pb = DBFactory.CreateParamBuilder();
                pb.AddParameter("ID", iD);
                dt = DBFactory.Database.FillDataTable("InvoiceDetails_GetByID", pb.Parameters);
                return dt;
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                return null;
            }
        }
        public DataTable GetByIDInvoice(int iDInvoice)
        {
            try
            {
                DataTable dt = new DataTable();
                ParameterBuilder pb = DBFactory.CreateParamBuilder();
                pb.AddParameter("ID", iDInvoice);
                dt = DBFactory.Database.FillDataTable("RestaurantInfo_GetByIDInvoice", pb.Parameters);
                return dt;
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                return null;
            }
        }
        public DataTable GetByIDFoodMenu(int iDFoodMenu)
        {
            try
            {
                DataTable dt = new DataTable();
                ParameterBuilder pb = DBFactory.CreateParamBuilder();
                pb.AddParameter("ID", iDFoodMenu);
                dt = DBFactory.Database.FillDataTable("RestaurantInfo_GetByIDFoodMenu", pb.Parameters);
                return dt;
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                return null;
            }
        }
        public DataTable GetAll()
        {
            try
            {
                DataTable dt = new DataTable();
                ParameterBuilder pb = DBFactory.CreateParamBuilder();
                dt = DBFactory.Database.FillDataTable("InvoiceDetails_GetAll", pb.Parameters);
                return dt;
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                return null;
            }
        }

        public List<InvoiceDetailsEntity> ConvertToList(DataTable dt)
        {
            List<InvoiceDetailsEntity> list = new List<InvoiceDetailsEntity>();
            for(int i=0;i<dt.Rows.Count;i++)
            {
                int id = (int)dt.Rows[i][0];
                int idInvoice = (int)dt.Rows[i][1];
                int idFoodMenu = (int)dt.Rows[i][2];
                int total = (int)dt.Rows[i][3];
                double priceTotal = (double)dt.Rows[i][4];
                InvoiceDetailsEntity entity = new InvoiceDetailsEntity(id, idInvoice, idFoodMenu, total, priceTotal);
                list.Add(entity);
            }
            return list;
        }

    }
}
