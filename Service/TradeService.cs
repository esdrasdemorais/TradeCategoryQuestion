using System;
using System.Linq;
using System.Threading.Tasks;
using TradeCategoryQuestion.Models;
using TradeCategoryQuestion.Repositories;

namespace TradeCategoryQuestion.Services
{
    public class TradeService : Service<Trade>, ITradeService
    {
	private readonly CategoryRepository categoryRepository;

	public TradeService(TradeRepository repository, CategoryRepository categoryRepository)
	    : base(repository)
	{
	    this.repository = repository;
	    this.categoryRepository = categoryRepository;
	}

	public async Task CategorizeTrade(Trade trade) {
	    var categories = categoryRepository.Read();
	    foreach (var category in categories) {
		if (trade.Value > 1000000) {
		    switch (trade.ClientSector.ToLower()) {
			case "public":
			    if (category.Name == "MEDIUMRISK") {
			        trade.Category = category;
			        break;
			    }
			break;
			case "private":
			    if (category.Name == "HIGHRISK") {
				trade.Category = category;
			        break;
			    }
			break;
		    }
		}
		if (trade.NextPaymentDate > DateTime.Now.AddDays(30) 
		    && category.Name == "DEFAULTED"
		) {
		    trade.Category = category;
		    break;
		}
	    }
	}

	public async Task<String> CategorizeTrades() {
	    var response = @"\n$$$$$$$$$$$$$$$$$ Output $$$$$$$$$$$$$$$$$$\n";

	    var trades = this.Read();

	    foreach (var trade in trades) {
		await CategorizeTrade(trade);
		response += trade.Category.Name + "\n";
	    }

   	    return response;
	}
    }
}
