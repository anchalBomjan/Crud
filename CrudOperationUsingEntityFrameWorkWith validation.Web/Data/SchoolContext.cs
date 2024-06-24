using CrudOperationUsingEntityFrameWorkWith_validation.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudOperationUsingEntityFrameWorkWith_validation.Web.Data
{
    public class SchoolContext:DbContext
    {

        public SchoolContext(DbContextOptions<SchoolContext>option):base(option) { }


        public DbSet <Teacher>Teachers {  get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Skills)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Salary)
                    .IsRequired()
                    .HasColumnType("money");

                entity.Property(e => e.AddedOn)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");
            });
        }





    }
}
