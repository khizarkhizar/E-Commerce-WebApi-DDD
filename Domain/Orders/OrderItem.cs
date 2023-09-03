using Domain.Base;
using Domain.Items;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Orders;

public partial class OrderItem : BaseEntity<int>
{
    [ForeignKey("Item")]
    public int? ItemId { get; private set; }
 
    public Item? Item { get; private set; }
    [ForeignKey("Order")] 
    public int OrderId { get; private set; }
    public virtual Order Order { get; private set; } = null!;
 
    public double Price { get; private set; }
   
    public int Qnty { get; private set; }
}
