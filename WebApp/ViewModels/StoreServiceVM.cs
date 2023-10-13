using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels
{
    public class StoreServiceVM
    {
        public int Id { get; set; }

        [Display(Name = "Service ID")]
        public int ServiceId { get; set; }

        [Display(Name = "LaundryStore ID")]
        public int LaundryStoreId { get; set; }

        [Display(Name = "Weight")]
        [Range(1, double.MaxValue, ErrorMessage = "Weight must be greater than 1")]
        public double? Weight { get; set; }

        [Display(Name = "Unit Price")]
        [Range(1, double.MaxValue, ErrorMessage = "Unit Price must be greater than 1")]
        public double? UnitPrice { get; set; }
    }
}
