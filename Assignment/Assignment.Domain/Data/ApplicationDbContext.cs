using Assignment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Domain.Data
{
   
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductRating> ProductRatings { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<RefreshToken> RefreshTokens { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder opitionsBuilder)
        {
            base.OnConfiguring(opitionsBuilder);
            //opitionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("CreatedDate");

                entity.Property(e => e.UpdatedDate)
                   .HasColumnType("smalldatetime")
                   .HasColumnName("UpdatedDate")
                   .HasDefaultValue(DateTime.Now);

                entity.Property(e => e.IsDeleted).HasDefaultValue(false);

                entity.ToTable("Category");
            });

            modelBuilder.Entity<Order>(entity =>
            {

                entity.Property(e => e.Qty)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.Total)
                    .IsRequired()
                    .HasMaxLength(1000000000);

                entity.Property(e => e.LastName)
                     .IsRequired()
                     .HasMaxLength(255);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(11);

                entity.Property(e => e.Address)
                     .IsRequired()
                     .HasMaxLength(255);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("CreatedDate");

                entity.Property(e => e.UpdatedDate)
                   .HasColumnType("smalldatetime")
                   .HasColumnName("UpdatedDate")
                   .HasDefaultValue(DateTime.Now);

                entity.Property(e => e.IsDeleted).HasDefaultValue(false);

                entity.ToTable("Order");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.Property(e => e.CreatedDate)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("CreatedDate");

                entity.Property(e => e.UpdatedDate)
                   .HasColumnType("smalldatetime")
                   .HasColumnName("UpdatedDate")
                   .HasDefaultValue(DateTime.Now);

                entity.ToTable("OrderDetail");
            });

            modelBuilder.Entity<ProductRating>(entity =>
            {

                entity.Property(e => e.Start)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Comment)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("CreatedDate");

                entity.Property(e => e.UpdatedDate)
                   .HasColumnType("smalldatetime")
                   .HasColumnName("UpdatedDate")
                   .HasDefaultValue(DateTime.Now);

                entity.Property(e => e.IsDeleted).HasDefaultValue(false);

                entity.ToTable("ProductRating");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Qty)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.Image)
                     .IsRequired()
                     .HasMaxLength(255);

                entity.Property(e => e.Price)
                    .IsRequired()
                    .HasMaxLength(1000000000);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("CreatedDate");

                entity.Property(e => e.UpdatedDate)
                   .HasColumnType("smalldatetime")
                   .HasColumnName("UpdatedDate")
                   .HasDefaultValue(DateTime.Now);

                entity.Property(e => e.IsDeleted).HasDefaultValue(false);

                entity.ToTable("Product");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(55);

                entity.ToTable("Role");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.Property(e => e.StatusName)
                    .IsRequired()
                    .HasMaxLength(55);

                entity.ToTable("Status");
            });

            modelBuilder.Entity<RefreshToken>(entity =>
            {

                entity.Property(e => e.ExpiryDate).HasColumnType("smalldatetime");

                entity.Property(e => e.TokenHash)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.TokenSalt)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.Ts)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("TS");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.RefreshTokens)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RefreshToken_User");

                entity.ToTable("RefreshToken");
            });           

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.PasswordSalt)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Phone)
                   .IsRequired()
                   .HasMaxLength(11);
                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("CreatedDate");

                entity.Property(e => e.UpdatedDate)
                   .HasColumnType("smalldatetime")
                   .HasColumnName("UpdatedDate")
                   .HasDefaultValue(DateTime.Now);

                entity.ToTable("User");

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
