using CustomerCRUDApp_BAL.Contracts.Dtos;

namespace CustomerCRUDApp_BAL.Contracts.Interfaces
{
    public interface IProductService
    {
        Task<ProductDTO> DeleteAsync(int id);
        Task<IEnumerable<ProductDTO>> GetAllAsync();
        Task<ProductDTO> GetByIdAsync(int id);
        Task<ProductAddOrUpdateDTO> InsertAsync(ProductAddOrUpdateDTO entity);
        Task<ProductAddOrUpdateDTO> UpdateAsync(ProductAddOrUpdateDTO entity, int id);
    }
}