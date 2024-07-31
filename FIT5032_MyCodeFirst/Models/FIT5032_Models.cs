using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace FIT5032_MyCodeFirst.Models
{
    public partial class FIT5032_Models : DbContext
    {
        public FIT5032_Models()
            : base("name=FIT5032_Models2")
        {
        }

        public virtual DbSet<students> students { get; set; }
        public virtual DbSet<units> units { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<students>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<students>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<students>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<students>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<students>()
                .HasMany(e => e.units)
                .WithOptional(e => e.students)
                .HasForeignKey(e => e.student_id);

            modelBuilder.Entity<units>()
                .Property(e => e.name)
                .IsUnicode(false);
        }
    }
}
