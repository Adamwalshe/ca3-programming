using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace ca3_programming
{
    internal class Passenger
    {
        private static string? _lastName, _firstName, _age, _gender, _occupation, _natCountry, _destCountry, _portCode, _maniId, _arrivalDate; //private fields for storing the passenger's personal information

        //public properties for accessing and modifying the fields, using the get and set methods.
        public string LastName { get { return _lastName; } set { _lastName = value; } }
        public string FirstName { get { return _firstName; } set { _firstName = value; } }
        public string Age { get { return _age; } set { _age = value; } }
        public string Gender { get { return _gender; } set { _gender = value; } }
        public string Occupation { get { return _occupation; } set { _occupation = value; } }
        public string NatCountry { get { return _natCountry; } set { _natCountry = value; } }
        public string DestCountry { get { return _destCountry; } set { _destCountry = value; } }
        public string PortCode { get { return _portCode; } set { _portCode = value; } }
        public string ManiId { get { return _maniId; } set { _maniId = value; } }
        public string ArrivalDate { get { return _arrivalDate; } set { _arrivalDate = value; } }

        public Passenger(string lastName, string firstName, string age, string gender, string occupation, string natCountry, string destCountry, string portCode, string maniId, string arrivalDate)
        {   //The constructor takes input parameters to initialize the private fields with the passenger's personal information.
            _lastName = lastName;
            _firstName = firstName;
            _age = age;
            _gender = gender;
            _occupation = occupation;
            _natCountry = natCountry;
            _destCountry = destCountry;
            _portCode = portCode;
            _maniId = maniId;
            _arrivalDate = arrivalDate;
        }
    }
}
