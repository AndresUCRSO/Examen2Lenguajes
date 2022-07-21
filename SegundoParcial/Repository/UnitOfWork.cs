﻿using SegundoParcial.Data;
using SegundoParcial.Repository.IRepository;

namespace SegundoParcial.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        private ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
