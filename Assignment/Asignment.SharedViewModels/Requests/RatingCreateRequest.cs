using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.SharedViewModels.Requests
{
    public class RatingCreateRequest
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int ProductId { get; set; }
        public string Comment { get; set; }
        [Range(1, 5)]
        public int Star { get; set; }
        public DateTime? CreatedDate { get; set; }
        
    }
}
