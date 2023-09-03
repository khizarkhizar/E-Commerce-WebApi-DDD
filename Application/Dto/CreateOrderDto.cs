using Domain.Orders;
using System.Collections.ObjectModel;

namespace WebApplication2.Application.Dto
{
    public class CreateOrderDto
    {
        public string? TrackingId { get;     set; } 

        public OrderStatusValue? Status { get;   set; }

        public DateTime CreatedAt { get;   set; }

        public DateTime? UpdatedAt { get;   set; }
         

        public int Qnty { get;   set; } 
         

        public int  AddressId { get; set; }

        public int ItemId { get; set; }    

          
    }
 
} 
