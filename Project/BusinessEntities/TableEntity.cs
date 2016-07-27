using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChutHueManagement.BusinessEntities
{
    public class TableEntity
    {
        private int _iD;
        private string _tableName;

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

        public string TableName
        {
            get
            {
                return _tableName;
            }

            set
            {
                _tableName = value;
            }
        }
        public TableEntity()
        {

        }

        public TableEntity(int iD, string tableName)
        {
            this._iD = iD;
            this._tableName = tableName;
        }
        public TableEntity( string tableName)
        {
            this._tableName = tableName;
        }
    }
}
