using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCRUDApp_BAL.Contracts.Dtos
{
    public class CustomerDTO
    {
        public CustomerDTO()
        {
            Products = new List<ProductListDTO>();
        }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? Age { get; set; }
        public ICollection<ProductListDTO>? Products { get; set; }
    }
}
