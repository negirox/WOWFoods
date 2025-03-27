using System.ComponentModel.DataAnnotations;

namespace WowFoodsViewModels.Models
{
    public class UserViewModel: UserLoginViewModel
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }

        [EmailAddress]
        public required string Email { get; set; }
       
        public string? Contact { get; set; }
        public string? Address { get; set; }
        public string? Gender { get; set; }
    }
}
