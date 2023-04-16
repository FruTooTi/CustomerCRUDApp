using CustomerCRUDApp_DAL.AppDbContext;
using CustomerCRUDApp_DAL.Entities;
using CustomerCRUDApp_DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCRUDApp.Infrastructure.Repositories.Impl
{
    public class CustomerRepository : IRepository<Customer>
    {
        private readonly ApplicationDbContext _context;
        public CustomerRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<Customer> DeleteAsync(int id)
        {
            var target = await _context.Customers
                .Include(c => c.Products)
                .ThenInclude(c => c.Product)
                .FirstOrDefaultAsync(c => c.CustomerId == id);
            if (target == null)
                return null;
            _context.Customers.Remove(target);
            return target;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            var target = await _context.Customers
                .Include(c => c.Products)
                .ThenInclude(c => c.Product)
                .ToListAsync();
            if (target == null)
                return null;
            return target;
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            var target = await _context.Customers
                .Include(c => c.Products)
                .ThenInclude(c => c.Product)
                .FirstOrDefaultAsync(c => c.CustomerId == id);
            if (target == null)
                return null;
            return target;
        }

        public async Task<Customer> InsertAsync(Customer entity)
        {
            var target = await _context.Customers.AddAsync(entity);
            return entity;
        }

        public async Task<Customer> UpdateAsync(int id, Customer entity)
        {
            var target = await _context.Customers.FirstOrDefaultAsync(c => c.CustomerId == id);
            if (target == null)
                return null;
            target.Name = entity.Name;
            target.Surname = entity.Surname;
            target.Age = entity.Age;
            return entity;
        }
    }
}
