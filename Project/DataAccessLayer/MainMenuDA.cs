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
    public class MainMenuDA
    {
        public MainMenuDA()
        {

        }

        public int Insert(MainMenuEntity entity)
        {
            try
            {
                ParameterBuilder pb = DBFactory.CreateParamBuilder();
                pb.AddParameter("NameEntryMenu", entity.NameEntryMenu);
                pb.AddParameter("IsDelete", "False");
                pb.AddParameter("Description", entity.Description);
                return (int)DBFactory.Database.ExecuteNonQuery("MainMenu_Insert", pb.Parameters);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                return 0;
            }
        }

        public bool UpDate(MainMenuEntity entity)
        {
            try
            {
                ParameterBuilder pb = DBFactory.CreateParamBuilder();
                pb.AddParameter("ID", entity.ID);
                pb.AddParameter("NameEntryMenu", entity.NameEntryMenu);
                pb.AddParameter("IsDelete", entity.IsDelete);
                pb.AddParameter("Description", entity.Description);
                
                int numRowEffected = DBFactory.Database.ExecuteNonQuery("MainMenu_UpDate", pb.Parameters);
                return (numRowEffected > 0);
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

                dt = DBFactory.Database.FillDataTable("MainMenu_GetAll", pb.Parameters);
                return dt;
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                throw new Exception(ex.Message, ex);
            }
        }

        public DataTable GetAllNotDelete()
        {
            try
            {
                DataTable dt = new DataTable();
                ParameterBuilder pb = DBFactory.CreateParamBuilder();

                dt = DBFactory.Database.FillDataTable("MainMenu_GetAllNotDelete", pb.Parameters);
                return dt;
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                throw new Exception(ex.Message, ex);
            }
        }


        public List<MainMenuEntity> ConvertToList(DataTable dt)
        {
            List<MainMenuEntity> list = new List<MainMenuEntity>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int id = (int)dt.Rows[i][0];
                string nameEntryMenu = dt.Rows[i][1].ToString();
                bool isDelete = (bool)dt.Rows[i][2];
                string description = dt.Rows[i][3].ToString();
                MainMenuEntity acc = new MainMenuEntity(id, nameEntryMenu, isDelete, description);
                list.Add(acc);
            }
            return list;
        }
    }
}
