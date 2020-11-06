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
            Picture = new HashSet<Picture>();
        }

        //public string LvDetails => $"{IssueId} | {IssueTime} | {Customer.CustomerName} | {Category.Category1} | {Situation.Situation1}";
        //public int dataGridIssueId => IssueId;
        //public string dataGridIssueText => Issue1;
        //public string dataGridSituation => Situation.Situation1;
        //public string dataGridCategory => Category.Category1;
        //public string dataGridCustomer => Customer.CustomerName;       
        //public DateTime dataGridIssueTime => IssueTime;

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

        [ForeignKey(nameof(CategoryId))]
        [InverseProperty("Issue")]
        public virtual Category Category { get; set; }
        [ForeignKey(nameof(CustomerId))]
        [InverseProperty("Issue")]
        public virtual Customer Customer { get; set; }
        [ForeignKey(nameof(SituationId))]
        [InverseProperty("Issue")]
        public virtual Situation Situation { get; set; }
        [InverseProperty("Issue")]
        public virtual ICollection<Comment> Comment { get; set; }
        [InverseProperty("Issue")]
        public virtual ICollection<Picture> Picture { get; set; }
    }
}
