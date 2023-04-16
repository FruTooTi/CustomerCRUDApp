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
    public class CustomerController : ControllerBase
    {
        private readonly IUnitofWork _unitOfWork;
        public CustomerController(IUnitofWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var data = await _unitOfWork._customerService.GetAllAsync();
            await _unitOfWork.SaveChangesAsync();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var data = await _unitOfWork._customerService.GetAsync(id);
            await _unitOfWork.SaveChangesAsync();
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> InsertAsync(CustomerAddOrUpdateDTO customer)
        {
            var data = await _unitOfWork._customerService.InsertAsync(customer);
            await _unitOfWork.SaveChangesAsync();
            return Ok(data);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(int id, CustomerAddOrUpdateDTO customer)
        {
            var data = await _unitOfWork._customerService.UpdateAsync(id, customer);
            await _unitOfWork.SaveChangesAsync();
            return Ok(data);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var data = await _unitOfWork._customerService.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
            return Ok(data);
        }
    }
}
