using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Threading;
using System.Threading.Tasks;
using TradeCategoryQuestion.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace TradeCategoryQuestion.Data {
    public class TradeContext : DbContext {
        //public TradeContext(TradeDbContextOptions options) : base(options) {}
	
	//private readonly String connectionString;

    	//public TradeContext(String connectionString)
    	//{
            //this.connectionString = connectionString;
    	//}

	public TradeContext() { }

    	/*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    	{
            optionsBuilder.UseSqlServer(connectionString);
    	}*/

        public virtual DbSet<Client> Client { get; set; }
	public virtual DbSet<Bank> Bank { get; set; }
	public virtual DbSet<Trade> Trade { get; set; }
	public virtual DbSet<Category> Category { get; set; }

        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder => {
            builder.AddConsole();
            }
        );

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
	    if (!optionsBuilder.IsConfigured)
            {
            	IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
            	var connectionString = configuration.GetConnectionString("DefaultConnection");
            	optionsBuilder.UseMySql(connectionString, new MariaDbServerVersion(new Version(10, 5, 6)));
            }

            base.OnConfiguring(optionsBuilder);
          
            optionsBuilder.UseLoggerFactory(loggerFactory)
                .EnableSensitiveDataLogging();
        }
    }
}
