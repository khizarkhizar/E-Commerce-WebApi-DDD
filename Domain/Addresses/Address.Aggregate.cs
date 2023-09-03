using Domain.Base;  
using System;
using System.Linq;

namespace Domain.Addresses
{
    public partial class Addr : IAggregateRoot
    {
        public Addr(int Id,string StrtAddr, string City, string Cntry, string ZipCode) 
        { 

            this.Update(
                Id,
                StrtAddr
                , City
                , Cntry
                , ZipCode 
            );
        }

        public void Update(int id,string StrtAddr
                ,string City
                ,string Cntry
                ,string ZipCode )
        {
            this.Id = id;
            this.StrtAddr = StrtAddr;
            this.City = City;
            this.Cntry = Cntry;
            this.ZipCode = ZipCode; 
        }

        

         
    }
}