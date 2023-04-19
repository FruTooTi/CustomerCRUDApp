using CustomerCRUDApp.DAL;
using CustomerCRUDApp_BAL.Contracts.Interfaces;
using CustomerCRUDApp_BAL.Services;
using Microsoft.AspNetCore.Mvc;

namespace CustomerCRUDApp.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class CustProdController : ControllerBase
    {
        private readonly IUnitofWork _unitOfWork;
        public CustProdController(IUnitofWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpPost("{CustomerId}/{ProductId}")]
        public async Task<IActionResult> InsertAsync(int CustomerId, int ProductId)
        {
            var data = await _unitOfWork._custProdService.InsertAsync(CustomerId, ProductId);
            return Ok(data);
        }
        [HttpDelete("{CustomerId}/{ProductId}")]
        public async Task<IActionResult> DeleteAsync(int CustomerId, int ProductId)
        {
            var data = await _unitOfWork._custProdService.DeleteAsync(CustomerId, ProductId);
            return Ok(data);
        }
    }
}
