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
    public class InvoiceDA
    {
        public InvoiceDA()
        {

        }
        public int Insert(InvoiceEntity entity)
        {
            try
            {
                ParameterBuilder pb = DBFactory.CreateParamBuilder();
                pb.AddParameter("InvoiceCode", entity.InvoiceCode);
                pb.AddParameter("TableName", entity.TableName);
                pb.AddParameter("DateTime", entity.Date);
                pb.AddParameter("Note", entity.Note);
                return (int)DBFactory.Database.ExecuteNonQuery("Invoice_Insert",pb.Parameters);
            }
            catch (Exception ex) 
            {
                Logger.Write(ex);
                return 0;
            }
        }

        public int InsertTS(InvoiceEntity entity, ref string errormessage)
        {
            try
            {
                DbConnector conn = DBFactory.Database.GetConnector();
                System.Data.Common.DbTransaction tran = DBFactory.Database.CreateTransaction(conn);

                int idInvoice = this.InsertTS(entity, conn, tran);

                if (idInvoice == 0)
                    return 0;

                int countdetails = entity.ListDetail.Count;

                InvoiceDetailsDA invoicedetailsDa = new InvoiceDetailsDA();

                for (int i = 0; i < countdetails; i++)
                {
                    InvoiceDetailsEntity detailsentity = entity.ListDetail[i];
                    detailsentity.IDInvoice = idInvoice;
                    int id = invoicedetailsDa.InsertTS(detailsentity, conn, tran, ref errormessage);
                    if (id == 0)
                        return 0;
                }
                    return 0;
            }
            catch (Exception ex)
            {
                errormessage = ex.Message;
                Logger.Write(ex);
                return 0;
            }
        }

        public int InsertTS(InvoiceEntity entity, DbConnector conn, System.Data.Common.DbTransaction tran)
        {
            try
            {
                ParameterBuilder pb = DBFactory.CreateParamBuilder();
                pb.AddParameter("InvoiceCode", entity.InvoiceCode);
                pb.AddParameter("TableName", entity.TableName);
                pb.AddParameter("DateTime", entity.Date);
                pb.AddParameter("Note", entity.Note);
                return (int)DBFactory.Database.ExecuteNonQuery("Invoice_Insert", pb.Parameters, conn, tran);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                return 0;
            }
        }

        public int InsertTS(InvoiceEntity entity, DbConnector conn, System.Data.Common.DbTransaction tran, ref string errormessage)
        {
            try
            {
                return InsertTS(entity, conn, tran);
            }
            catch (Exception ex)
            {
                errormessage = ex.Message;
                Logger.Write(ex);
                return 0;
            }
        }

        public bool UpDate(InvoiceEntity entity)
        {
            try
            {
                ParameterBuilder pb = DBFactory.CreateParamBuilder();
                pb.AddParameter("ID", entity.ID);
                pb.AddParameter("InvoiceCode", entity.InvoiceCode);
                pb.AddParameter("TableName", entity.TableName);
                pb.AddParameter("DateTime", entity.Date);
                pb.AddParameter("Note", entity.Note);
                return (int)DBFactory.Database.ExecuteNonQuery("Invoice_UpDate", pb.Parameters)>0;
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                return false;
            }
        }
        public DataTable GetAll()
        {
            try
            {
                DataTable dt = new DataTable();
                ParameterBuilder pb = DBFactory.CreateParamBuilder();
                dt = DBFactory.Database.FillDataTable("Invoice_GetAll",pb.Parameters);
                return dt;
            }
            catch(Exception ex)
            {
                Logger.Write(ex);
                return null;
            }
        }
        public DataTable GetByID(int iD)
        {
            try
            {
                DataTable dt = new DataTable();
                ParameterBuilder pb = DBFactory.CreateParamBuilder();
                pb.AddParameter("ID", iD);
                dt = DBFactory.Database.FillDataTable("Invoice_GetByID", pb.Parameters);
                return dt;
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                return null;
            }
        }

        public DataTable GetSerialCodeMax()
        {
            try
            {
                DataTable dt = new DataTable();
                ParameterBuilder pd = DBFactory.CreateParamBuilder();

                dt = DBFactory.Database.FillDataTable("Invoice_GetSerialCodeMax", pd.Parameters);
                return dt;
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                return null;
            }
        }

        public List<InvoiceEntity> ConvertToList(DataTable dt)
        {
            List<InvoiceEntity> list = new List<InvoiceEntity>();
            for(int i=0;i<dt.Rows.Count;i++)
            {
                int iD = (int)dt.Rows[i][0];
                string invoiceCode = dt.Rows[i][1].ToString();
                string tableName = dt.Rows[i][2].ToString();
                DateTime date = DateTime.Parse( dt.Rows[i][3].ToString());
                string note = dt.Rows[i][4].ToString();
                InvoiceEntity invoice = new InvoiceEntity(iD, invoiceCode, tableName, date, note);
                list.Add(invoice);
            }
            return list;
        }

    }
}
