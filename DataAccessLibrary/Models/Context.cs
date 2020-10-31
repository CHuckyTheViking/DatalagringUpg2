using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAccessLibrary.Models
{
    public partial class Context : DbContext
    {
        public Context()
        {
        }

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Issue> Issue { get; set; }
        public virtual DbSet<Picture> Picture { get; set; }
        public virtual DbSet<Situation> Situation { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:jesper-sqldatabase.database.windows.net,1433;Initial Catalog=upg2dbjesper;Persist Security Info=False;User ID=SqlAdmin;Password=kaliberSNUS1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasOne(d => d.Issue)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.IssueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Comment__issue_i__6E01572D");
            });

            modelBuilder.Entity<Issue>(entity =>
            {
                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Issue)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Issue__category___6A30C649");

                entity.HasOne(d => d.CommentNavigation)
                    .WithMany(p => p.IssueNavigation)
                    .HasForeignKey(d => d.CommentId)
                    .HasConstraintName("FK__Issue__comment_i__6D0D32F4");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Issue)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Issue__customer___693CA210");

                entity.HasOne(d => d.Picture)
                    .WithMany(p => p.Issue)
                    .HasForeignKey(d => d.PictureId)
                    .HasConstraintName("FK__Issue__picture_i__6C190EBB");

                entity.HasOne(d => d.Situation)
                    .WithMany(p => p.Issue)
                    .HasForeignKey(d => d.SituationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Issue__situation__6B24EA82");
            });

            modelBuilder.Entity<Picture>(entity =>
            {
                entity.HasOne(d => d.IssueNavigation)
                    .WithMany(p => p.PictureNavigation)
                    .HasForeignKey(d => d.IssueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Picture__issue_i__6EF57B66");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
