using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.SharedViewModels.Requests
{
    public class ProductUpdateRequest
    {
        [Required(ErrorMessage = "Product Id is required.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Product type is required.")]
        public int CategoryId { get; set; }
        public int Qty { get; set; }
        [Required(ErrorMessage = "Product name is required.")]
        public string ProductName { get; set; }
        public string Image { get; set; }
        [Required(ErrorMessage = "Product price is required.")]
        public int Price { get; set; }

        [Display(Name = "Product Price Description")]
        public string Description { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}
