using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChutHueManagement.BusinessEntities
{
    
    public class LogBackupRestoreEntity
    {
        
        private int _id;

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        
        private bool _isBackup;

        public bool IsBackup
        {
            get { return _isBackup; }
            set { _isBackup = value; }
        }
    
        private string _note;

        public string Note
        {
            get { return _note; }
            set { _note = value; }
        }

        private DateTime _datetime;
        public DateTime Date
        {
            get { return _datetime; }
            set { _datetime = value; }
        }

        private string _paths;
        public string Path
        {
            get { return _paths; }
            set { _paths = value; }
        }

        
        public LogBackupRestoreEntity()
        {

        }

        
        public LogBackupRestoreEntity(string name, DateTime date,bool isBackup, string path, string note)
        {
            _id = 0;
            _name = name;
            _datetime = date;
            _isBackup = isBackup;
            _paths = path;
            _note = note;
        }
        
        public LogBackupRestoreEntity(int iD, string name, DateTime date, bool isBackup, string path, string note)
        {
            _id = iD;
            _name = name;
            _datetime = date;
            _isBackup = isBackup;
            _paths = path;
            _note = note;
        }
    }
}

