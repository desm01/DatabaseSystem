using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2WoodSide3190.objects
{
    class Bus
    {
        //Declaration of private variables
        private int _busId;
        private string _busRoute;
        private string _busDriver;
        private int _busTime;
        //The constructor encapsulates the properties
        public Bus(int busId, string busRoute, string busDriver, int busTime) 
        {
            BusId = busId;
            BusRoute = busRoute;
            BusDriver = busDriver;
            BusTime = busTime;
        }
        //Default constrcutor assigns everything to null
        public Bus() 
        {
            BusId = 0;
            BusRoute = null;
            BusDriver = null;
            BusTime = 0;
        }
        //Encapsualtion of the Bus private variables to public properties which can be called elsewhere in the program
        public int BusId
        {
            get { return _busId; }
            set { _busId = value; }
        }

        public string BusRoute
        {
            get { return _busRoute; }
            set { _busRoute = value; }
        }

        public string BusDriver
        {
            get { return _busDriver; }
            set { _busDriver = value; }
        }

        public int BusTime
        {
            get { return _busTime; }
            set { _busTime = value; }
        }

    }
}
