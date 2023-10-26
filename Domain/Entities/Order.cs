using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Order
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

        // Navigation property for the related Customer
        public Customer Customer { get; set; }

        // Navigation property for a collection of related OrderDetails
        public ICollection<OrderDetail> OrderDetails { get; set; }

        // Navigation property for a collection of related Shippings
        public ICollection<Shipping> Shippings { get; set; }
    }
}