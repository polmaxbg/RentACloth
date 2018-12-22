using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using RentACloth.Common;

namespace RentACloth.Data
{
    public class DbRepository<TEntity> : IRepository<TEntity> , IDisposable
        where TEntity : class
    {
        private readonly RentAClothContext context;
        private  DbSet<TEntity> dbSet;

        public DbRepository(RentAClothContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }
        public Task AddAsync(TEntity entity)
        {
            return this.dbSet.AddAsync(entity);
        }

        public IQueryable<TEntity> All()
        {
            return this.dbSet;
        }

        public void Delete(TEntity entity)
        {
            this.dbSet.Remove(entity);
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public void Dispose()
        {
            this.context.Dispose();
        }
    }
}
