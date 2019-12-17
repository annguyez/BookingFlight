using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NguyenVietCongAn
{
    class Routes
    {
        int ID_;

        public int ID
        {
            get { return ID_; }
            set { ID_ = value; }
        }
        float distance_;

        public float Distance
        {
            get { return distance_; }
            set { distance_ = value; }
        }
        string flighttime_;

        public string Flighttime
        {
            get { return flighttime_; }
            set { flighttime_ = value; }
        }
        private Airports _departureAirport, _arrivalAirport;

        internal Airports ArrivalAirport
        {
            get { return _arrivalAirport; }
            set { _arrivalAirport = value; }
        }

        internal Airports DepartureAirport
        {
            get { return _departureAirport; }
            set { _departureAirport = value; }
        }
        public Routes() { }
        public Routes(int id, Airports departure, Airports arrival, float distance, string flightime)
        {
            this.ID = id;
            this.DepartureAirport = departure;
            this.ArrivalAirport = arrival;
            this.Distance = distance;
            this.Flighttime = flightime;
        }
        public Routes(int id, Airports departure, Airports arrival)
        {
            ID = id;
            DepartureAirport = departure;
            ArrivalAirport = arrival;
        }
    }
}
