

using Domain.Addresses; 
using Domain.Base;
using System.Net;  

namespace Domain.Orders;

public partial class Order : BaseEntity<int>
{
 


    public string? TrackingId { get; private set; } 
 
    public OrderStatusValue? Status { get; private set; }
     
    public DateTime CreatedAt { get; private set; }

    public DateTime? UpdatedAt { get; private set; } 
    public virtual ICollection<OrderItem> OrderItems { get; private set; } = new List<OrderItem>();
    public virtual ICollection<Addr> Address { get; private set; }



}
