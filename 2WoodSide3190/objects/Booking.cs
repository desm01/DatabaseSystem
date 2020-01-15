using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2WoodSide3190.objects
{
  public  class Booking
    {
        //Declaration of private variables
        private int _bookingId;
        private int _childId;
        private int _busBookingId;
        private bool _paid;
        private DateTime _time;
        //The constructor encapsulates the properties
        public Booking(int bookingId, int childId, int busBookingId, bool paid, DateTime time) 
        {
            BookingId = bookingId;
            ChildId = childId;
            BusBookingId = busBookingId;
            Paid = paid;
            Time = time;
        }
        //Default constrcutor assigns everything to null
        public Booking() 
        {
            BookingId = 0;
            ChildId = 0;
            BusBookingId = 0;
            Paid = false;
            Time = DateTime.Now;
        }
        //Encapsualtion of the Booking private variables to public properties which can be called elsewhere in the program
        public int BookingId
        {
            get { return _bookingId; }
            set { _bookingId = value; }
        }

        public int ChildId
        {
            get { return _childId; }
            set { _childId = value; }
        }

        public int BusBookingId
        {
            get { return _busBookingId; }
            set { _busBookingId = value; }
        }

        public bool Paid
        {
            get { return _paid; }
            set { _paid = value; }
        }

        public DateTime Time
        {
            get { return _time; }
            set { _time = value; }
        }

    }
}
