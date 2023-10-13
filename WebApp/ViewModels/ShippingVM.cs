using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels
{
    public class ShippingVM
    {
        public int Id { get; set; }

        [Display(Name = "Order ID")]
        public int OrderId { get; set; }

        [Display(Name = "Staff ID")]
        public int StaffId { get; set; }

        [Display(Name = "Status")]
        public bool Status { get; set; }

        [Display(Name = "Type")]
        public bool Type { get; set; }
    }
}
