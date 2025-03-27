using System;
using System.Collections.Generic;
using System.Text;

namespace WowFoods.Models
{
    public class EmployeeStaff
    {
        public int Id { get; set; }
        public double Salary { get; set; }

        public DateTime DateOfJoining { get; set; }

        public bool IsActive { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
