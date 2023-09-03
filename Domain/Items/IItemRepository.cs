using Domain.Interfaces;

namespace Domain.Items
{
    public interface IItemRepository : IAsyncRepository<Item>
    {
    }
}