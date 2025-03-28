using System.ComponentModel.DataAnnotations;

namespace WowFoodsViewModels.Models
{
    public class CategoryViewModel
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
    }
}

