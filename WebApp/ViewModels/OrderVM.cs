using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace WebApp.ViewModels
{
    public class OrderVM
    {
        public int Id { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        public DateTime OrderTime { get; set; }
        public double? TotalPrice { get; set; } = 0;

        public bool IsPayed { get; set; }

    }
}
