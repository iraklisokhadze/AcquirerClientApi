using Infrastucture.DBEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;

namespace Infrastucture
{
    public class AcquireDbContext : DbContext
    {
        public AcquireDbContext(DbContextOptions<AcquireDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Payment>().HasKey(p => p.Id);
            modelBuilder.Entity<Payment>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Payment>().Property(p => p.Ccy).HasMaxLength(3);
            modelBuilder.Entity<Payment>().Property(p => p.TransactionId).HasMaxLength(255);

            modelBuilder.Entity<PaymentCallback>().HasKey(p => p.Id);
            modelBuilder.Entity<PaymentCallback>().HasIndex(p => p.ShopOrderId);
            modelBuilder.Entity<PaymentCallback>().HasIndex(p => p.OrderId);
            modelBuilder.Entity<PaymentCallback>().HasIndex(p => p.IpayPaymentId);

            modelBuilder.Entity<RefundCallback>().HasKey(p => p.Id);
            modelBuilder.Entity<RefundCallback>().HasIndex(p => p.ShopOrderId);
            modelBuilder.Entity<RefundCallback>().HasIndex(p => p.OrderId);
            modelBuilder.Entity<RefundCallback>().HasIndex(p => p.IpayPaymentId);

            modelBuilder.Entity<Payment>().HasOne(p => p.PaymentStatus).WithMany(s => s.PaymentRequests).HasForeignKey(p => p.StatusId);
        }

        public DbSet<Payment> PaymentRequests { get; set; }
        public DbSet<PaymentCallback> PaymentCallbacks { get; set; }
        public DbSet<RefundCallback> RefundCallbacks { get; set; }

    }
}
