using System.ComponentModel.DataAnnotations;

namespace Assignment.API.Requests
{
    public class UpdateUserRequest
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Please enter username")]
        [RegularExpression("^[0-9a-zA-Z]*$",
           ErrorMessage = "Username doesn't have space character")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please enter Address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please enter email")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email:", Prompt = "example@example.com")]
        [RegularExpression("^[a-z][a-z0-9_\\.]{5,32}@[a-z0-9]{2,}(\\.[a-z0-9]{2,4}){1,2}$", ErrorMessage = "Email is invalid")]
        public string Email { get; set; }

        [Display(Name = "Phone")]
        [Required(ErrorMessage = "Please enter PhoneNumber")]
        [RegularExpression("^0[0-9]{9}$",
            ErrorMessage = "Phone numbers have to start with 0 and have 10 numbers")]
        public string PhoneNumber { get; set; }
    }
}
