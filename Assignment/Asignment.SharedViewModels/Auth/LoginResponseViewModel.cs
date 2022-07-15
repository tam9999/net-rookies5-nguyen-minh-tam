using Assignment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.SharedViewModels.Auth
{
    public class LoginResponseViewModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public bool Active { get; set; }
        public string Token { get; set; }

        public LoginResponseViewModel(UserViewModel user, string token)
        {
            Id = user.Id;
            Email = user.Email;
            Role = user.Role;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Phone = user.Phone;
            Address = user.Address;
            Active = user.Active;
            Token = token;
        }
    }
}
