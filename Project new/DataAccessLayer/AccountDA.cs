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
    public class AccountDA
    {
        public AccountDA()
        {

        }
     
        public int Insert(AccountEntity entity)
        {
            try
            {
                ParameterBuilder pb = DBFactory.CreateParamBuilder();
                pb.AddParameter("UserName", entity.UserName);
                pb.AddParameter("Password", entity.Password);
                pb.AddParameter("Description", entity.Description);    
                return (int)DBFactory.Database.ExecuteNonQuery("Account_Insert", pb.Parameters);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                return 0;
            }
        }
        
        public bool UpDate(AccountEntity entity)
        {
            try
            {
                ParameterBuilder pb = DBFactory.CreateParamBuilder();
                pb.AddParameter("ID", entity.ID);
                pb.AddParameter("UserName", entity.UserName);
                pb.AddParameter("Password", entity.Password);
                pb.AddParameter("Description", entity.Description);

                int numRowEffected = DBFactory.Database.ExecuteNonQuery("Account_UpDate", pb.Parameters);
                return (numRowEffected > 0);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                return false;
            }
        }
    
        public bool ChangePass(string username, string oldpass, string newpass)
        {
            try
            {
                ParameterBuilder pb = DBFactory.CreateParamBuilder();
                pb.AddParameter("UserName", username);
                pb.AddParameter("OldPass", oldpass);
                pb.AddParameter("NewPass", newpass);

                int numRowEffected = DBFactory.Database.ExecuteNonQuery("Account_ChangePass", pb.Parameters);
                return (numRowEffected > 0);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                throw new Exception(ex.Message);
            }
        }

        public DataTable LogIn(string UserName, string Pass)
        {
            try
            {
                DataTable dt = new DataTable();
                ParameterBuilder pb = DBFactory.CreateParamBuilder();
                pb.AddParameter("UserName", UserName);
                pb.AddParameter("Password", Pass);

                dt = DBFactory.Database.FillDataTable("Account_LogIn", pb.Parameters);
                return dt;
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                throw new Exception(ex.Message, ex);
            }
        }


        /// <summary>
        /// ?????
        /// </summary>
        /// <returns></returns>
        public DataTable Find_All()
        {
            try
            {
                return DBFactory.Database.FillDataTable("SELECT * FROM Account");
            }    
            
            catch (Exception ex)
            {
                Logger.Write(ex);
                return null;
            }
        }
       
        public DataTable Find_UserName(string UserName)
        {
            try
            {
                DataTable dt = new DataTable();
                ParameterBuilder pd = DBFactory.CreateParamBuilder();
                pd.AddParameter("UserName", UserName);

                dt = DBFactory.Database.FillDataTable("Account_Find_UserName", pd.Parameters);
                return dt;
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                return null;
            }
        }    
      
        //public bool Delete(int id)
        //{
        //    try
        //    {
        //        ParameterBuilder pd = DBFactory.CreateParamBuilder();
        //        pd.AddParameter("IDTK", id);

        //        return DBFactory.Database.ExecuteNonQuery("TaiKhoan_Delete", pd.Parameters) > 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.Write(ex);
        //        throw new Exception(ex.Message, ex);
        //    }
        //}
       
        //public bool Delete_UserName(string UserName)
        //{
        //    try
        //    {
        //        ParameterBuilder pd = DBFactory.CreateParamBuilder();
        //        pd.AddParameter("UserName", UserName);

        //        return DBFactory.Database.ExecuteNonQuery("TaiKhoan_Delete_UserName", pd.Parameters) > 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.Write(ex);
        //        throw new Exception(ex.Message, ex);
        //    }
        //}
      
        public List<AccountEntity> ConvertToList(DataTable dt)
        {
            List<AccountEntity> list = new List<AccountEntity>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int id = (int)dt.Rows[i][0];
                string username = dt.Rows[i][1].ToString();
                string password = dt.Rows[i][2].ToString();
                string description = dt.Rows[i][3].ToString();
                AccountEntity acc = new AccountEntity(id, username, password, description);
                list.Add(acc);
            }
            return list;
        }
    }
}
