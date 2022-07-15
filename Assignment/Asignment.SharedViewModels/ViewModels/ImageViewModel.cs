using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.SharedViewModels.ViewModels
{
    public class ImageViewModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ImageName { get; set; }
        public string ImageURL { get; set; }
        public IFormFile File { get; set; }
        public bool IsDeleted { get; set; }
    }
}
