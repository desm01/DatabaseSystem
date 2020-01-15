using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2WoodSide3190.objects
{
    class Parent
    {
    //Declaration of private variables
        private int _parentId;
        private string _parentName;
        private string _parentPhone;
        private string _parentEmail;
        private string _parentAddress;
        private string _parentOccupation;


        //The constructor encapsulates the properties
        public Parent(int parentId, string parentName, string parentPhone, string parentEmail, string parentAddress, string parentOccupation) 
        {
            ParentId = parentId;
            ParentName = parentName;
            ParentPhone = parentPhone;
            ParentEmail = parentEmail;
            ParentAddress = parentAddress;
            ParentOccupation = parentOccupation;
        }
        //Default constrcutor assigns everything to null
        public Parent() 
        {
            ParentId = 0;
            ParentName = null;
            ParentPhone = null;
            ParentEmail = null;
            ParentAddress = null;
            ParentOccupation = null;
        }
        //Encapsualtion of parents private variables to public properties which can be called elsewhere in the program
        public int ParentId
        {
            get { return _parentId; }
            set { _parentId = value; }
        }

        public string ParentName
        {
            get { return _parentName; }
            set { _parentName = value; }
        }

        public string ParentPhone
        {
            get { return _parentPhone; }
            set { _parentPhone = value; }
        }

        public string ParentEmail
        {
            get { return _parentEmail; }
            set { _parentEmail = value; }
        }

        public string ParentAddress
        {
            get { return _parentAddress; }
            set { _parentAddress = value; }
        }

        public string ParentOccupation
        {
            get { return _parentOccupation; }
            set { _parentOccupation = value; }
        }

    }
}
