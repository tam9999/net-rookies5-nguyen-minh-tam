using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Domain.Entities
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int OrderId { get; set; }
        public int UserId { get; set; }
        
        public virtual Order Order { get; set; }
        public virtual User User { get; set; }
    }
}
