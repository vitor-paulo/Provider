using Provider.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Provider.Domain.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        Task<IList<TEntity>> GetAll();
        Task<TEntity> GetById(Guid id);
        Task Create(TEntity entity);
        Task Update(Guid id, TEntity entity);
        Task Delete(Guid id);
    }
}
