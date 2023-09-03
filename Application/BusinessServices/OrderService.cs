

using Infrastructure.Data;
using WebApplication2.Application.Services;

using WebApplication2.Application.Dto;
using Domain.Addresses;
using Domain.Items;
using Domain.Orders;

namespace WebApplication2.Application.BusinessServices
{
    public class OrderService : BaseService
    {
        private readonly UnitOfWork _unitofwork;
        private readonly AddressesService _addressesService;
        private readonly ItemService _itemService;
        public OrderService(UnitOfWork unitofwork, AddressesService addressesService, ItemService itemService) : base(unitofwork)
        {
            _addressesService = addressesService;
            this._itemService = itemService;
        }

        public async Task<Tuple<int, List<Order>>> FetchAll(int page = 1,
            int pageSize = 5)
        {

            var repo = UnitOfWork.AsyncRepository<Order>();


            var count = await repo.GetCount();
            List<Order> orders = await repo.GetAllAsync();
            return Tuple.Create(count, orders);
        }




        public async Task<List<Order>> FetchAllFromItemName(string Name)
        {
            var repo = UnitOfWork.AsyncRepository<Order>();
            var repo1 = UnitOfWork.AsyncRepository<OrderItem>();

            var res = repo1.GetAsync(x => x.Item.ItemNme == Name).Result;

            return repo.ListAsync(_ => _.Id == res.OrderId).Result;
        }


        public int GetTotalSum(Order order)
        {
            int sum = 0;
            //    foreach (var item in order.OrderItems)
            //    {
            //         (sum += (item.Item.Price * item.Qnty));
            //    }

            return sum;
        }

        public async Task<Order> Create(CreateOrderDto form)
        {
            //if (form.CartItems == null)
            //    return null;

            Addr address;
            if (form.AddressId != 0)
            {
                address = await _addressesService.FetchById(form.AddressId);
                if (address == null)
                    throw new Exception("Null Address");
        
 
                Item products = await _itemService.FetchById(form.ItemId);


               
                
                 
                Order order = new Order(form.TrackingId, form.CreatedAt, form.UpdatedAt);

                order.Address.Add(address);
                var repo = UnitOfWork.AsyncRepository<Order>();
                var od = await repo.AddAsync(order);
                int Id = await UnitOfWork.SaveChangesAsync();
                var product = products;

                var orderItems = new OrderItem
                (
                    product.Id, 
                    od.Id, 
                     product.Price,
                    form.Qnty
                );

                var repo1 = UnitOfWork.AsyncRepository<OrderItem>();
                await repo1.AddAsync(orderItems);

                  Id = await UnitOfWork.SaveChangesAsync();

                if (Id != null && Id > 0) {
                    products.reduceQuantity(form.Qnty);

                    _ = _itemService.Update(products);

                }
                return od;
            }

            {
                throw new Exception("Address not found!");
            }


        }




    }
}
