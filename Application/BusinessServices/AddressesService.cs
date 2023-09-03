using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;  
using Infrastructure.Data;
using Domain.Interfaces;
using Domain.Addresses;
using Application.Dto;
using Domain.Categories;
using WebApplication2.Application.Dto;
using System.Reflection.Emit;

namespace WebApplication2.Application.Services
{
    public class AddressesService : BaseService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddressesService(UnitOfWork unitOfWork) : base(unitOfWork)
        { 
   
        }

        public async Task<List<Addr>> FetchPage(int page = 1, int pageSize = 5)
        {
            var repository = UnitOfWork.AsyncRepository< Addr>();
            var addr = await repository.GetAllAsync();

            return   addr;
        }

        public async Task<Addr> FetchById(int id)
        {
            var queryable = UnitOfWork.AsyncRepository<Addr>();
            var results = await queryable.GetAsync(_ => _.Id == id);

            return results;
        }

 
        public async Task<AddrDtoResponse> Create( 
            string dtoCountry, string dtoCity, string dtoStreetAddress, string dtoZipCode)
        {
            
            var addr = new Addr(0,dtoStreetAddress, dtoCity, dtoCountry, dtoZipCode);

            var repository = UnitOfWork.AsyncRepository<Addr>();
            await repository.AddAsync(addr);
            int Id= await UnitOfWork.SaveChangesAsync();

            var response = new AddrDtoResponse()
            {
                Id = Id,
                StrtAddr = dtoCountry,
                Cntry =dtoStreetAddress,
                ZipCode= dtoZipCode
            };
            return response;

        }

    }
}