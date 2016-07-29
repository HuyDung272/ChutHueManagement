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
    public class RestaurantInfoDA
    {
        public RestaurantInfoDA()
        {

        }
        public int Insert(RestaurantInfoEntity entity)
        {
            try
            {
                ParameterBuilder pb = DBFactory.CreateParamBuilder();
                pb.AddParameter("NameRestaurant", entity.NameRestaurant);
                pb.AddParameter("Address", entity.Address);
                pb.AddParameter("PhoneNumber", entity.PhoneNumber);
                pb.AddParameter("CellPhone", entity.CellPhone);
                pb.AddParameter("Email", entity.Email);
                pb.AddParameter("Description", entity.Description);
                return (int)DBFactory.Database.ExecuteNonQuery("RestaurantInfo_Insert", pb.Parameters);
            }catch(Exception ex)
            {
                Logger.Write(ex);
                return 0;
            }
        }
        public bool UpDate(RestaurantInfoEntity entity)
        {
            try
            {
                ParameterBuilder pb = DBFactory.CreateParamBuilder();
                pb.AddParameter("ID", entity.ID);
                pb.AddParameter("NameRestaurant", entity.NameRestaurant);
                pb.AddParameter("Address", entity.Address);
                pb.AddParameter("PhoneNumber", entity.PhoneNumber);
                pb.AddParameter("CellPhone", entity.CellPhone);
                pb.AddParameter("Email", entity.Email);
                pb.AddParameter("Description", entity.Description);
                return DBFactory.Database.ExecuteNonQuery("RestaurantInfo_Insert", pb.Parameters)>0;
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
                dt = DBFactory.Database.FillDataTable("RestaurantInfo_GetAll", pb.Parameters);
                return dt;
            }
            catch (Exception ex)
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
                dt = DBFactory.Database.FillDataTable("RestaurantInfo_GetByID", pb.Parameters);
                return dt;
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                return null;
            }
        }
        public List<RestaurantInfoEntity> ConvertToList(DataTable dt)
        {
            List<RestaurantInfoEntity> list = new List<RestaurantInfoEntity>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int id = (int)dt.Rows[i][0];
                string nameRestaurant = dt.Rows[i][1].ToString();
                string address = dt.Rows[i][2].ToString();
                string phoneNumber = dt.Rows[i][3].ToString();
                string cellPhone = dt.Rows[i][4].ToString();
                string email = dt.Rows[i][5].ToString();
                string description = dt.Rows[i][6].ToString();
                RestaurantInfoEntity entity = new RestaurantInfoEntity(id,nameRestaurant,address,phoneNumber,cellPhone,email,description);
                list.Add(entity);
            }
            return list;
        }
    }
}
