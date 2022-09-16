using DomainModels.Models.Abstractions;
using Microsoft.EntityFrameworkCore;
using Repository.DAL;
using Repository.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoggerService;
using DomainModels.Models;

namespace Repository.Repository.Implementation
{
    public class ProductApiRepository<T> : IRepository<T> where T : Entity
    {

        protected readonly ProductAppDbContext _db;

        private DbSet<T> table = null;

        public ProductApiRepository(ProductAppDbContext db)
        {
            _db = db;
            table = _db.Set<T>();
        }

        public async Task<bool> AddAsync(T item)
        {
            try
            {
                await table.AddAsync(item);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Logger.Write(ex.Message);
                return false;
            }
        }

        public bool Delete(T item)
        {
            try
            {
                table.Remove(item);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Logger.Write(ex.Message);
                return false;
            }
        }

        public async Task<IList<T>> GetAllAsync()
        {
            if (table.Count() == 0)
                throw new Exception("There are no existing product");
            return await table.ToListAsync();
        }

        public async Task<T> GetAsync(int Id)
        {
            var product = await table.FirstOrDefaultAsync(t => t.Id == Id);
            if(product == null)
                throw new Exception("The given product id is invalid");
            return product;
        }

        public T GetByUsername(string Username)
        {
            try
            {
                var user = table.FirstOrDefault(u => (u as User).Username == Username);
                return user;
            }
            catch (Exception)
            {
                return null;
            };
        }

        public bool Update(T item)
        {
            try
            {
                table.Update(item);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Logger.Write(ex.Message);
                return false;
            }
        }
    }
}
