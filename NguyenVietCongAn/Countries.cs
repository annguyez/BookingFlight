using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NguyenVietCongAn
{
    class Countries
    {
        private int _iD;

        public int ID
        {
            get { return _iD; }
            set { _iD = value; }
        }
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public Countries() { }
        public Countries(int id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}
