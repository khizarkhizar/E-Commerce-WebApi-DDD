using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Categories;
using Infrastructure.Data;
using WebApplication2.Application.Dto; 

namespace WebApplication2.Application.Services
{
    public class CategoriesService :BaseService
    {
        private readonly UnitOfWork _unitOfWork;

        public CategoriesService(UnitOfWork  unitOfWork) :base(unitOfWork)
        { 
        }

        public async Task<int> Count()
        { var repo = UnitOfWork.AsyncRepository<CtgrNme>();
            return await repo.GetCount();
        }

        public async Task<Tuple<int, List<CtgrNme>>> FetchPage(int page, int pageSize)
        {
            var queryable = UnitOfWork.AsyncRepository<CtgrNme>();
            var count = await queryable.GetCount();
            var results = await queryable.GetAllAsync()  ;

            return await Task.FromResult(Tuple.Create(count, results));
        }

        public async Task< CtgrNme> FetchById(int id)
        {
            var queryable = UnitOfWork.AsyncRepository<CtgrNme>();
            var results = await queryable.GetAsync(_=>_.Id==id)   ;

            return  results ;
        }


        public async Task<CategoryDtoResponse> Create(string name, string subCategory 
            )
        { 
            var user = new CtgrNme(name
                , subCategory );

            var repository = UnitOfWork.AsyncRepository<CtgrNme>();
            await repository.AddAsync(user);
            await UnitOfWork.SaveChangesAsync();

            var response = new CategoryDtoResponse()
            {
                Id = user.Id,
                CategoryName = name
            };
            return response;

        }

 
    }
}