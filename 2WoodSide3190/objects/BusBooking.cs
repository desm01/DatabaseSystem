using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2WoodSide3190.objects
{
    class BusBooking
    {
        //Declaration of private variables
        private int _busBookingId;
        private int _busId;
        private int _staffId;

        private string _driver;
        private string _staff;
        //The constructor encapsulates the properties

        public BusBooking(int busBookingId, int busId, int staffId, string driver, string staff) 
        {
            BusBookingId = busBookingId;
            BusId = busId;
            StaffId = staffId;
            Driver = driver;
            Staff = staff;
        }
        //Default constrcutor assigns everything to null
        public BusBooking() 
        {
            BusBookingId = 0;
            BusId = 0;
            StaffId = 0;
            Driver = null;
            Staff = null;
        }

        //Encapsualtion of the BusBooking private variables to public properties which can be called elsewhere in the program
        public int BusBookingId
        {
            get { return _busBookingId; }
            set { _busBookingId = value; }
        }

        public int BusId
        {
            get { return _busId; }
            set { _busId = value; }
        }

        public int StaffId
        {
            get { return _staffId; }
            set { _staffId = value; }
        }

        public string Driver 
        { 
        get { return _driver; }
        set { _driver = value; }
        }

        public string Staff 
        { 
        get { return _staff; }
        set { _staff = value; }
        }

    }
}
