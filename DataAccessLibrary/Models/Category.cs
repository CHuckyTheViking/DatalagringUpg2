using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLibrary.Models
{
    public partial class Category
    {
        public Category()
        {
            Issue = new HashSet<Issue>();
        }

        [Key]
        [Column("category_id")]
        public int CategoryId { get; set; }
        [Column("category")]
        [StringLength(20)]
        public string Category1 { get; set; }

        [InverseProperty("Category")]
        public virtual ICollection<Issue> Issue { get; set; }
    }
}
