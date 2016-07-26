using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChutHueManagement.BusinessEntities;
using ChutHueManagement.DataProvider;
using ChutHueManagement.Utilities;
using System.Data;

namespace ChutHueManagement.DataAccessLayer
{
    public class InfoDA
    {
        public InfoDA()
        {

        }

        public int Insert(InfoEntity entity)
        {
            try
            {
                ParameterBuilder pb = DBFactory.CreateParamBuilder();
                pb.AddParameter("NameRestaurant", entity.NameRestaurant);
                pb.AddParameter("Address", entity.Address);
                pb.AddParameter("PhoneNumber", entity.PhoneNumber);
                pb.AddParameter("CellNumber", entity.CellNumber);
                pb.AddParameter("Email", entity.Email);
                pb.AddParameter("Description", entity.Description);

                return (int)DBFactory.Database.ExecuteNonQuery("Info_Insert", pb.Parameters);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                throw new Exception(ex.Message, ex);
            }
        }

        public bool UpDate(InfoEntity entity)
        {
            try
            {
                ParameterBuilder pb = DBFactory.CreateParamBuilder();

                pb.AddParameter("NameRestaurant", entity.NameRestaurant);
                pb.AddParameter("Address", entity.Address);
                pb.AddParameter("PhoneNumber", entity.PhoneNumber);
                pb.AddParameter("CellNumber", entity.CellNumber);
                pb.AddParameter("Email", entity.Email);
                pb.AddParameter("Description", entity.Description);


                return DBFactory.Database.ExecuteNonQuery("Info_UpDate", pb.Parameters) > 0;
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                throw new Exception(ex.Message, ex);
            }
        }

        public DataTable GetInfo()
        {
            try
            {
                DataTable dt = new DataTable();
                ParameterBuilder pb = DBFactory.CreateParamBuilder();

                dt = DBFactory.Database.FillDataTable("Info_GetInfo", pb.Parameters);
                return dt;
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                throw new Exception(ex.Message, ex);
            }
        }

        public List<InfoEntity> ConvertToList(DataTable dt)
        {
            List<InfoEntity> list = new List<InfoEntity>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int id = (int)dt.Rows[i][0];
                string nameRestaurant = dt.Rows[i][1].ToString();
                string address = dt.Rows[i][2].ToString();
                string phoneNumber = dt.Rows[i][3].ToString();
                string cellNumber = dt.Rows[i][4].ToString();
                string email = dt.Rows[i][5].ToString();
                string description = dt.Rows[i][6].ToString();
                InfoEntity info = new InfoEntity(id, nameRestaurant, address, phoneNumber, cellNumber, email, description);
                list.Add(info);
            }
            return list;
        }

    }
}
