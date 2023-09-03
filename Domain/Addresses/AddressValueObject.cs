using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Addresses
{
    public class AddressValueObject
    {

        public string _Street { get; private set; }
        public string _City { get; private set; }
        public string _Country { get; private set; }
        public string _ZipCode { get; private set; }
        public string CompleteAddress { get; private set; }

        public AddressValueObject(string Street, string City, string  Country, string  ZipCode)
        {

            _Street = Street;
            _City = City;
            _Country =  Country;
            _ZipCode =  ZipCode;

            CompleteAddress = $"Zip Code {_ZipCode}, Street # {Street}, City {City}, Country {_Country}";


        }


    }
}
