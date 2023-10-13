using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class OrderDetail
    {
        public int Id { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }

        [Range(1, 10, ErrorMessage = "Quantity must be at least 1")]
        public short Quantity { get; set; }

        // Navigation property for the related Order
        public Order Order { get; set; }

        // Navigation property for a collection of related Services
        public ICollection<Service> Services { get; set; }
    }
}