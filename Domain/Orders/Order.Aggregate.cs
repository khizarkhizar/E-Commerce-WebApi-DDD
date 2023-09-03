using Domain.Addresses; 
using Domain.Base;
using Domain.Items;
using System.Linq;

namespace Domain.Orders
{
    public partial class Order : IAggregateRoot
    {
        
        public Order(string TrackingId , DateTime CreatedAt, DateTime? UpdatedAt)
        {
            Address = new HashSet<Addr>();

            this.Update(
                TrackingId , CreatedAt, UpdatedAt 
            );
        }

        

        public void Update(string TrackingId,  DateTime CreatedAt, DateTime? UpdatedAt)
        {
            this.TrackingId = TrackingId; 
            this.CreatedAt = CreatedAt;
            this.UpdatedAt = UpdatedAt;
       

        }

        public void AddProduct(Item product, int quantity)
        {
            // Implement logic to add a product to the order
        }

        public void RemoveProduct(Item product)
        {
            // Implement logic to remove a product from the order
        }

        public void Process()
        {
            // Implement logic to process the order
        }
        public Addr AddAddress(int Id,string Street, string City, string Country, string ZipCode)
        {
            // Make sure there's only one payslip  per month
            var exist = Address.Where(_ => _.StrtAddr == Street && _.City == City && _.Cntry == Country && _.ZipCode == ZipCode);

            if (exist.Count() > 0) {
                 
                return (Addr)exist;
            }

            var add = new Addr();
            add.Update(Id,Street, City, Country, ZipCode); 
            return add;
        }
        
    }
}