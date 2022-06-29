using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int Qty { get; set; }
        public int Total { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int StatusId { get; set; }
        public bool IsDeleted { get; set; }
        
        public List<OrderDetail> OrderDetails { get; set; }
        public List<Status> Statuses { get; set; }
        public Product Product { get; set; }
    }
}
