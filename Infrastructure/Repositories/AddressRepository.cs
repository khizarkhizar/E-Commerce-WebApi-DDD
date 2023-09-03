using Domain.Addresses;
using Infrastructure.Database; 

namespace Infrastructure.Data.Repositories
{
    public class AddressRepository : RepositoryBase<Addr>
        , IAddressRepository
    {
        public AddressRepository(EcomOrderDDDContext dbContext) : base(dbContext)
        {
        }
    }
}