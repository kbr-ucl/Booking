namespace Booking.Application.Persistance
{
    public interface IRepository<E>
    {
        void Save(E entity);
    }


}
