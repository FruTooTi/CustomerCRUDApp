using CustomerCRUDApp_DAL.AppDbContext;
using CustomerCRUDApp_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCRUDApp.Infrastructure.Repositories.Impl
{
    public class CustProdRepository
    {
        private readonly ApplicationDbContext _context;
        public CustProdRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<CustomerProduct> InsertAsync(int CustomerId, int ProductId)
        {
            var newData = new CustomerProduct()
            {
                CustomerId = CustomerId,
                ProductId = ProductId
            };
            await _context.CustomerProduct.AddAsync(newData);
            return newData;
        }
        public async Task<CustomerProduct> DeleteAsync(int CustomerId, int ProductId)
        {
            var target = await _context.CustomerProduct.FindAsync(ProductId, CustomerId);
            if (target == null)
                return null;
            _context.CustomerProduct.Remove(target);
            return target;
        }
    }
}
