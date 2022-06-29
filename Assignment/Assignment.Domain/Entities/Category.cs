using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Domain.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}
