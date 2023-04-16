using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCRUDApp_BAL.Contracts.Dtos
{
    public class ProductAddOrUpdateDTO
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime DateAdded { get; set; } = DateTime.Now;
    }
}
