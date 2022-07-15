using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Qty { get; set; }
        public string? Image { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public int CategoryId { get; set; }
        public int ProductRatingId { get; set; }
        public int? ImageId { get; set; }

        public virtual List<Order> Orders { get; set; }
        public virtual List<ProductRating> ProductRatings { get; set; }
        public virtual Category Category { get; set; }
        public virtual List<Image> Images { get; set; }
    }
}
