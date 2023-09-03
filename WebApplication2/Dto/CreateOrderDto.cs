using Domain.Orders;
using System.Collections.ObjectModel;

namespace WebApplication2.Dto
{
    public class CreateOrderDto
    {
        public string? TrackingId { get; private set; } 

        public OrderStatusValue? Status { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public DateTime? UpdatedAt { get; private set; }
         

        public int Qnty { get; private set; } 
         

        public int? AddressId { get; set; }

        public int? ItemId { get; set; }    

          
    }
 
} 
