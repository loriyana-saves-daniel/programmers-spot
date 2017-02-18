using Bytes2you.Validation;
using ProgrammersSpot.Business.Data.Contracts;

namespace ProgrammersSpot.Business.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IProgrammersSpotDbContext context;

        public UnitOfWork(IProgrammersSpotDbContext context)
        {
            Guard.WhenArgument(context, "Db context").IsNull().Throw();

            this.context = context;
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        public void Dispose()
        {
        }
    }
}
