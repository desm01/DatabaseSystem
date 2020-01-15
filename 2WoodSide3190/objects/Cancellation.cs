using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2WoodSide3190.objects
{
   public class Cancellation
    {
        //Declaration of private variables
        private int _cancellationId;
        private int _bookingId;
        private int _childId;
        private DateTime _date;
        private string _reason;
        //The constructor encapsulates the properties
        public Cancellation(int cancellationId, int bookingId, int childId, DateTime date, string reason) 
        {
            CancellationId = cancellationId;
            BookingId = bookingId;
            ChildId = childId;
            Date = date;
            Reason = reason;
        }
        //Default constrcutor assigns everything to null
        public Cancellation() 
        {
            CancellationId = 0;
            BookingId = 0;
            ChildId = 0;
            Date = DateTime.Now;
            Reason = null;
        }

        //Encapsualtion of the cancelation private variables to public properties which can be called elsewhere in the program
        public int CancellationId
        {
            get { return _cancellationId; }
            set { _cancellationId = value; }
        }

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

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public string Reason 
        { 
        get { return _reason; }
        set { _reason = value; }
        }

    }
}
