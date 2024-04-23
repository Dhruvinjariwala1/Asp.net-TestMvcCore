using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TestMvcCore.Models
{
    public partial class TestApiMvcContext : DbContext
    {
        public TestApiMvcContext()
        {
        }

        public TestApiMvcContext(DbContextOptions<TestApiMvcContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Food> Foods { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-Q44OQGMV\\SQLEXPRESS02;Initial Catalog=TestApiMvc;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Food>(entity =>
            {
                entity.ToTable("food");

                entity.Property(e => e.Foodid).HasColumnName("foodid");

                entity.Property(e => e.Foodname)
                    .HasMaxLength(50)
                    .HasColumnName("foodname");

                entity.Property(e => e.Foodprice).HasColumnName("foodprice");

                entity.Property(e => e.Foodquantity).HasColumnName("foodquantity");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
