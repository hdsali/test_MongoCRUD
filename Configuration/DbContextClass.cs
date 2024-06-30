using Microsoft.EntityFrameworkCore;
using MongoTest7CQRS.Domain;


namespace MongoTest7CQRS.Configurations
{
        public class DbContextClass : DbContext
        {
            protected readonly IConfiguration Configuration;

            public DbContextClass(IConfiguration configuration)
            {
                Configuration = configuration;
            }
            protected override void OnConfiguring(DbContextOptionsBuilder options)
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            }

            public DbSet<ProductDetails> Products { get; set; }
        }
    }

