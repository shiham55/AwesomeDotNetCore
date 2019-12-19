using AwesomeDotNetCore.Data.Models;
using AwesomeDotNetCore.Data.Repository;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AwesomeDotNetCore.Data
{
    public class AdventureWorksUnit : IAdventureWorksUnit, IDisposable
    {
        private AdventureWorks _dbContext;

        public AdventureWorksUnit() : this(new AdventureWorks()) { }

        public AdventureWorksUnit(AdventureWorks dbContext)
        {
            _dbContext = dbContext;
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            var result = (GenericRepository<T>)Activator.CreateInstance(typeof(GenericRepository<T>), _dbContext);
            if (result != null)
            {
                return result;
            }
            return null;
        }

        public void Save()
        {
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
    }
}
