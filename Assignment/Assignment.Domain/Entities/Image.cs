using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Domain.Entities
{
    public class Image
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ImageURL { get; set; }
        public string ImageName { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Product Product { get; set; }
    }
}
