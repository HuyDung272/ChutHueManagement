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
    public class TablesDA
    {
        public TablesDA()
        {

        }
        public int Insert(TableEntity entity)
        {
            try
            {
                ParameterBuilder pb = DBFactory.CreateParamBuilder();
                pb.AddParameter("TableName", entity.TableName);
                return (int)DBFactory.Database.ExecuteNonQuery("Tables_Insert", pb.Parameters);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                return 0;
            }
        }
        public bool UpDate(TableEntity entity)
        {
            try
            {
                ParameterBuilder pb = DBFactory.CreateParamBuilder();
                pb.AddParameter("ID", entity.ID);
                pb.AddParameter("TableName", entity.TableName);
                return DBFactory.Database.ExecuteNonQuery("Tables_UpDate", pb.Parameters)>0;
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
                dt = DBFactory.Database.FillDataTable("Tables_GetByID", pb.Parameters);
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
                dt = DBFactory.Database.FillDataTable("Tables_GetAll", pb.Parameters);
                return dt;
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                return null;
            }
        }
        public List<TableEntity> ConvertToList(DataTable dt)
        {
            List<TableEntity> list = new List<TableEntity>();
            for(int i=0;i<dt.Rows.Count;i++)
            {
                int iD = (int)dt.Rows[i][0];
                string nameTable = dt.Rows[i][1].ToString();
                TableEntity tb = new TableEntity(iD, nameTable);
                list.Add(tb);
            }
            return list;
        }
    }
}
