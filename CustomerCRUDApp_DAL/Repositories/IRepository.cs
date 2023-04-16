using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCRUDApp_DAL.Repositories
{
    public interface IRepository<T> where T : class
    {
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> GetByIdAsync(int id);
        public Task<T> InsertAsync(T entity);
        public Task<T> UpdateAsync(int id, T entity);
        public Task<T> DeleteAsync(int id);
    }
}
