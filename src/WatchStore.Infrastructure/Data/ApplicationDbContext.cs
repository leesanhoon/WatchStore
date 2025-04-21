using Microsoft.EntityFrameworkCore;
using WatchStore.Core.Domain.Entities;

namespace WatchStore.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Cấu hình cho bảng Product
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Model).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).HasMaxLength(2000);
                entity.Property(e => e.Price).HasPrecision(18, 2);
                entity.Property(e => e.ImageUrl).HasMaxLength(500);

                // Cấu hình relationship với Brand
                entity.HasOne(p => p.Brand)
                      .WithMany(b => b.Products)
                      .HasForeignKey(p => p.BrandId)
                      .OnDelete(DeleteBehavior.Restrict); // Không cho phép xóa Brand khi còn Product
            });

            // Cấu hình cho bảng Brand
            modelBuilder.Entity<Brand>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name)
                      .IsRequired()
                      .HasMaxLength(100);

                // Thêm unique constraint cho tên Brand
                entity.HasIndex(e => e.Name)
                      .IsUnique();

                entity.Property(e => e.Description).HasMaxLength(500);
                entity.Property(e => e.ImageUrl).HasMaxLength(500);
            });

            // Đặt tên các bảng theo quy ước PostgreSQL (lowercase)
            modelBuilder.Entity<Product>().ToTable("products");
            modelBuilder.Entity<Brand>().ToTable("brands");
        }
    }
}