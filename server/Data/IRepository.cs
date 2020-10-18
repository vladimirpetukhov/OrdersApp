using CloudinaryDotNet.Actions;
using Server.API.Helpers;
using Server.API.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.API.Data
{
    public interface IRepository<TEntity,TiD>
        where TEntity:class
    {
        IQueryable<TEntity> All();

        Task<TEntity> GetEntity(TiD id);

        Task<PagedList<TEntity>> AllPaged(PaginationParams paginationParams);
        Task<PagedList<TEntity>> GetProducts(ProductParams productParams);
        Task<PagedList<TEntity>> GetOrders(OrderParams orderParams);

        IQueryable<TEntity> AllAsNoTracking();

        Task AddAsync(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        Task<int> SaveChangesAsync();
    }
}
