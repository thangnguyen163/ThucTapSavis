using Microsoft.EntityFrameworkCore;
using ThucTapSavis_Shared.Models;

namespace ThucTapSavis_API.Data
{
    public class MyDbContext:DbContext
    {
        public MyDbContext()
        {

        }

        public MyDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillItem> BillItems { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<ProductItem> ProductItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<PromotionItem> PromotionsItem { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Cart>().HasKey(a => a.UserId);
            builder.Entity<Cart>().HasOne(u => u.User).WithOne(c => c.Cart).HasForeignKey<Cart>(c => c.UserId);
            builder.Entity<Bill>().HasOne(u => u.Users).WithMany(b => b.Bills).HasForeignKey(b => b.UserId);
            builder.Entity<BillItem>().HasOne(b => b.Bills).WithMany(bi => bi.BillItems).HasForeignKey(bi => bi.BillId);
            builder.Entity<Image>().HasOne(pi => pi.ProductItems).WithMany(i => i.Images).HasForeignKey(i => i.ProductItemId);
            builder.Entity<ProductItem>().HasOne(c => c.Colors).WithMany(pi => pi.ProductItem).HasForeignKey(pi => pi.ColorId);
            builder.Entity<ProductItem>().HasOne(s => s.Size).WithMany(pi => pi.ProductItem).HasForeignKey(pi => pi.SizeId);
            builder.Entity<PromotionItem>().HasOne(pi => pi.ProductItems).WithMany(pp => pp.PromotionsItems).HasForeignKey(pp => pp.ProductItemsId);
            builder.Entity<PromotionItem>().HasOne(p => p.Promotions).WithMany(pp => pp.PromotionsItem).HasForeignKey(pp => pp.PromotionsId);
            builder.Entity<ProductItem>().HasOne(p => p.Products).WithMany(pi => pi.ProductItems).HasForeignKey(pi => pi.ProductId);
            builder.Entity<Product>().HasOne(c => c.Categorys).WithMany(p => p.Products).HasForeignKey(p => p.CategoryId);
            builder.Entity<CartItem>().HasOne(pi => pi.ProductItems).WithMany(ci => ci.CartItems).HasForeignKey(ci => ci.ProductItemId);
            builder.Entity<CartItem>().HasOne(c => c.Cart).WithMany(ci => ci.CartItems).HasForeignKey(ci => ci.UserId);
            builder.Entity<BillItem>().HasOne(pi => pi.ProductItems).WithMany(bi => bi.BillItems).HasForeignKey(bi => bi.ProductItemsId);
            builder.Entity<BillItem>().HasOne(b => b.Bills).WithMany(bi => bi.BillItems).HasForeignKey(bi => bi.BillId);


        }
    }

}
