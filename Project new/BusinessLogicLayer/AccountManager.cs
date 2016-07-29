using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChutHueManagement.Utilities;
using ChutHueManagement.DataProvider;
using ChutHueManagement.BusinessEntities;
using ChutHueManagement.DataAccessLayer;
using System.Data;

namespace ChutHueManagement.BusinessLogicLayer
{
    public class AccountManager
    {
        private static AccountDA adapter = null;

        static AccountManager()
        {
            if (adapter == null)
                adapter = new AccountDA();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static int Insert(AccountEntity entity)
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static bool UpDate(AccountEntity entity)
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

        public static DataTable LogIn(string UserName, string Password)
        {
            try
            {
                return adapter.LogIn(UserName, Password);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                return null;
            }
        }

        public static DataTable LogIn(string UserName, string Password, ref string errormessage)
        {
            try
            {
                return adapter.LogIn(UserName, Password);
            }
            catch (Exception ex)
            {
                errormessage = ex.Message;
                Logger.Write(ex);
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DataTable Find_All()
        {
            try
            {
                return adapter.Find_All();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static DataTable Find_UserName(string username)
        {
            try
            {
                return adapter.Find_UserName(username);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="oldpass"></param>
        /// <param name="newpass"></param>
        /// <returns></returns>
        public static bool ChangePass(string username, string oldpass, string newpass)
        {
            try
            {
                return adapter.ChangePass(username, oldpass, newpass);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                return false;
            }
        }

        public static bool ChangePass(string username, string oldpass, string newpass, ref string errormessage)
        {
            try
            {
                return adapter.ChangePass(username, oldpass, newpass);
            }
            catch (Exception ex)
            {
                errormessage = ex.Message;
                Logger.Write(ex);
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="oldpass"></param>
        /// <param name="newpass"></param>
        /// <param name="errormessage"></param>
        /// <returns></returns>
        
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<AccountEntity> ConvertToList(DataTable dt)
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



