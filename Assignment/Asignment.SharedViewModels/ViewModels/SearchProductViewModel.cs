using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.SharedViewModels.ViewModels
{
    public class SearchProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Image { get; set; }
        public int Price { get; set; }
        public int ProductRatingId { get; set; }
        public int Start { get; set; }
        public string Description { get; set; }
        public int Qty { get; set; }
        public bool IsDeleted { get; set; }
    }
}
