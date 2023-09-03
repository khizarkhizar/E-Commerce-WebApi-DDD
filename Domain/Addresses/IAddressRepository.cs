using Domain.Interfaces; 

namespace Domain.Addresses
{
    public interface IAddressRepository : IAsyncRepository<Addr>
    {
    }
}