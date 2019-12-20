using AwesomeDotNetCore.Data.Models;
using AwesomeDotNetCore.Data.Repository;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
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
            using (var transaction = _dbContext.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted))
            {
                try
                {
                    _dbContext.SaveChanges();
                    transaction.Commit();
                }
                catch (DbUpdateConcurrencyException dbUpdateConcurrencyException)
                {
                    //<TODO> : log   
                    transaction.Rollback();
                }
                catch (DbUpdateException dbUpdateExceptoin)
                {
                    //<TODO> : log
                    transaction.Rollback();
                }
                catch (Exception ex)
                {
                    //<TODO> : log
                    transaction.Rollback();
                }
                finally
                {
                    //<TODO> : can log and see io operation stats may be
                }
            }
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
