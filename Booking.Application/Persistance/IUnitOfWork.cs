namespace Booking.Application.Persistance
{
    public interface IUnitOfWork<T,E> where T : IRepository<E>
    {
        T Repository { get; }

        void BeginUnitOfWork();
        void CommitUnitOfWork();
        void Save(E entity);
    }
}
