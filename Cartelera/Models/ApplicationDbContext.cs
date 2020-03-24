
using Cartelera.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Cartelera.Models
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        private readonly IConfiguration _conf;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration conf)
            : base(options)
        {
            _conf = conf;
        }

        public ApplicationDbContext(IConfiguration conf)
        {
            _conf = conf;
        }




        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(
                    new { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
                    new { Id = "2", Name = "Customer", NormalizedName = "CUSTOMER" },
                    new { Id = "3", Name = "Moderator", NormalizedName = "MODERATOR" }
                );
        }

        public DbSet<ProductModel> Products { get; set; }

    }
}
