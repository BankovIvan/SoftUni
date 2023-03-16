namespace FastFood.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Enums;
    using FastFood.Common.EntityConfiguration;

    public class Order
    {
        public Order()
        {
            this.Id = Guid.NewGuid().ToString();
            this.EmployeeId = Guid.NewGuid().ToString();
            this.OrderItems = new HashSet<OrderItem>();
        }

        [Key]
        [MaxLength(ValidationConstants.GUIDMaxLength)]
        public string Id { get; set; } = null!;

        [Required]
        public string Customer { get; set; } = null!;

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public OrderType Type { get; set; }

        [NotMapped]
        public decimal TotalPrice { get; set; }

        [ForeignKey(nameof(Employee))]
        [MaxLength(ValidationConstants.GUIDMaxLength)]
        public string EmployeeId { get; set; } = null!;

        [Required]
        public virtual Employee Employee { get; set; } = null!;

        public virtual ICollection<OrderItem>? OrderItems { get; set; }
    }
}