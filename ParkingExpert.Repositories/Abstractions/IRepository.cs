using System.Collections.Generic;
using ParkingExpert.DB.Entities;

namespace ParkingExpert.Repositories.Abstractions
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}