using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Staff
    {
        public int Id { get; set; }

        [ForeignKey(nameof(ApplicationUser))]
        public string ApplicationUserId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(30, ErrorMessage = "Name must be at most 30 characters")]
        public string Name { get; set; }

        [Range(18, 99, ErrorMessage = "Age must be between 18 and 99")]
        public int Age { get; set; }

        [StringLength(100, ErrorMessage = "Address must be at most 100 characters")]
        public string Address { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}