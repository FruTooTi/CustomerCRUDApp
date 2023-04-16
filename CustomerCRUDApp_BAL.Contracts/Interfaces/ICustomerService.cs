using CustomerCRUDApp_BAL.Contracts.Dtos;

namespace CustomerCRUDApp_BAL.Contracts.Interfaces
{
    public interface ICustomerService
    {
        Task<CustomerDTO> DeleteAsync(int id);
        Task<IEnumerable<CustomerDTO>> GetAllAsync();
        Task<CustomerDTO> GetAsync(int id);
        Task<CustomerAddOrUpdateDTO> InsertAsync(CustomerAddOrUpdateDTO entity);
        Task<CustomerAddOrUpdateDTO> UpdateAsync(int id, CustomerAddOrUpdateDTO entity);
    }
}