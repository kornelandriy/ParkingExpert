using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ParkingExpert.DB;
using ParkingExpert.DB.Entities;
using ParkingExpert.Repositories.Abstractions;

namespace ParkingExpert.Repositories.Implementations
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly PEDataContext _context;
        private DbSet<T> entities;
        public Repository(PEDataContext context)
        {
            _context = context;
            entities = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }
        public T GetById(int id)
        {
            return entities.SingleOrDefault(s => s.Id == id);
        }
        public void Insert(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            entities.Add(entity);
            _context.SaveChanges();
        }
        public void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            T entity = entities.SingleOrDefault(s => s.Id == id);
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            entities.Remove(entity);
            _context.SaveChanges();
        }
    }
}