using Microsoft.EntityFrameworkCore;
using Provider.Domain.Entities;
using Provider.Domain.Interfaces;
using Provider.Infra.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Provider.Infra.Repositories.GenericRepository
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly MainContext _dbContext;

        protected GenericRepository(MainContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var entity = await GetById(id);
            _dbContext.Set<TEntity>()
                .Remove(entity);
        }

        public async Task<IList<TEntity>> GetAll()
        {
            return await _dbContext.Set<TEntity>()
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<TEntity> GetById(Guid id)
        {
            return await _dbContext.Set<TEntity>()
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task Update(Guid id, TEntity entity)
        {
            _dbContext.Set<TEntity>()
                .Update(entity);

            await _dbContext.SaveChangesAsync();
        }
    }
}
