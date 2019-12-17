using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NguyenVietCongAn
{
    class Airports
    {
        private int _iD;

        public int ID
        {
            get { return _iD; }
            set { _iD = value; }
        }
        private string _IATACode, _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string IATACode
        {
            get { return _IATACode; }
            set { _IATACode = value; }
        }
        //private Countries country;
        public Airports() { }
        public Airports(int id, string name)
        {
            this.ID = id;
            this.Name = name;
        }
        public Airports(int id)
        {
            this.ID = id;
        }
    }
}
