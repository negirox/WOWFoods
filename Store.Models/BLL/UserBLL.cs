using System;

namespace Store.Models.BLL
{
    public class UserBLL
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string contact { get; set; }
        public string address { get; set; }
        public string gender { get; set; }
        public string user_type { get; set; }
        public DateTime added_date { get; set; }
        public byte[] userImage { get; set; } // New property
        public string userSalary { get; set; } // New property

        public string DefaultSalary { get; set; } // New property
        public string aadharNo { get; set; } // New property
        public int added_by { get; set; }
    }

}
