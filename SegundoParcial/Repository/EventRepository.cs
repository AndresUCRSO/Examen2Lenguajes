using SegundoParcial.Data;
using SegundoParcial.Models;
using SegundoParcial.Repository.IRepository;

namespace SegundoParcial.Repository
{
    public class EventRepository : Repository<Event>, IEventRepository
    {
        private ApplicationDbContext _db;

        public EventRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Event obj)
        {
            var objFromDB = _db.Event.FirstOrDefault(x => x.Id == obj.Id);

            if (objFromDB != null)
            {
                objFromDB.Name = obj.Name;
                objFromDB.Date = obj.Date;
                objFromDB.Description = obj.Description;
                objFromDB.MaxAssistance = obj.MaxAssistance;
                objFromDB.Price = obj.Price;
                objFromDB.AvailableSpaces = objFromDB.AvailableSpaces;

                if (obj.ImageUrl != null)
                {
                    objFromDB.ImageUrl = obj.ImageUrl;
                }
            }
        }
    }
}
