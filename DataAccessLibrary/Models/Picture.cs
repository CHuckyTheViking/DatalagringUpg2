using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLibrary.Models
{
    public partial class Picture
    {
        [Key]
        [Column("picture_id")]
        public int PictureId { get; set; }
        [Required]
        [Column("picture")]
        public byte[] Picture1 { get; set; }
        [Column("issue_id")]
        public int IssueId { get; set; }

        [ForeignKey(nameof(IssueId))]
        [InverseProperty("Picture")]
        public virtual Issue Issue { get; set; }
    }
}
