 

using Microsoft.EntityFrameworkCore;
 
using Infrastructure.Data;
using Domain.Items;
using WebApplication2.Application.Services;
using Domain.Categories; 
using System.Diagnostics;
using WebApplication2.Application.Dto;

namespace WebApplication2.Application.BusinessServices
{
    public class ItemService : BaseService
    {
        private readonly UnitOfWork _unitofWork;



        public ItemService(UnitOfWork unitofWork) :base(unitofWork)
        { 
        }

        

        public async Task<List<Item>> FetchAll()
        {
            var repo = UnitOfWork.AsyncRepository<Item>();
            return await repo.GetAllAsync();  
        }

        public async Task<Item> FetchById(int id )
        {
            var queryable = UnitOfWork.AsyncRepository<Item>();
            var results = await queryable.GetAsync(_ => _.Id == id);


            return   results;

        }



        public async Task Create(Item item)
        {

            var itm = new Item(item.ItemNme, item.ItemDesc, item.Brnd, item.Price ,item.Rvew,item.Stock, item.CategoryId);

            var repository = UnitOfWork.AsyncRepository<Item>();
            await repository.AddAsync(itm);
            await UnitOfWork.SaveChangesAsync();
        }
 
 

        public async Task<Task> Update(Item product)
        { 

            var repo = UnitOfWork.AsyncRepository<Item>();
             
            var t=await repo.UpdateAsync(product);
            await UnitOfWork.SaveChangesAsync();
            return Task.CompletedTask;
        }


        public async Task<bool> Delete(long id)
        {
            var repo = UnitOfWork.AsyncRepository<Item>();
            var itm=repo.GetAsync(_=>_.Id.Equals(id)); 
            if (itm != null)
            {
                return await Delete(itm.Result); 
            }

            return false;
        }

        public async Task<bool> Delete(Item product)
        {
            var repo = UnitOfWork.AsyncRepository<Item>();
            return await repo.DeleteAsync(product);  
        }
        

    }
}
