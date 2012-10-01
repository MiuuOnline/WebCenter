using System;
using Fs.Core.Repositories;
using Fs.Data.Database;

namespace Fs.Domain.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {

        IRepository<Product> Products { get; }

        void Save();

    }
}
