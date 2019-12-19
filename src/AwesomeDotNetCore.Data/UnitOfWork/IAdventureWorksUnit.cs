using AwesomeDotNetCore.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace AwesomeDotNetCore.Data
{
    public interface IAdventureWorksUnit :IDisposable
    {
        IRepository<T> GetRepository<T>() where T : class;
        void Save();

    }
}
