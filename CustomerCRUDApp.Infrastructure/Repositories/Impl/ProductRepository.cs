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
    public class ProductRepository : IRepository<Product>
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Product> DeleteAsync(int id)
        {
            var target = await _context.Products
                .Include(p => p.Customers)
                .ThenInclude(p => p.Customer)
                .FirstOrDefaultAsync(p => p.ProductId == id);
            if (target == null)
                return null;
            _context.Products.Remove(target);
            return target;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var target = await _context.Products
                .Include(p => p.Customers)
                .ThenInclude(p => p.Customer)
                .ToListAsync();
            if (target == null)
                return null;
            return target;
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            var target = await _context.Products
                .Include(p => p.Customers)
                .ThenInclude(p => p.Customer)
                .FirstOrDefaultAsync(p => p.ProductId == id);
            if (target == null)
                return null;
            return target;
        }

        public async Task<Product> InsertAsync(Product entity)
        {
            var target = await _context.Products.AddAsync(entity);
            return entity;
        }

        public async Task<Product> UpdateAsync(int id, Product entity)
        {
            var target = await _context.Products.FindAsync(id);
            if (target == null)
                return null;
            target.Title = entity.Title;
            target.Description = entity.Description;
            target.DateAdded = entity.DateAdded;
            return target;
        }
    }
}
