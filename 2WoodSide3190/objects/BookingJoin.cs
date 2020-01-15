using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2WoodSide3190.objects
{
   public class BookingJoin
    {
        //Declaration of private variables
        private int _bookingId;
        private DateTime _date;

        private bool _paid;
        private string _name;
        private int _age;

        //The constructor encapsulates the properties
        public BookingJoin(int bookingId, DateTime date, bool paid, string name, int age) 
        {
            BookingId = bookingId;
            Date = date;
            Paid = paid;
            Name = name;
            Age = age;

        }
        //Default constrcutor assigns everything to null
        public BookingJoin() 
        {
            BookingId = 0;
            Date = Convert.ToDateTime(null);
            Paid = false;
            Name = null;
        }
        //Encapsualtion of the Booking and Children private variables to public properties which can be called elsewhere in the program
        public int BookingId 
        { 
        get { return _bookingId; }
        set { _bookingId = value; }
        }

        public DateTime Date 
        { 
        get { return _date; }
        set { _date = value; }
        }

        public bool Paid 
        { 
        get { return _paid; }
        set { _paid = value; }
        }

        public string Name
        { 
        get { return _name; }
        set { _name = value; }
        }

        public int Age 
        { 
        get { return _age; }
        set { _age = value; }
        }

   /*     public string ParentName 
        { 
        get { return _parentName; }
        set { _parentName = value; }
        }

        public string BusRoute 
        { 
        get { return _busRoute; }
        set { _busRoute = value; }
        }  */
    }
}
