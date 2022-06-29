using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Domain.Entities
{
    public class ProductRating
    {
        public int Id { get; set; }
        public int Start { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}
