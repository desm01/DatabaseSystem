using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2WoodSide3190.objects
{
    class Staff
    {
        //Declaration of private variables
        private int _staffId;
        private string _staffName;
        private int _staffNumber;
        private string _staffAddress;
        private string _staffEmail;
        private bool _staffVoluntary;


        //The constructor encapsulates the properties
        public Staff(int staffId, string staffName, int staffNumber, string staffAddress, string staffEmail, bool staffVoluntary) 
        {
            StaffId = staffId;
            StaffName = staffName;
            StaffNumber = staffNumber;
            StaffAddress = staffAddress;
            StaffEmail = staffEmail;
            StaffVoluntary = staffVoluntary;
        }
        //Default constrcutor assigns everything to null
        public Staff () 
        {
            StaffId = 0;
            StaffName = null;
            StaffNumber =0;
            StaffAddress = null;
            StaffEmail = null;
            StaffVoluntary = false;
        }
        //Encapsualtion of staffs private variables to public properties which can be called elsewhere in the program
        public int StaffId
        {
            get { return _staffId; }
            set { _staffId = value; }
        }

        public string StaffName
        {
            get { return _staffName; }
            set { _staffName = value; }
        }

        public int StaffNumber
        {
            get { return _staffNumber; }
            set { _staffNumber = value; }
        }

        public string StaffAddress
        {
            get { return _staffAddress; }
            set { _staffAddress = value; }
        }

        public string StaffEmail
        {
            get { return _staffEmail; }
            set { _staffEmail = value; }
        }

        public bool StaffVoluntary
        {
            get { return _staffVoluntary; }
            set { _staffVoluntary = value; }
        }

    }
}
