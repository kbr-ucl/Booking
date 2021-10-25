using Microsoft.EntityFrameworkCore;

namespace Crosscut.Persistance
{
    public interface IRepository
    {
        DbContext GetContext();
    }


}
