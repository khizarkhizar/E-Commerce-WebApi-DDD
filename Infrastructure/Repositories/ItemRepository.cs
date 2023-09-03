using Domain.Items;
using Infrastructure.Database; 
namespace Infrastructure.Data.Repositories
{
    public class ItemRepository : RepositoryBase<Item>
        , IItemRepository
    {
        public ItemRepository(EcomOrderDDDContext dbContext) : base(dbContext)
        {
        }
    }
}