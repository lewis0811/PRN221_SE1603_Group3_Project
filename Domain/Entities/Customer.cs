using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace Domain.Entities
{
    public class Customer
    {
        public int Id { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(30, ErrorMessage = "Name must be at most 30 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(100, ErrorMessage = "Address must be at most 100 characters")]
        public string Address { get; set; }

        // Navigation property for the related ApplicationUser
        public ApplicationUser ApplicationUser { get; set; }

        // Navigation property for a collection of related Orders
        public ICollection<Order> Orders { get; set; }
    }
}