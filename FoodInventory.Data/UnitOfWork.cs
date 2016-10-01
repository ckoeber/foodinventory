using System;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FoodInventory.Data.Interfaces;
using FoodInventory.Data.Models;
using FoodInventory.Data.Repositories;

namespace FoodInventory.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private FoodInventoryEntities context = new FoodInventoryEntities();

        private GenericRepository<Product> productRepository;
        public UnitOfWork()
        {
            if (context == null)
            {
                context = new FoodInventoryEntities();
            }
            context.Database.CommandTimeout = 600;
        }

        public DbContext GetContext()
        {
            return context;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public GenericRepository<Product> ProductRepository
        {
            get { return productRepository ?? (productRepository = new GenericRepository<Product>(context)); }
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            System.GC.SuppressFinalize(this);
        }
    }
}
