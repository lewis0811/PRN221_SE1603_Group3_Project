using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels
{
    public class StaffVM
    {
        public int Id { get; set; }

        [Display(Name = "User ID")]
        public string ApplicationUserId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(30, ErrorMessage = "Name must be at most 30 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Age is required")]
        [Range(18, 99, ErrorMessage = "Age must be between 18 and 99")]
        public int Age { get; set; }

        [StringLength(100, ErrorMessage = "Address must be at most 100 characters")]
        public string Address { get; set; }
    }
}
