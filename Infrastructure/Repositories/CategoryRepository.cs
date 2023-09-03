using Domain.Categories;
using Domain.Orders;
using Infrastructure.Database; 

namespace Infrastructure.Data.Repositories
{
    public class CategoryRepository : RepositoryBase<CtgrNme>
        , ICategoryRepository
    {
        public CategoryRepository(EcomOrderDDDContext dbContext) : base(dbContext)
        {
        }
    }
}