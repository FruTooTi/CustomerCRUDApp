using CustomerCRUDApp_BAL.Contracts.Dtos;
using CustomerCRUDApp_BAL.Contracts.Interfaces;
using CustomerCRUDApp_DAL.Entities;
using CustomerCRUDApp_DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCRUDApp_BAL.Services.Impl
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _repository;
        public ProductService(IRepository<Product> repository)
        {
            _repository = repository;
        }
        public async Task<ProductDTO> GetByIdAsync(int id)
        {
            var Product = await _repository.GetByIdAsync(id);
            if (Product == null)
                return null;
            var CustomerList = new List<CustomerListDTO>();
            ProductDTO prodDto = new ProductDTO()
            {
                Title = Product.Title,
                Description = Product.Description,
                DateAdded = Product.DateAdded,
            };
            foreach (var Customer in Product.Customers)
            {
                CustomerList.Add(new CustomerListDTO()
                {
                    Name = Customer.Customer.Name,
                    Surname = Customer.Customer.Surname,
                    Age = Customer.Customer.Age,
                    CustomerId = Customer.CustomerId,
                });
            }
            prodDto.Customers = CustomerList;
            return prodDto;
        }
        public async Task<IEnumerable<ProductDTO>> GetAllAsync()
        {
            var AllProducts = await _repository.GetAllAsync();
            if (AllProducts == null)
                return null;
            List<ProductDTO> AllProdDto = new List<ProductDTO>();
            foreach (var Product in AllProducts)
            {
                var CustomerList = new List<CustomerListDTO>();
                ProductDTO prodDto = new ProductDTO()
                {
                    Title = Product.Title,
                    Description = Product.Description,
                    DateAdded = Product.DateAdded,
                };
                foreach (var Customer in Product.Customers)
                {
                    CustomerList.Add(new CustomerListDTO()
                    {
                        Name = Customer.Customer.Name,
                        Surname = Customer.Customer.Surname,
                        Age = Customer.Customer.Age,
                        CustomerId = Customer.CustomerId,
                    });
                }
                prodDto.Customers = CustomerList;
                AllProdDto.Add(prodDto);
            }
            return AllProdDto;
        }
        public async Task<ProductAddOrUpdateDTO> InsertAsync(ProductAddOrUpdateDTO entity)
        {
            Product newProd = new Product()
            {
                Title = entity.Title,
                Description = entity.Description,
                DateAdded = entity.DateAdded
            };
            await _repository.InsertAsync(newProd);
            return entity;
        }
        public async Task<ProductAddOrUpdateDTO> UpdateAsync(ProductAddOrUpdateDTO entity, int id)
        {
            Product newProd = new Product()
            {
                Title = entity.Title,
                Description = entity.Description,
                DateAdded = entity.DateAdded
            };
            await _repository.UpdateAsync(id, newProd);
            return entity;
        }
        public async Task<ProductDTO> DeleteAsync(int id)
        {
            ProductDTO dto = new ProductDTO();
            var target = await _repository.DeleteAsync(id);
            if (target == null)
                return null;
            dto.Title = target.Title;
            dto.Description = target.Description;
            dto.DateAdded = target.DateAdded;
            foreach (var Customer in target.Customers)
            {
                CustomerListDTO custDto = new CustomerListDTO()
                {
                    Name = Customer.Customer.Name,
                    Age = Customer.Customer.Age,
                    CustomerId = Customer.CustomerId,
                    Surname = Customer.Customer.Surname
                };
                dto.Customers.Add(custDto);
            }
            return dto;
        }
    }
}
