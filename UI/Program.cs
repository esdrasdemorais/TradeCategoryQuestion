﻿using System;
using System.Configuration;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using SimpleInjector.Integration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

using TradeCategoryQuestion.Data;
using TradeCategoryQuestion.Services;
using TradeCategoryQuestion.Repositories;
using TradeCategoryQuestion.Models;

namespace TradeCategoryQuestion.UI
{
    public class Startup
    {
	public void ConfigureServices(IServiceCollection services)
            => services.AddDbContext<TradeContext>();

    	public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    	{
	    
    	}
    }

    class Program
    {
	static private IConfiguration Configuration { get; }
        static private Container Container { get; set; }
	static private TradeService Service { get; set; }

	public static IHostBuilder CreateHostBuilder(string[] args)
            => Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(
                webBuilder => webBuilder.UseStartup<Startup>());

	static async Task Main(string[] args)
        {
            Console.WriteLine("$$$$$$$$$$$$$$ TradeCategoryQuestion $$$$$$$$$$$$$");

	    Container = new Container();
	    Container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

	    Container.Register<TradeContext>(Lifestyle.Scoped);
	    Container.Register<ITradeRepository, TradeRepository>(Lifestyle.Scoped);
	    Container.Register<TradeRepository>(Lifestyle.Scoped);
	    Container.Register<CategoryRepository>(Lifestyle.Scoped);
	    Container.Register<ITradeService, TradeService>(Lifestyle.Scoped);
	    Container.Register<TradeService>(Lifestyle.Scoped);

    	    var services = new ServiceCollection();

    	    var provider = services.AddSimpleInjector(Container)
        	.BuildServiceProvider(validateScopes: true);

	    provider.UseSimpleInjector(Container);

    	    Container.Verify();

       	    await CategorizeTrades();
        }

	static async Task SetTrade(ICollection<Trade> trades) {
	    Console.WriteLine("Input Trade Datas Separating per Space:");
	   
	    var input = Console.ReadLine();
	    var data = input.Split(' ');
	   
	    var trade = new Trade();
	    trade.Value = Convert.ToDouble(data[0]);
	    trade.ClientSector = data[1];
	    trade.NextPaymentDate = Convert.ToDateTime(data[2]);

	    trades.Add(trade);
	}

	static async Task<ICollection<Trade>> InputData() {
	    var trades = new Collection<Trade>();

	    Console.WriteLine("Input Date: ");
	    String input = Console.ReadLine();
	    var date = Convert.ToDateTime(input);
	    
	    Console.WriteLine("Input N for Trade Quantities: ");
	    input = Console.ReadLine();
	    var n = Convert.ToInt32(input);
	    
	    var i = 0;
	    while (i < n) {
		await SetTrade(trades);
		i++;
	    }

	    return trades;
	}

	static async Task SaveData(ICollection<Trade> trades) {
	    foreach (var trade in trades) {
		if (!Service.Create(trade)) throw new Exception("Erro To Persist! Try Again!");
	    }
	}

	static async Task CategorizeTrades() {
	    while (true) {
    	        using (AsyncScopedLifestyle.BeginScope(Container))
    	        {
        	    Service = Container.GetInstance<TradeService>();
		    var inputs = await InputData();
		    await SaveData(inputs);
		    var output = await Service.CategorizeTrades();
		    Console.WriteLine(output);
    	        }
	    }
	}
    }
}
