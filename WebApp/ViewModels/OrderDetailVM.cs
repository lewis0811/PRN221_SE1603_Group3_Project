﻿using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels
{
    public class OrderDetailVM
    {
        public int Id { get; set; }

        [Display(Name = "Order ID")]
        public int OrderId { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        [Range(1, 10, ErrorMessage = "Quantity must be between 1 and 10")]
        public short Quantity { get; set; }
    }
}
