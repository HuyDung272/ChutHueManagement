using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChutHueManagement.BusinessEntities
{
    public class AccountEntity
    {
        private int _iD;

        public int ID
        {
            get { return _iD; }
            set { _iD = value; }
        }
        
        private string _userName;

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        
        private string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        private string _description;

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public AccountEntity()
        {

        }
        
        public AccountEntity(string userName, string pass, string description)
        {
            _iD = 0;
            _userName = userName;
            _password = pass;
            _description = description;         
        }
     
        public AccountEntity(int iD, string userName, string pass, string description)
        {
            _iD = iD;
            _userName = userName;
            _password = pass;
            _description = description;
        }
    }
}

