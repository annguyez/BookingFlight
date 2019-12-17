using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NguyenVietCongAn
{
    class Aircrafts
    {
        private string _name;
        private string _makeModel;
        private int _iD;
        private int _totalSeats;
        private int _economySeats;
        private int _businessSeats;

        public string Name { get => _name; set => _name = value; }
        public string MakeModel { get => _makeModel; set => _makeModel = value; }
        public int ID { get => _iD; set => _iD = value; }
        public int TotalSeats { get => _totalSeats; set => _totalSeats = value; }
        public int EconomySeats { get => _economySeats; set => _economySeats = value; }
        public int BusinessSeats { get => _businessSeats; set => _businessSeats = value; }
        public Aircrafts() { }
        public Aircrafts(int id, string name, string makeModel, int totalSeats, int economySeats, int businessSeats)
        {
            this.Name = name;
            this.MakeModel = makeModel;
            this.ID = id;
            this.TotalSeats = totalSeats;
            this.EconomySeats = economySeats;
            this.BusinessSeats = businessSeats;
        }
    }
}
