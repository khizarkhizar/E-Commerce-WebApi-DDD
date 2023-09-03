using Domain.Items;
using Domain.Orders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 
namespace WebApplication2.Application.Dto
{
    public class OrderItemDtoResponse
    { 
        public int? ItemId { get;   set; }

        public Item? Item { get;   set; }
    
        public int OrderId { get;   set; }
        public virtual Order Order { get;   set; } = null!;

        public double Price { get;   set; }

        public int Qnty { get;   set; }

    }

}
