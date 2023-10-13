using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Service
    {
        public int Id { get; set; }

        [ForeignKey("OrderDetail")]
        public int OrderDetailId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name must be at most 100 characters")]
        public string Name { get; set; }

        [StringLength(200, ErrorMessage = "Description must be at most 200 characters")]
        public string Description { get; set; }

        // Navigation property for the related OrderDetail
        public OrderDetail OrderDetail { get; set; }
    }
}