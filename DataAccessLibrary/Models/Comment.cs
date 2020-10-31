using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLibrary.Models
{
    public partial class Comment
    {
        public Comment()
        {
            IssueNavigation = new HashSet<Issue>();
        }

        [Key]
        [Column("comment_id")]
        public int CommentId { get; set; }
        [Column("issue_id")]
        public int IssueId { get; set; }
        [Required]
        [Column("comment")]
        [StringLength(255)]
        public string Comment1 { get; set; }
        [Column("comment_time", TypeName = "datetime")]
        public DateTime CommentTime { get; set; }

        [ForeignKey(nameof(IssueId))]
        [InverseProperty("Comment")]
        public virtual Issue Issue { get; set; }
        [InverseProperty("CommentNavigation")]
        public virtual ICollection<Issue> IssueNavigation { get; set; }
    }
}
