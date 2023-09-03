using Domain.Orders;
using Infrastructure.Database; 

namespace Infrastructure.Data.Repositories
{
    public class OrderRepository : RepositoryBase<Order>
        , IOrderRepository
    {
        public OrderRepository(EcomOrderDDDContext dbContext) : base(dbContext)
        {
        }
    }
}