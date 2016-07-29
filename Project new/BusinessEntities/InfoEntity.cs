using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChutHueManagement.BusinessEntities
{
    public class InfoEntity
    {
        private int _iD;

        public int ID
        {
            get { return _iD; }
            set { _iD = value; }
        }

        private string _nameRestaurant;

        public string NameRestaurant
        {
            get { return _nameRestaurant; }
            set { _nameRestaurant = value; }
        }

        private string _addreess;

        public string Address
        {
            get { return _addreess; }
            set { _addreess = value; }
        }

        private string _phoneNumber;

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }

        private string _cellNumber;

        public string CellNumber
        {
            get { return _cellNumber; }
            set { _cellNumber = value; }
        }

        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private string _description;

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public InfoEntity()
        {

        }

        public InfoEntity(string nameRestaurant, string addreess, string phoneNumber, string cellNumber, string email, string description)
        {
            _iD = 0;
            _nameRestaurant = nameRestaurant;
            _addreess = addreess;
            _phoneNumber = phoneNumber;
            _cellNumber = cellNumber;
            _email = email;
            _description = description;
        }

        public InfoEntity(int iD, string nameRestaurant, string addreess, string phoneNumber, string cellNumber, string email, string description)
        {
            _iD = iD;
            _nameRestaurant = nameRestaurant;
            _addreess = addreess;
            _phoneNumber = phoneNumber;
            _cellNumber = cellNumber;
            _email = email;
            _description = description;
        }
    }
}

