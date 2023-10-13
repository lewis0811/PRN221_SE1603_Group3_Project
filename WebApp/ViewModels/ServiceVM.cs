using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels
{
    public class ServiceVM
    {
        public int Id { get; set; }

        [Display(Name = "OrderDetail ID")]
        public int OrderDetailId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name must be at most 100 characters")]
        public string Name { get; set; }

        [StringLength(200, ErrorMessage = "Description must be at most 200 characters")]
        public string Description { get; set; }
    }
}
