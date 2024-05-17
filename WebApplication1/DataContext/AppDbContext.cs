using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.DataContext
{
    public class AppDbContext : IdentityDbContext<ApplicationUser> 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products {  get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {

            base.OnModelCreating(mb);


            // Products 

            mb.Entity<Product>().Property(p => p.Name)
                                .IsRequired()
                                .HasMaxLength(30);

            mb.Entity<Product>().Property(p => p.Description)
                                .IsRequired()
                                .HasMaxLength(200);

            mb.Entity<Product>().Property(p => p.Price)
                                .IsRequired()
                                .HasColumnType("decimal");

            mb.Entity<Product>().Property(p => p.Quantity)
                                .HasColumnType("int");


            // Categories 

            mb.Entity<Category>().Property(p => p.Name)
                                 .IsRequired()
                                 .HasMaxLength(30);

            mb.Entity<Category>().Property(p => p.Description)
                                 .IsRequired()
                                 .HasMaxLength(200);



            // Relationships 


            mb.Entity<Product>().HasOne<Category>(c => c.Category)
                                .WithMany(m => m.Products)
                                .HasForeignKey(c => c.Id);
                                
        }
    }
}
