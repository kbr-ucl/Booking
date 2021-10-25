using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Crosscut.Persistance
{
    public class UnitOfWork<R>: IUnitOfWork<R> where R : IRepository
    {
        private DbContext _context;
        private IDbContextTransaction _transaction;

        public UnitOfWork(R repository)
        {
            _context = repository.GetContext();
        }

        public void BeginUnitOfWork()
        {
            _transaction = _context.Database.BeginTransaction(System.Data.IsolationLevel.Serializable);
        }

        public void CommitUnitOfWork()
        {
            try
            {
                _context.SaveChanges();
                _transaction.Commit();
            }
            catch (Exception ex)
            {
                _transaction.Rollback();
                throw;
            }
        }
    }
}
