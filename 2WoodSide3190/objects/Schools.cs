using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2WoodSide3190.objects
{
   public class Schools
    {
        //Declaration of private variables
        private int _schoolId;
        private string _schoolName;
        private string _schoolLocation;
        private string _schoolAddress;
        private int _schoolNumber;
        private string _schoolEmail;
        //The constructor encapsulates the properties
        public Schools(int schoolId, string schoolName, string schoolLocation, string schoolAddress, int schoolNumber, string schoolEmail) 
        {
            SchoolId = schoolId;
            SchoolName = schoolName;
            SchoolLocation = schoolLocation;
            SchoolAddress = schoolAddress;
            SchoolNumber = schoolNumber;
            SchoolEmail = schoolEmail;                    
        }
        //Default constrcutor assigns everything to null
        public Schools() 
        {
            SchoolId = 0;
            SchoolName = null;
            SchoolLocation = null;
            SchoolAddress = null;
            SchoolNumber = 0;
            SchoolEmail = null;
        }
        //Encapsualtion of schools private variables to public properties which can be called elsewhere in the program
        public int SchoolId
        {
            get { return _schoolId; }
            set { _schoolId = value; }
        }

        public string SchoolName
        {
            get { return _schoolName; }
            set { _schoolName = value; }
        }

        public string SchoolLocation
        {
            get { return _schoolLocation; }
            set { _schoolLocation = value; }
        }

        public string SchoolAddress
        {
            get { return _schoolAddress; }
            set { _schoolAddress = value; }
        }

        public int SchoolNumber
        {
            get { return _schoolNumber; }
            set { _schoolNumber = value; }
        }

        public string SchoolEmail
        {
            get { return _schoolEmail; }
            set { _schoolEmail = value; }
        }

    }
}
