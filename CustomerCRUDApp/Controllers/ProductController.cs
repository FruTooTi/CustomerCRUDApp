using CustomerCRUDApp.DAL;
using CustomerCRUDApp_BAL.Contracts.Dtos;
using CustomerCRUDApp_BAL.Contracts.Interfaces;
using CustomerCRUDApp_BAL.Services;
using CustomerCRUDApp_DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CustomerCRUDApp.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IUnitofWork _unitOfWork;
        public ProductController(IUnitofWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var data = await _unitOfWork._productService.GetAllAsync();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var data = await _unitOfWork._productService.GetByIdAsync(id);
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> InsertAsync(ProductAddOrUpdateDTO product)
        {
            var data = await _unitOfWork._productService.InsertAsync(product);
            return Ok(data);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(int id, ProductAddOrUpdateDTO product)
        {
            var data = await _unitOfWork._productService.UpdateAsync(product, id);
            return Ok(data);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var data = await _unitOfWork._productService.DeleteAsync(id);
            return Ok(data);
        }
    }
}
