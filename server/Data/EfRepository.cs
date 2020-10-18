using Server.API.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using AutoMapper.QueryableExtensions;
using Server.API.Dtos.Product;
using AutoMapper;
using Server.API.Models;

namespace Server.API.Data
{
    public class EfRepository<TEntity, TiD> : IRepository<TEntity, TiD>
        where TEntity : class
    {

        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public EfRepository(DataContext context, IMapper mapper)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));
            this.DbSet = this._context.Set<TEntity>();
            this._mapper = mapper;
        }

        protected DbSet<TEntity> DbSet { get; set; }

        public virtual IQueryable<TEntity> All() => this.DbSet;

        public virtual IQueryable<TEntity> AllAsNoTracking() => this.DbSet.AsNoTracking();

        public async virtual Task AddAsync(TEntity entity)
        {
            try
            {
                var result = await this.DbSet.AddAsync(entity);
                await this._context.SaveChangesAsync();
            }
            catch (SqlException ex)
            {
                throw new InvalidOperationException();
            }
        }

        public virtual void Update(TEntity entity)
        {
            var entry = this._context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.DbSet.Attach(entity);
            }

            entry.State = EntityState.Modified;
        }

        public virtual void Delete(TEntity entity) => this.DbSet.Remove(entity);

        public Task<int> SaveChangesAsync() => this._context.SaveChangesAsync();

        //public void Dispose() => this.Context.Dispose();

        public async Task<PagedList<TEntity>> AllPaged(PaginationParams paginationParams)
        {
            var all = this.AllAsNoTracking();

            var created = await PagedList<TEntity>.CreateAsync(all, paginationParams.PageNumber, paginationParams.PageSize);

            return created;
        }

        public async Task<TEntity> GetEntity(TiD id)
        {
            return await this.DbSet.FindAsync(id);
        }

        public async Task<PagedList<TEntity>> GetProducts(ProductParams productParams)
        {
            IQueryable<TEntity> products = new List<TEntity>().AsQueryable();
            try
            {
                     products = this._context
                    .Products
                    .ProjectTo<TEntity>(_mapper.ConfigurationProvider)
                    .AsNoTracking();
            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.Message);
            }


            return await PagedList<TEntity>.CreateAsync(products, productParams.PageNumber, productParams.PageSize);
        }

        public async Task<PagedList<TEntity>> GetOrders(OrderParams productParams)
        {
            var orders = this._context
                .Orders
                .ProjectTo<TEntity>(_mapper.ConfigurationProvider)
                .AsNoTracking();

            return await PagedList<TEntity>.CreateAsync(orders, productParams.PageNumber, productParams.PageSize);
        }
    }
}
