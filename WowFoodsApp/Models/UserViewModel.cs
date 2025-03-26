using System.ComponentModel.DataAnnotations;

namespace WowFoodsApp.Models
{
    public class UserViewModel: UserLoginViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }
       
        public string Contact { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
    }
}
