using SegundoParcial.Models;
using System.Linq.Expressions;

namespace SegundoParcial.Repository.IRepository
{
    public interface IEventRepository : IRepository<Event>
    {
        void Update(Event obj);
    }
}
