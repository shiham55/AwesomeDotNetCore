using AwesomeDotNetCore.Data.Models;
using AwesomeDotNetCore.Data.Repository;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AwesomeDotNetCore.Data.UnitOfWork
{
    public class AdventureWorksUnit : IAdventureWorksUnit, IDisposable
    {
        private AdventureWorks _dbContext;

        public AdventureWorksUnit(AdventureWorks adventureWorks)
        {
            _dbContext = adventureWorks;
        }

        #region Properties
        private IRepository<Product> _productRepository;
        public IRepository<Product> ProductRepository
        {
            get
            {
                if (_productRepository == null)
                {
                    _productRepository = new GenericRepository<Product>(_dbContext);
                }
                return _productRepository;
            }
        }

        private IRepository<Store> _storeRepository;
        public IRepository<Store> StoreRepository
        {
            get
            {
                if (_storeRepository == null)
                {
                    _storeRepository = new GenericRepository<Store>(_dbContext);
                }
                return _storeRepository;
            }
        }

        #endregion

        #region Generic Methods
        public void Save()
        {
            //<TODO> : Handle validation errors
            // exceptions and transaction handling
            _dbContext.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
