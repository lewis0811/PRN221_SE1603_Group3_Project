using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels
{
    public class LaundryStoreVM
    {
        public int Id { get; set; }

        [Display(Name = "User ID")]
        public string ApplicationUserId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(30, ErrorMessage = "Name must be at most 30 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(100, ErrorMessage = "Address must be at most 100 characters")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Capacity is required")]
        [Range(5, 10, ErrorMessage = "Capacity must be at least 5 and lower than 10")]
        public int Capacity { get; set; }

        public bool Status { get; set; }
    }
}
