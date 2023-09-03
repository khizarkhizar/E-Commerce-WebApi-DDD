using Domain.Base;
using Domain.Interfaces;
using Infrastructure.Data.Repositories;
using Infrastructure.Database;
using System;
using System.Threading.Tasks; 

namespace Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EcomOrderDDDContext _dbContext;

        public UnitOfWork(EcomOrderDDDContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IAsyncRepository<T> AsyncRepository<T>() where T : BaseEntity
        {
            return new RepositoryBase<T>(_dbContext);
        }

        public Task<int> SaveChangesAsync()
        {
            return _dbContext.SaveChangesAsync();
        }
    }
}