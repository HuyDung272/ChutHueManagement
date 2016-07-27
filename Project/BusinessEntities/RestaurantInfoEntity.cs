using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChutHueManagement.BusinessEntities
{
    public class RestaurantInfoEntity
    {
        private int _iD;
        private string _nameRestaurant;
        private string _address;
        private string _phoneNumber;
        private string _cellPhone;
        private string _email;
        private string _description;

        public int ID
        {
            get
            {
                return _iD;
            }

            set
            {
                _iD = value;
            }
        }

        public string NameRestaurant
        {
            get
            {
                return _nameRestaurant;
            }

            set
            {
                _nameRestaurant = value;
            }
        }

        public string Address
        {
            get
            {
                return _address;
            }

            set
            {
                _address = value;
            }
        }

        public string PhoneNumber
        {
            get
            {
                return _phoneNumber;
            }

            set
            {
                _phoneNumber = value;
            }
        }

        public string CellPhone
        {
            get
            {
                return _cellPhone;
            }

            set
            {
                _cellPhone = value;
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }

            set
            {
                _email = value;
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }

            set
            {
                _description = value;
            }
        }
        public RestaurantInfoEntity()
        {

        }
        public RestaurantInfoEntity(int iD, string nameRestaurant, string address, string phoneNumber, string cellPhone, string email, string description)
        {
            this._iD = iD;
            this._nameRestaurant = nameRestaurant;
            this._address = address;
            this._phoneNumber = phoneNumber;
            this._cellPhone = cellPhone;
            this._email = email;
            this._description = description;
        }
        public RestaurantInfoEntity( string nameRestaurant, string address, string phoneNumber, string cellPhone, string email, string description)
        {
            this._nameRestaurant = nameRestaurant;
            this._address = address;
            this._phoneNumber = phoneNumber;
            this._cellPhone = cellPhone;
            this._email = email;
            this._description = description;
        }
    }
}
