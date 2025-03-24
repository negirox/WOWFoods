using System;

namespace Store.Models.BLL
{
    public class CategoriesBLL
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public DateTime added_date { get; set; }
        public int added_by { get; set; }

    }
}
