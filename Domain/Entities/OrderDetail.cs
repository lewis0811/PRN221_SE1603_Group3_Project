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

        [ForeignKey(nameof(StoreService))]
        public int StoreServiceId { get; set; }

        [Range(1, 10, ErrorMessage = "Quantity must be at least 1")]
        public short Quantity { get; set; }

        [Required(ErrorMessage = "TotalPrice is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "TotalPrice must be greater than 0.01")]
        public double? TotalPrice { get; set; } = 0;

        // Navigation property for the related Order
        public Order Order { get; set; }

        // Navigation property for a collection of related Services
        public StoreService StoreService { get; set; }
    }
}