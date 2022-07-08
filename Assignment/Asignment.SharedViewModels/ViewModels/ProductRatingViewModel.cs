using System.ComponentModel.DataAnnotations;

namespace Assignment.SharedViewModels.ViewModels
{
    public class ProductRatingViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int ProductId { get; set; }
        public string Comment { get; set; }
        [Range(1, 5)]
        public int Star { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        
    }
}
