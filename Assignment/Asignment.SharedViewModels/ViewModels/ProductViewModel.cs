﻿namespace Assignment.SharedViewModels.ViewModels
{
    public class ProductViewModel
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
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int? ImageId { get; set; }
    }
}
