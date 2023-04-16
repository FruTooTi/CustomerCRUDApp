using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCRUDApp_BAL.Contracts.Dtos
{
    public class ProductDTO
    {
        public ProductDTO()
        {
            Customers = new List<CustomerListDTO>();
        }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime DateAdded { get; set; }
        public ICollection<CustomerListDTO>? Customers { get; set; }
    }
}
