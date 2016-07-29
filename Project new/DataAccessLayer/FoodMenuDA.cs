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
    public class FoodMenuDA
    {
        public FoodMenuDA()
        {

        }
        public int Insert(FoodMenuEntity entity)
        {
            try
            {
                ParameterBuilder pb = DBFactory.CreateParamBuilder();
                pb.AddParameter("NameFood", entity.NameFood);
                pb.AddParameter("IDMainMenu", entity.IdMainMenu);
                pb.AddParameter("Price", entity.Price);
                pb.AddParameter("IsDelete", entity.IsDelete);
                pb.AddParameter("Description", entity.Description);
                return (int)DBFactory.Database.ExecuteNonQuery("FoodMenu_Insert", pb.Parameters);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                throw new Exception(ex.Message, ex);
            }
        }
        public bool UpDate(FoodMenuEntity entity)
        {
            try
            {
                ParameterBuilder pb = DBFactory.CreateParamBuilder();
                pb.AddParameter("ID", entity.ID);
                pb.AddParameter("NameFood", entity.NameFood);
                pb.AddParameter("IDMainMenu", entity.IdMainMenu);
                pb.AddParameter("Price", entity.Price);
                pb.AddParameter("IsDelete", entity.IsDelete);
                pb.AddParameter("Description", entity.Description);
                return DBFactory.Database.ExecuteNonQuery("FoodMenu_UpDate", pb.Parameters) > 0;
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                throw new Exception(ex.Message, ex);
            }
        }

        public DataTable GetAll()
        {
            try
            {
                DataTable dt = new DataTable();
                //ParameterBuilder pb = DBFactory.CreateParamBuilder();
                dt = DBFactory.Database.FillDataTable("FoodMenu_GetAll");
                return dt;
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                throw new Exception(ex.Message, ex);
            }
        }
        public DataTable GetByID(int iD)
        {
            try
            {
                DataTable dt = new DataTable();
                ParameterBuilder pb = DBFactory.CreateParamBuilder();
                pb.AddParameter("ID", iD);
                dt = DBFactory.Database.FillDataTable("FoodMenu_GetByID",pb.Parameters);
                return dt;
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                throw new Exception(ex.Message, ex);
            }
        }

        public DataTable GetByIDMainMenu(int idMainMenu)
        {
            try
            {
                DataTable dt = new DataTable();
                ParameterBuilder pb = DBFactory.CreateParamBuilder();
                pb.AddParameter("IDMainMenu", idMainMenu);
                dt = DBFactory.Database.FillDataTable("FoodMenu_GetByIDMainMenu", pb.Parameters);
                return dt;
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                throw new Exception(ex.Message, ex);
            }
        }
        public List<FoodMenuEntity> ConvertToList(DataTable dt)
        {
            List<FoodMenuEntity> list = new List<FoodMenuEntity>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int id = (int)dt.Rows[i][0];
                string nameFood = dt.Rows[i][1].ToString();
                int idMainMenu = (int)dt.Rows[i][2];
                double price = (double)dt.Rows[i][3];
                bool isDelete = (bool)dt.Rows[i][4];
                string description = dt.Rows[i][5].ToString();
                FoodMenuEntity foodMenu = new FoodMenuEntity(id, nameFood, idMainMenu, price, isDelete, description);
                list.Add(foodMenu);
            }
            return list;
        }

    }
}
