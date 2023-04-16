using CustomerCRUDApp_BAL.Contracts.Interfaces;
using CustomerCRUDApp_BAL.Contracts.Dtos;
using CustomerCRUDApp_DAL.Entities;
using CustomerCRUDApp_DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCRUDApp_BAL.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer> _repository;
        public CustomerService(IRepository<Customer> repository, IProductService service)
        {
            _repository = repository;
        }
        public async Task<CustomerDTO> GetAsync(int id)
        {
            CustomerDTO Dto = new CustomerDTO();
            var Customer = await _repository.GetByIdAsync(id);
            if (Customer == null)
                return null;

            Dto.Name = Customer.Name;
            Dto.Surname = Customer.Surname;
            Dto.Age = Customer.Age;
            foreach (var CustProd in Customer.Products)
            {
                ProductListDTO prodDto = new ProductListDTO();
                prodDto.ProductId = CustProd.ProductId;
                prodDto.Title = CustProd.Product.Title;
                prodDto.Description = CustProd.Product.Description;
                prodDto.DateAdded = CustProd.Product.DateAdded;
                Dto.Products.Add(prodDto);
            }
            return Dto;
        }
        public async Task<IEnumerable<CustomerDTO>> GetAllAsync()
        {
            var CustomerList = await _repository.GetAllAsync();
            if (CustomerList == null)
                return null;
            List<CustomerDTO> customerDtos = new List<CustomerDTO>();
            foreach (var Customer in CustomerList)
            {
                CustomerDTO Dto = new CustomerDTO();

                Dto.Name = Customer.Name;
                Dto.Surname = Customer.Surname;
                Dto.Age = Customer.Age;
                foreach (var CustProd in Customer.Products)
                {
                    ProductListDTO prodDto = new ProductListDTO();
                    prodDto.ProductId = CustProd.ProductId;
                    prodDto.Title = CustProd.Product.Title;
                    prodDto.Description = CustProd.Product.Description;
                    prodDto.DateAdded = CustProd.Product.DateAdded;
                    Dto.Products.Add(prodDto);
                }
                customerDtos.Add(Dto);
            }
            return customerDtos;
        }
        public async Task<CustomerAddOrUpdateDTO> InsertAsync(CustomerAddOrUpdateDTO entity)
        {
            Customer cust = new Customer();
            List<Product> prod = new List<Product>();
            cust.Name = entity.Name;
            cust.Surname = entity.Surname;
            cust.Age = entity.Age;
            await _repository.InsertAsync(cust);
            return entity;
        }
        public async Task<CustomerAddOrUpdateDTO> UpdateAsync(int id, CustomerAddOrUpdateDTO entity)
        {
            Customer cust = new Customer();
            cust.Name = entity.Name;
            cust.Surname = entity.Surname;
            cust.Age = entity.Age;
            await _repository.UpdateAsync(id, cust);
            return entity;
        }
        public async Task<CustomerDTO> DeleteAsync(int id)
        {
            CustomerDTO dto = new CustomerDTO();
            var target = await _repository.DeleteAsync(id);
            if (target == null)
                return null;
            dto.Name = target.Name;
            dto.Surname = target.Surname;
            dto.Age = target.Age;
            foreach (var CustProd in target.Products)
            {
                ProductListDTO prodDto = new ProductListDTO();
                prodDto.Title = CustProd.Product.Title;
                prodDto.Description = CustProd.Product.Description;
                prodDto.DateAdded = CustProd.Product.DateAdded;
                dto.Products.Add(prodDto);
            }
            return dto;
        }
    }
}
