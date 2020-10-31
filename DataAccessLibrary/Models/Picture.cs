using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLibrary.Models
{
    public partial class Picture
    {
        public Picture()
        {
            Issue = new HashSet<Issue>();
        }

        [Key]
        [Column("picture_id")]
        public int PictureId { get; set; }
        [Column("issue_id")]
        public int IssueId { get; set; }
        [Required]
        [Column("picture")]
        [StringLength(100)]
        public string Picture1 { get; set; }

        [ForeignKey(nameof(IssueId))]
        [InverseProperty("PictureNavigation")]
        public virtual Issue IssueNavigation { get; set; }
        [InverseProperty("Picture")]
        public virtual ICollection<Issue> Issue { get; set; }
    }
}
