using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChutHueManagement.BusinessEntities
{
    public class LogSystemEntity
    {
        private int _iD;

        public int ID
        {
            get { return _iD; }
            set { _iD = value; }
        }

        private int _iDAccount;

        public int IDAccount
        {
            get { return _iDAccount; }
            set { _iDAccount = value; }
        }

       
        private string _event;

        public string Event
        {
            get { return _event; }
            set { _event = value; }
        }

        private DateTime _dateTime;

        public DateTime Date
        {
            get
            {
                return _dateTime;
            }

            set
            {
                _dateTime = value;
            }
        }

        public LogSystemEntity()
        {

        }

        public LogSystemEntity(int iDAccount, string events, DateTime datetime)
        {
            _iD = 0;
            _iDAccount = IDAccount;
            _event = events;
            _dateTime = datetime;
        }

        public LogSystemEntity(int iD, int iDAccount, string events, DateTime datetime)
        {
            _iD = 0;
            _iDAccount = IDAccount;
            _event = events;
            _dateTime = datetime;
        }
    }
}


