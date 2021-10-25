using Microsoft.EntityFrameworkCore;

namespace Crosscut.Persistance
{
    public interface IUnitOfWork<R> where R : IRepository
    {
        void BeginUnitOfWork();
        void CommitUnitOfWork();
    }
}
