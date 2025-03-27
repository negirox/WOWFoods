using System;

namespace WowFoods.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }
        public UserInformation UserInformation { get; set; }
        public EmployeeStaff EmployeeStaff { get; set; }

    }
}
