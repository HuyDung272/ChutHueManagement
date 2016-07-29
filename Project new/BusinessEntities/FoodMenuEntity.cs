using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChutHueManagement.BusinessEntities
{
    public class FoodMenuEntity
    {
        private int _iD;
        private string _nameFood;
        private int _idMainMenu;
        private double _price;
        private bool _isDelete;
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

        public string NameFood
        {
            get
            {
                return _nameFood;
            }

            set
            {
                _nameFood = value;
            }
        }

        public int IdMainMenu
        {
            get
            {
                return _idMainMenu;
            }

            set
            {
                _idMainMenu = value;
            }
        }

        public double Price
        {
            get
            {
                return _price;
            }

            set
            {
                _price = value;
            }
        }

        public bool IsDelete
        {
            get
            {
                return _isDelete;
            }

            set
            {
                _isDelete = value;
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
        public FoodMenuEntity()
        {

        }
        public FoodMenuEntity(int iD, string nameFood, int idMainMenu, double price, bool isDelete, string description)
        {
            this._iD = iD;
            this._nameFood = nameFood;
            this._idMainMenu = idMainMenu;
            this._price = price;
            this._isDelete = isDelete;
            this._description = description;
        }
        public FoodMenuEntity(string nameFood, int idMainMenu, double price, bool isDelete, string description)
        {
            this._nameFood = nameFood;
            this._idMainMenu = idMainMenu;
            this._price = price;
            this._isDelete = isDelete;
            this._description = description;
        }
    }
}
