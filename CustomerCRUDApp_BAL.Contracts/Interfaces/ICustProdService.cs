using CustomerCRUDApp_DAL.Entities;

namespace CustomerCRUDApp_BAL.Contracts.Interfaces
{
    public interface ICustProdService
    {
        Task<CustomerProduct> DeleteAsync(int CustomerId, int ProductId);
        Task<CustomerProduct> InsertAsync(int CustomerId, int ProductId);
    }
}