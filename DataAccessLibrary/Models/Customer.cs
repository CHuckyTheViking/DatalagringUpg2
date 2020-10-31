using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLibrary.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Issue = new HashSet<Issue>();
        }

        [Key]
        [Column("customer_id")]
        public int CustomerId { get; set; }
        [Required]
        [Column("customer_name")]
        [StringLength(50)]
        public string CustomerName { get; set; }

        [InverseProperty("Customer")]
        public virtual ICollection<Issue> Issue { get; set; }
    }
}
