using CustomerCRUDApp_BAL.Contracts.Interfaces;

namespace CustomerCRUDApp.DAL
{
    public interface IUnitofWork
    {
        ICustomerService _customerService { get; }
        IProductService _productService { get; }
        ICustProdService _custProdService { get; }
        Task<int> SaveChangesAsync();
    }
}