using Microsoft.EntityFrameworkCore;
using Mango.Services.CouponAPI.Models;

namespace Mango.Services.CouponAPI.Data
{
    public class AppDbContext : DbContext
    {
        // DbContextOptions<AppDbContext> options
        public  AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Coupon> Coupons { set; get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Coupon>().HasData(new Coupon { CouponId = 1, CouponCode = "10PER", DiscountAmount = 10 });
            modelBuilder.Entity<Coupon>().HasData(new Coupon { CouponId = 2, CouponCode = "20PER", DiscountAmount = 20 });

        }


    }
}
