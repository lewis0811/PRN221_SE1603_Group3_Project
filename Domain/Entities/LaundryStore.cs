using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class LaundryStore
    {
        public int Id { get; set; }

        [ForeignKey(nameof(ApplicationUser))]
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
        public ApplicationUser ApplicationUser { get; set; }
        public virtual List<StoreService> Services { get; set; }
    }
}