using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCRUDApp_DAL.Entities
{
    public class CustomerProduct
    {
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Customer Customer { get; set; }
        public Product Product { get; set; }
    }
}
