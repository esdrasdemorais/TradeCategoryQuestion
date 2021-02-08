using System;
using System.Threading.Tasks;
using Xunit;
using Moq;
using TradeCategoryQuestion.Models;
using TradeCategoryQuestion.Services;
using TradeCategoryQuestion.Data;
using TradeCategoryQuestion.Repositories;

namespace IntegrationTest
{
    public class TradeCategoryQuestionIntegrationTest
    {
	private Boolean IsValid(Trade trade) {
	    return trade.Client != null &&
		trade.Bank != null &&
		//trade.Category != null &&
		trade.Value > 0 &&
		trade.NextPaymentDate >= DateTime.Now.Date &&
		trade.ClientSector != null && trade.ClientSector.Trim().Length > 0;
	}

        [Fact]
	public void TestValidTrade()
    	{
	    var trade = new Trade();

	    trade.Client = new Client();
	    trade.Bank = new Bank();
	    trade.Value = 2000000;
	    trade.NextPaymentDate = DateTime.Now;
	    trade.ClientSector = "Private";

	    Assert.Equal(true, IsValid(trade));
	}

        [Fact]
        public async Task TestCategorizeTrade()
        {
	    var trade = new Trade();

	    trade.Client = new Client();
	    trade.Bank = new Bank();
	    trade.Value = 2000000;
	    trade.NextPaymentDate = Convert.ToDateTime("02/07/2021");
	    trade.ClientSector = "Public";

	    var tradeContext = new TradeContext();

	    var tradeRepository = new TradeRepository(tradeContext);

	    var categoryRepository = new CategoryRepository(tradeContext);

	    var tradeService = new TradeService(tradeRepository, categoryRepository);
	    
	    await tradeService.CategorizeTrade(trade);

	    Assert.Equal(true, trade.Category != null);
        }
	
	[Fact]
	public async Task TestIsDefaultedCategorizedTrade()
	{
	    var trade = new Trade();

	    trade.Client = new Client();
	    trade.Bank = new Bank();
	    trade.Value = 200000;
	    trade.NextPaymentDate = DateTime.Now.AddDays(31);
	    trade.ClientSector = "Private";

 	    var tradeContext = new TradeContext();

	    var tradeRepository = new TradeRepository(tradeContext);

	    var categoryRepository = new CategoryRepository(tradeContext);

	    var tradeService = new TradeService(tradeRepository, categoryRepository);
	    
	    await tradeService.CategorizeTrade(trade);

	    var result = (trade.Category != null) ? trade.Category.Name.ToUpper() : null;

	    Assert.Equal("DEFAULTED", result);
	}

	[Fact]
	public async Task TestIsMediumRiskCategorizedTrade()
	{
	    var trade = new Trade();

	    trade.Client = new Client();
	    trade.Bank = new Bank();
	    trade.Value = 2000000;
	    trade.NextPaymentDate = DateTime.Now;
	    trade.ClientSector = "Public";

 	    var tradeContext = new TradeContext();

	    var tradeRepository = new TradeRepository(tradeContext);

	    var categoryRepository = new CategoryRepository(tradeContext);

	    var tradeService = new TradeService(tradeRepository, categoryRepository);
	    
	    await tradeService.CategorizeTrade(trade);

	    var result = (trade.Category != null) ? trade.Category.Name.ToUpper() : null;

	    Assert.Equal("MEDIUMRISK", result);
	}

	[Fact]
	public async Task TestIsHighRiskCategorizedTrade()
	{
	    var trade = new Trade();

	    trade.Client = new Client();
	    trade.Bank = new Bank();
	    trade.Value = 2000000;
	    trade.NextPaymentDate = DateTime.Now;
	    trade.ClientSector = "Private";

	    var tradeContext = new TradeContext();

	    var tradeRepository = new TradeRepository(tradeContext);

	    var categoryRepository = new CategoryRepository(tradeContext);

	    var tradeService = new TradeService(tradeRepository, categoryRepository);
	    
	    await tradeService.CategorizeTrade(trade);

	    var result = (trade.Category != null) ? trade.Category.Name.ToUpper() : null;	

	    Assert.Equal("HIGHRISK", result);
	}

	[Fact]
	public async Task TestIsPoliticallyExposedCategorizedTrade()
	{
	    var trade = new Trade();

	    trade.Client = new Client();
	    trade.Bank = new Bank();
	    trade.Value = 200000;
	    trade.NextPaymentDate = Convert.ToDateTime("03/07/2021");
	    trade.ClientSector = "Private";
	    trade.IsPoliticallyExposed = true;

	    var tradeContext = new TradeContext();

	    var tradeRepository = new TradeRepository(tradeContext);

	    var categoryRepository = new CategoryRepository(tradeContext);

	    var tradeService = new TradeService(tradeRepository, categoryRepository);
	    
	    await tradeService.CategorizeTrade(trade);

	    var result = (trade.Category != null) ? trade.Category.Name.ToUpper() : null;	

	    Assert.Equal("POLITICALLYEXPOSEDPERSON", result);
	}
    }
}
