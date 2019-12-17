using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NguyenVietCongAn
{
    class Schedules
    {
        private string _date, _time;

        private string _flightNumber;

        public string FlightNumber
        {
            get { return _flightNumber; }
            set { _flightNumber = value; }
        }

        public string Time
        {
            get { return _time; }
            set { _time = value; }
        }

        public string Date
        {
            get { return _date; }
            set { _date = value; }
        }
        private int _iD;

        public int ID
        {
            get { return _iD; }
            set { _iD = value; }
        }
        private float _economyPrice;

        public float EconomyPrice
        {
            get { return _economyPrice; }
            set { _economyPrice = value; }
        }
        private bool _confirmed;

        
        private Routes _route;

        public Routes Route
        {
            get { return _route; }
            set { _route = value; }
        }
        private Aircrafts _aircraft;

        internal Aircrafts Aircraft
        {
            get { return _aircraft; }
            set { _aircraft = value; }
        }

        public bool Confirmed { get => _confirmed; set => _confirmed = value; }

        public Schedules() { }
        public Schedules(int id, string date, string time, string flightnumber, float economyprice, bool confirmed, Routes route, Aircrafts aircraft)
        {
            ID = id;
            Date = date;
            Time = time;
            FlightNumber = flightnumber;
            EconomyPrice = economyprice;
            Confirmed = confirmed;
            Route = route;
            Aircraft = aircraft;
        }
        public Schedules(int id, string date, string time, string flightnumber, float economyprice, bool confirmed, Routes route)
        {
            ID = id;
            Date = date;
            Time = time;
            FlightNumber = flightnumber;
            EconomyPrice = economyprice;
            Confirmed = confirmed;
            Route = route;

        }
    }
}
