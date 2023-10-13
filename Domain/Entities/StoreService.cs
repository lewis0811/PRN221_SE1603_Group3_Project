using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class StoreService
    {
        public int Id { get; set; }

        [ForeignKey("Service")]
        public int ServiceId { get; set; }

        [ForeignKey("LaundryStore")]
        public int LaundryStoreId { get; set; }

        
        [Range(1, double.MaxValue, ErrorMessage = "Weight must be greater than 1")]
        public double? Weight { get; set; } = null;


        [Range(1, double.MaxValue, ErrorMessage = "UnitPrice must be greater than 1")]
        public double? UnitPrice { get; set; } = null;

        // Navigation property for the related Service
        public Service Service { get; set; }

        // Navigation property for the related LaundryStore
        public LaundryStore LaundryStore { get; set; }
    }
}