using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2WoodSide3190.objects
{
    class ChildParentJoin
    {
        //Declaration of private variables which will be used in the innerjoin 
        private int _childId;
        private string _childName;
        private string _medicalDetails;
        private int _age;
        private string _schoolName;
        private string _parentName;
        private string _parentEmail;
        private string _parentPhone;
        private string _address;

        //The constructor encapsulates the properties
        public ChildParentJoin(int childId, string childName, string medicalDetails, int age, string schoolName, string parentName, string parentEmail, string parentPhone, string address ) 
        {
            ChildId = childId;
            ChildName = childName;
            MedicalDetails = medicalDetails;
            Age = age;
            SchoolName = schoolName;
            ParentName = parentName;
            ParentEmail = parentEmail;
            ParentPhone = parentPhone;
            Address = address;
        }
        //Default constrcutor assigns everything to null
        public ChildParentJoin() 
        {
            ChildId = 0;
            ChildName = null;
            MedicalDetails = null;
            ParentName = null;
            Address = null;
        }
        //Encapsualtion of children and parents private variables to public properties which can be called elsewhere in the program
        public int ChildId 
        { 
        get { return _childId; }
        set { _childId = value; }
        }

        public string ChildName 
        { 
        get { return _childName; }
        set { _childName = value; }
        }

        public string MedicalDetails 
        { 
        get { return _medicalDetails; }
        set { _medicalDetails = value; }
        }

        public int Age 
        { 
        get { return _age; }
        set { _age = value; }
        }

        public string SchoolName
        {
            get { return _schoolName; }
            set { _schoolName = value; }
        }

        public string ParentName 
        { 
        get { return _parentName; }
        set { _parentName = value; }
        }

        public string ParentEmail
        {
            get { return _parentEmail; }
            set { _parentEmail = value; }
        }

        public string ParentPhone
        {
            get { return _parentPhone; }
            set { _parentPhone = value; }
        }

        public string Address 
        { 
        get { return _address; }
        set { _address = value; }
        }
    }
}
