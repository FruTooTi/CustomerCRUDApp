using CustomerCRUDApp.DAL;
using CustomerCRUDApp.Infrastructure.Repositories.Impl;
using CustomerCRUDApp_BAL.Contracts.Interfaces;
using CustomerCRUDApp_BAL.Services;
using CustomerCRUDApp_BAL.Services.Impl;
using CustomerCRUDApp_DAL.AppDbContext;
using CustomerCRUDApp_DAL.Entities;
using CustomerCRUDApp_DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCRUDApp_BAL.UnitofWork
{
    public class UnitofWork : IUnitofWork
    {
        private readonly ApplicationDbContext AppDbContext;
        public UnitofWork(ApplicationDbContext appDbContext)
        {
            AppDbContext = appDbContext;
        }
        private IRepository<Customer> _customerRepository => new CustomerRepository(AppDbContext);
        private IRepository<Product> _productRepository => new ProductRepository(AppDbContext);
        private CustProdRepository _custProdRepository => new CustProdRepository(AppDbContext);
        public ICustProdService _custProdService => new CustProdService(_custProdRepository);
        public IProductService _productService => new ProductService(_productRepository);
        public ICustomerService _customerService => new CustomerService(_customerRepository, _productService);
        public async Task<int> SaveChangesAsync()
        {
            return await AppDbContext.SaveChangesAsync();
        }
    }
}
