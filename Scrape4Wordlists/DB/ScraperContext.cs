using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Scrape4Wordlists.Models;

namespace Scrape4Wordlists.DB
{
    public class ScraperContext : DbContext
    {
        public ScraperContext()
        {
        }

        public ScraperContext(DbContextOptions<ScraperContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("dbconnection.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("ScraperContext");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        public DbSet<ScrapedUri> ScrapeUri { get; set; }
    }
}
