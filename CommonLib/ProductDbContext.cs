using CommonLib.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib
{
    public class ProductDbContext : DbContext
    {
        public static readonly ILoggerFactory ConsoleLogger
          = LoggerFactory.Create(builder => { builder.AddConsole(); });

        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Not for production, show EF query data in the console
            optionsBuilder.UseLoggerFactory(ConsoleLogger);
            // Show EF Query parameter values in the console
            optionsBuilder.EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }

}
