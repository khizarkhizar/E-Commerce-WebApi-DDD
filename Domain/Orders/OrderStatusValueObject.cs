 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
namespace Domain.Orders
{
    public enum OrderStatusValue
    {
        Pending,
        Processing,
        Shipped,
        Delivered,
        Canceled
    }
   
    //public class OrderStatusValueObject 
    //{
        
    //    public OrderStatusValue Value { get; private set; }

    //    private OrderStatusValueObject(OrderStatusValue value)
    //    {
    //        Value = value;
    //    }

    //    public static OrderStatusValueObject Pending => new OrderStatusValueObject(OrderStatusValue.Pending);
    //    public static OrderStatusValueObject Processing => new OrderStatusValueObject(OrderStatusValue.Processing);
    //    public static OrderStatusValueObject Shipped => new OrderStatusValueObject(OrderStatusValue.Shipped);
    //    public static OrderStatusValueObject Delivered => new OrderStatusValueObject(OrderStatusValue.Delivered);
    //    public static OrderStatusValueObject Canceled => new OrderStatusValueObject(OrderStatusValue.Canceled);

    //}
}
