using System;

namespace ProgrammersSpot.Business.Data.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();
    }
}
