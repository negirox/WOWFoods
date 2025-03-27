using System.ComponentModel.DataAnnotations;

namespace WowFoodsViewModels.Models
{
    public class UserLoginViewModel
    {
        [Required]
        public required string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public required string Password { get; set; }

        public UserType UserType { get; set; }
    }
}
