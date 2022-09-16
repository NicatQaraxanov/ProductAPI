using DomainModels.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.Abstraction
{
    public interface IRepository<T> where T : Entity
    {
        Task<IList<T>> GetAllAsync();

        Task<T> GetAsync(int Id);

        T GetByUsername(string Username);

        Task<bool> AddAsync(T item);

        bool Update(T item);

        bool Delete(T item);
    }
}
