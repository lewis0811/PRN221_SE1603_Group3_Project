using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using Domain.Enums;

namespace WebApp.ViewModels
{
    public class OrderVM
    {
        public int Id { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        [Display(Name = "Order Time")]
        public DateTime OrderTime { get; set; }
        [Display(Name = "Total Price")]
        public double TotalPrice { get; set; }
        public bool IsPaid { get; set; }
        [Display(Name = "Order Status")]
        public OrderStatus OrderStatus { get; set; }

    }
}
