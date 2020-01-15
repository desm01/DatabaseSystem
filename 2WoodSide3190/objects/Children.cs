using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2WoodSide3190.objects
{
    class Children
    {
        //Declaration of private variables
        private int _childId;
        private int _parentId;
        private int _schoolId;
        private string _childName;
        private string _medicalDetails;
        private int _age;
        //The constructor encapsulates the properties
        public Children( int childId, int parentId, int schoolId, string childName, string medicalDetails, int age) 
        {
            ChildId = childId;
            ParentId = parentId;
            SchoolId = schoolId;
            ChildName = childName;
            MedicalDetails = medicalDetails;
            Age = age;
        }
        //Default constrcutor assigns everything to null
        public Children() 
        {
            ChildId = 0;
            ParentId = 0;
            SchoolId = 0;
            ChildName = null;
            MedicalDetails = null;
            Age = 0;
        }


        //Encapsualtion of childrens private variables to public properties which can be called elsewhere in the program
        public int ChildId
        {
            get { return _childId; }
            set { _childId = value; }
        }

        public int ParentId
        {
            get { return _parentId; }
            set { _parentId = value; }
        }

        public int SchoolId
        {
            get { return _schoolId; }
            set { _schoolId = value; }
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
    }
}
