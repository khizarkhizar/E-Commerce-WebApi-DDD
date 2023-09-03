using Domain.Base;
using Domain.Categories;
using Domain.Orders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Items;
[Serializable]
public partial class Item : BaseEntity<int>
{
     public Item(string ItemNme, string ItemDesc,string Brnd, decimal Price, int? rvew, int Rvew,int Stock) { }
    public string ItemNme { get; private set; } = null!;
    public string ItemDesc { get; private set; } = null!;

    public string? Brnd { get; private set; }
    public double Price { get; private set; }

    public int? Rvew { get; private set; }

    public int? Stock { get; private set; }
    [ForeignKey("Ctgr")]
    public int? CategoryId { get; private set; }
    [ForeignKey("CategoryId")]
    public virtual CtgrNme Ctgr { get; private set; } = null!;
    public virtual ICollection<OrderItem> OrderItems { get; private set; } = new List<OrderItem>();

}
