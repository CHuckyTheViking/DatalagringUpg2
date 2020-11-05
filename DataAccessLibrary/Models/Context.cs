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
                    .HasConstraintName("FK__Comment__issue_i__693CA210");
            });

            modelBuilder.Entity<Issue>(entity =>
            {
                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Issue)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Issue__category___6754599E");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Issue)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Issue__customer___66603565");

                entity.HasOne(d => d.Situation)
                    .WithMany(p => p.Issue)
                    .HasForeignKey(d => d.SituationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Issue__situation__68487DD7");
            });

            modelBuilder.Entity<Picture>(entity =>
            {
                entity.HasOne(d => d.Issue)
                    .WithMany(p => p.Picture)
                    .HasForeignKey(d => d.IssueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Picture__issue_i__6A30C649");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
