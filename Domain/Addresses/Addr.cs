 
using Domain.Base;
using Domain.Orders;
using System;
using System.Collections.Generic;

namespace Domain.Addresses;

public partial class Addr : BaseEntity<int>
{
    public Addr( )
    {
        
    }
    public AddressValueObject Address;
    public string StrtAddr { get; private set; } = null!;

    public string City { get; private set; } = null!;

    public string Cntry { get; private set; } = null!;

    public string? ZipCode { get; private set; }

    public string? CompleteAddress { get; private set; }
    public virtual ICollection<Order> Orders { get; private set; } = new List<Order>();
    public void getAddress(
      string Street, string City, string Country, string ZipCode
      )
    {

        Address = new AddressValueObject(Street, City, Country, ZipCode);
        CompleteAddress = Address.CompleteAddress;

    }
}
