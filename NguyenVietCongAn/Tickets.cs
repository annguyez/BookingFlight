using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NguyenVietCongAn
{
    class Tickets
    {
        private int _iD;

        public int ID
        {
            get { return _iD; }
            set { _iD = value; }
        }
        private Schedules _schedule;

        internal Schedules Schedule
        {
            get { return _schedule; }
            set { _schedule = value; }
        }
        private CabinTypes _cabintype;

        internal CabinTypes Cabintype
        {
            get { return _cabintype; }
            set { _cabintype = value; }
        }
        private Countries _country;

        internal Countries Country
        {
            get { return _country; }
            set { _country = value; }
        }
        private string _firstname, _lastname, _email, _phone, _passport_number, _booking_referrence, _birthdate;

        public string Birthdate
        {
            get { return _birthdate; }
            set { _birthdate = value; }
        }

        public string Booking_referrence
        {
            get { return _booking_referrence; }
            set { _booking_referrence = value; }
        }

        public string Passport_number
        {
            get { return _passport_number; }
            set { _passport_number = value; }
        }

        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Lastname
        {
            get { return _lastname; }
            set { _lastname = value; }
        }

        public string Firstname
        {
            get { return _firstname; }
            set { _firstname = value; }
        }
        private int _confirm;

        public int Confirm
        {
            get { return _confirm; }
            set { _confirm = value; }
        }

        public Tickets() { }
        public Tickets(string firstname, string lastname, string birthdate, string passport_number, Countries country, string phone)
        {
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Birthdate = birthdate;
            this.Passport_number = passport_number;
            this.Country = country;
            this.Phone = phone;
        }
    }
}
