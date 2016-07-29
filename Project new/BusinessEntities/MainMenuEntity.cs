using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChutHueManagement.BusinessEntities
{
    public class MainMenuEntity
    {
        private int _iD;

        public int ID
        {
            get { return _iD; }
            set { _iD = value; }
        }
        
        private string _nameEntryMenu;

        public string NameEntryMenu
        {
            get { return _nameEntryMenu; }
            set { _nameEntryMenu = value; }
        }
        
        private bool _isDelete;

        public bool IsDelete
        {
            get { return _isDelete; }
            set { _isDelete = value; }
        }

        private string _description;

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public MainMenuEntity()
        {

        }
        
        public MainMenuEntity(string nameEntryMenu, bool isDelete, string description)
        {
            _iD = 0;
            _nameEntryMenu = nameEntryMenu;
            _isDelete = isDelete;
            _description = description;
        }
     
        public MainMenuEntity(int iD, string nameEntryMenu, bool isDelete, string description)
        {
            _iD = iD;
            _nameEntryMenu = nameEntryMenu;
            _isDelete = isDelete;
            _description = description;
        }
    }
}


