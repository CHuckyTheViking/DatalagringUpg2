using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLibrary.Models
{
    public partial class Situation
    {
        public Situation()
        {
            Issue = new HashSet<Issue>();
        }

        [Key]
        [Column("situation_id")]
        public int SituationId { get; set; }
        [Required]
        [Column("situation")]
        [StringLength(20)]
        public string Situation1 { get; set; }

        [InverseProperty("Situation")]
        public virtual ICollection<Issue> Issue { get; set; }
    }
}
