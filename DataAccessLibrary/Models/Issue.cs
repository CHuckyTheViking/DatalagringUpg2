using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLibrary.Models
{
    public partial class Issue
    {
        public Issue()
        {
            Comment = new HashSet<Comment>();
            PictureNavigation = new HashSet<Picture>();
        }

        [Key]
        [Column("issue_id")]
        public int IssueId { get; set; }
        [Required]
        [Column("issue")]
        [StringLength(255)]
        public string Issue1 { get; set; }
        [Column("issue_time", TypeName = "datetime")]
        public DateTime IssueTime { get; set; }
        [Column("customer_id")]
        public int CustomerId { get; set; }
        [Column("category_id")]
        public int CategoryId { get; set; }
        [Column("situation_id")]
        public int SituationId { get; set; }
        [Column("picture_id")]
        public int? PictureId { get; set; }
        [Column("comment_id")]
        public int? CommentId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        [InverseProperty("Issue")]
        public virtual Category Category { get; set; }
        [ForeignKey(nameof(CommentId))]
        [InverseProperty("IssueNavigation")]
        public virtual Comment CommentNavigation { get; set; }
        [ForeignKey(nameof(CustomerId))]
        [InverseProperty("Issue")]
        public virtual Customer Customer { get; set; }
        [ForeignKey(nameof(PictureId))]
        [InverseProperty("Issue")]
        public virtual Picture Picture { get; set; }
        [ForeignKey(nameof(SituationId))]
        [InverseProperty("Issue")]
        public virtual Situation Situation { get; set; }
        [InverseProperty("Issue")]
        public virtual ICollection<Comment> Comment { get; set; }
        [InverseProperty("IssueNavigation")]
        public virtual ICollection<Picture> PictureNavigation { get; set; }
    }

    //public partial class Issue
    //{
    //    public Issue()
    //    {
    //        Comment = new HashSet<Comment>();
    //        PictureNavigation = new HashSet<Picture>();
    //    }

    //    [Key]
    //    [Column("issue_id")]
    //    public int IssueId { get; set; }
    //    [Required]
    //    [Column("issue")]
    //    [StringLength(255)]
    //    public string Issue1 { get; set; }
    //    [Column("issue_time", TypeName = "datetime")]
    //    public DateTime IssueTime { get; set; }
    //    [Column("customer_id")]
    //    public int CustomerId { get; set; }
    //    [Column("customer_name")]
    //    public string CustomerName { get; set; }
    //    [Column("category_id")]
    //    public int CategoryId { get; set; }
    //    [Column("category")]
    //    public string Category1 { get; set; }
    //    [Column("situation_id")]
    //    public int SituationId { get; set; }
    //    [Column("situation")]
    //    public string Situation1 { get; set; }
    //    [Column("picture_id")]
    //    public int? PictureId { get; set; }
    //    [Column("picture")]
    //    public string Picture1 { get; set; }

    //    [Column("comment_id")]
    //    public int? CommentId { get; set; }
    //    [Column("comment")]
    //    public string Comment1 { get; set; }
    //    [Column("comment_time", TypeName = "datetime")]
    //    public DateTime CommentTime { get; set; }
    //    public string LvDetails => $"{IssueId} {Customer.CustomerName} {Situation.Situation1} {Category.Category1} {IssueTime}";

    //    [ForeignKey(nameof(CategoryId))]
    //    [InverseProperty("Issue")]
    //    public virtual Category Category { get; set; }
    //    [ForeignKey(nameof(CommentId))]
    //    [InverseProperty("IssueNavigation")]
    //    public virtual Comment CommentNavigation { get; set; }
    //    [ForeignKey(nameof(CustomerId))]
    //    [InverseProperty("Issue")]
    //    public virtual Customer Customer { get; set; }
    //    [ForeignKey(nameof(PictureId))]
    //    [InverseProperty("Issue")]
    //    public virtual Picture Picture { get; set; }
    //    [ForeignKey(nameof(SituationId))]
    //    [InverseProperty("Issue")]
    //    public virtual Situation Situation { get; set; }
    //    [InverseProperty("Issue")]
    //    public virtual ICollection<Comment> Comment { get; set; }
    //    [InverseProperty("IssueNavigation")]
    //    public virtual ICollection<Picture> PictureNavigation { get; set; }
    //}
}
