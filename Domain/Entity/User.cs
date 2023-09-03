////using Microsoft.AspNetCore.Identity;
//using Domain.Addresses;
//using Domain.Base;
//using Domain.Orders;
//using System;
//using System.Collections.Generic;

//namespace WebApplication2.Domain.Entity;
//[Serializable]
//public  partial class User :BaseEntity<int>// : IdentityUser<long>
//{
//    public long UserId { get; set; }

//    public string UserLognId { get; set; } = null!;

//    public string PassKey { get; set; } = null!;

//    public int Role { get; set; }

//    public string Name { get; set; } = null!;

//    public virtual ICollection<Addr> Addrs { get; set; } = new List<Addr>();

//    //public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

//    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

//    public virtual ICollection<UsrSesn> UsrSesns { get; set; } = new List<UsrSesn>();
//}
