using System.Collections.Generic;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DevReviewsDbContext : DbContext
    {
        public DevReviewsDbContext(DbContextOptions<DevReviewsDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductReview> ProductReviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(p =>
            {
                p.ToTable("tb_Product");
                p.HasKey(p => p.Id);
            });

            modelBuilder.Entity<ProductReview>(pr =>
            {
                pr.ToTable("tb_Product");
                pr.HasKey(p => p.Id);
                pr.Property(p => p.Author)
                    .HasMaxLength(50)
                    .HasColumnName("n_author");
            });

            //  modelBuilder.Entity<Product>()
            //      .ToTable("tb_Product")
            //      .HasKey();

            // modelBuilder.Entity<Product>()
            //     .HasKey(p => p.Id);

            // modelBuilder.Entity<ProductReview>()
            //     .ToTable("tb_ProductReviews");
        }

    }
}