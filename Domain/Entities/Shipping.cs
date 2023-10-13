using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Shipping
    {
        public int Id { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }

        [ForeignKey("Staff")]
        public int StaffId { get; set; }

        public bool Status { get; set; }

        public bool Type { get; set; }

        // Navigation property for the related Order
        public Order Order { get; set; }

        // Navigation property for the related Staff
        public Staff Staff { get; set; }
    }
}