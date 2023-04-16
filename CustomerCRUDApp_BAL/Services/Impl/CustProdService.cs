using CustomerCRUDApp_DAL.Entities;
using CustomerCRUDApp.Infrastructure.Repositories.Impl;
using CustomerCRUDApp_BAL.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCRUDApp_BAL.Services.Impl
{
    public class CustProdService : ICustProdService
    {
        private readonly CustProdRepository _repository;
        public CustProdService(CustProdRepository repository)
        {
            _repository = repository;
        }
        public async Task<CustomerProduct> InsertAsync(int CustomerId, int ProductId)
        {
            return await _repository.InsertAsync(CustomerId, ProductId);
        }
        public async Task<CustomerProduct> DeleteAsync(int CustomerId, int ProductId)
        {
            return await _repository.DeleteAsync(CustomerId, ProductId);
        }
    }
}
