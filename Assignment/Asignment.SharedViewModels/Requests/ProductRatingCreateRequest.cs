using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.SharedViewModels.Requests
{
    public class ProductRatingCreateRequest
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public string Comment { get; set; }
        public int Star { get; set; }
    }
}
