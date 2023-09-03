using Domain.Addresses; 
using Domain.Base;
using Domain.Items;
using System.Linq;

namespace Domain.Orders
{
    public partial class OrderItem : IAggregateRoot
    {
        
        public OrderItem(int? ItemId , int OrderId,  double Price, int Qnty )
        { 

            this.Update (
              ItemId,     OrderId,  Price,   Qnty
            );
        }

        

        public void Update(int? ItemId,  int OrderId,   double Price, int Qnty)
        {
            this.ItemId = ItemId;  
            this.OrderId = OrderId;
            this.Price = Price;
            this.Qnty = Qnty; 


        }

   
    }
}