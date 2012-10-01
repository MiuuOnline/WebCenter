using System;
using System.Data.Entity;
using System.Linq;
using Fs.Core.Repositories;
using Fs.Data.Database;

namespace Fs.Domain.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;
        private bool _disposed;

        private IRepository<Product> _productRepository;

        /// <summary>
        /// NOTE: repository getters instantiate repositories as needed (lazily)...
        ///       i wish I knew of IoC "way" of wiring up repository getters...
        /// </summary>
        /// <param name="dbContextFactory"></param>
        public UnitOfWork(IDbContextFactory dbContextFactory)
        {
            _dbContext = dbContextFactory.GetDbContext();
        }

        public IRepository<Product> Products
        {
            get { return _productRepository ?? (_productRepository = new Repository<Product>(_dbContext)); }
        }

        public void Save()
        {
            if (_dbContext.GetValidationErrors().Any())
            {
                // TODO: move validation errors into domain level exception and then throw it instead of EF related one
            }
            _dbContext.SaveChanges();
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            _disposed = true;
        }
    }

}
