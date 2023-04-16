using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCRUDApp_DAL.Entities
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        [MaxLength(128)]
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime DateAdded { get; set; } = DateTime.Now;
        public ICollection<CustomerProduct>? Customers { get; set; }
    }
}
