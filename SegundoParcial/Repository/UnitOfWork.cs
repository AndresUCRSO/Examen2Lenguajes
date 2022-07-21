using SegundoParcial.Data;
using SegundoParcial.Repository.IRepository;

namespace SegundoParcial.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        private ApplicationDbContext _db;

        public IEventRepository Event { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Event = new EventRepository(_db);

        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
