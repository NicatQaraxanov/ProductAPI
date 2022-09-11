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

namespace Repository.Repository.Implementation
{
    public class ProductApiRepository<T> : IRepository<T> where T : Entity
    {

        protected readonly ProductAppDbContext _db;

        public ProductApiRepository(ProductAppDbContext db)
        {
            _db = db;
        }

        public async Task<bool> AddAsync(T item)
        {
            try
            {
                await _db.Set<T>().AddAsync(item);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(T item)
        {
            try
            {
                _db.Set<T>().Remove(item);
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
            if (_db.Set<T>().Count() == 0)
                throw new Exception("There are no existing product");
            return await _db.Set<T>().ToListAsync();
        }

        public async Task<T> GetAsync(int Id)
        {
            var product = await _db.Set<T>().FirstOrDefaultAsync(p => p.Id == Id);
            if(product == null)
                throw new Exception("The given product id is invalid");
            return product;
        }

        public bool Update(T item)
        {
            try
            {
                _db.Set<T>().Update(item);
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
