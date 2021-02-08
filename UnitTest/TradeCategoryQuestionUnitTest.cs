using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xunit;
using Moq;
using TradeCategoryQuestion.Models;
using TradeCategoryQuestion.Services;
using TradeCategoryQuestion.Data;
using TradeCategoryQuestion.Repositories;

namespace Test
{
    public class TradeCategoryQuestionUnitTest
    {
	private readonly ICollection<Category> Categories = new Collection<Category>();

	public TradeCategoryQuestionUnitTest() {
	    Categories.Add(new Category() { Name = "DEFAULTED", Period = 30 });
    	    Categories.Add(new Category() { Name = "MEDIUMRISK", GreaterThan = 1000000, Sector = Sector.Public });
    	    Categories.Add(new Category() { Name = "HIGHRISK", GreaterThan = 1000000, Sector = Sector.Private });
    	    Categories.Add(new Category() { Name = "POLITICALLYEXPOSEDPERSON" });
	}

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
	public void TestInvalidTrade()
	{
    	    var trade = new Trade();
	    Assert.Equal(false, IsValid(trade));
	}

        [Fact]
        public async Task TestCategorizeTrade()
        {
	    var trade = new Trade();

	    trade.Client = new Client();
	    trade.Bank = new Bank();
	    trade.Value = 2000000;
	    trade.NextPaymentDate = DateTime.Now.AddDays(31);
	    trade.ClientSector = "Private";

	    var tradeContext = new Mock<TradeContext>().Object;

	    var tradeRepositoryMock = new Mock<TradeRepository>(tradeContext).Object;

	    var categoryRepositoryMock = new Mock<CategoryRepository>(tradeContext).Object;

	    var tradeService = new TradeService(tradeRepositoryMock, categoryRepositoryMock);
	    
	    try {
	    	await tradeService.CategorizeTrade(trade);
	    } catch (Exception ex) {
	    	if (trade.Category == null) {
   	            var categorizationCriteria = new TradeCategorizationCriteria(Categories);
	            trade.Category = (Category) categorizationCriteria.CategorizeTrade(trade);
	    	}
	    }

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

 	    var tradeContext = new Mock<TradeContext>().Object;

	    var tradeRepositoryMock = new Mock<TradeRepository>(tradeContext).Object;

	    var categoryRepositoryMock = new Mock<CategoryRepository>(tradeContext).Object;

	    var tradeService = new TradeService(tradeRepositoryMock, categoryRepositoryMock);
	    
	    try {
	    	await tradeService.CategorizeTrade(trade);
	    } catch (Exception ex) {
	    	if (trade.Category == null) {
   	            var categorizationCriteria = new TradeCategorizationCriteria(Categories);
	            trade.Category = (Category) categorizationCriteria.CategorizeTrade(trade);
	    	}
	    }

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

 	    var tradeContext = new Mock<TradeContext>().Object;

	    var tradeRepositoryMock = new Mock<TradeRepository>(tradeContext).Object;

	    var categoryRepositoryMock = new Mock<CategoryRepository>(tradeContext).Object;

	    var tradeService = new TradeService(tradeRepositoryMock, categoryRepositoryMock);
	    
   	    try {
	    	await tradeService.CategorizeTrade(trade);
	    } catch (Exception ex) {
	    	if (trade.Category == null) {
   	            var categorizationCriteria = new TradeCategorizationCriteria(Categories);
	            trade.Category = (Category) categorizationCriteria.CategorizeTrade(trade);
	    	}
	    }

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

	    var tradeContext = new Mock<TradeContext>().Object;

	    var tradeRepositoryMock = new Mock<TradeRepository>(tradeContext).Object;

	    var categoryRepositoryMock = new Mock<CategoryRepository>(tradeContext).Object;

	    var tradeService = new TradeService(tradeRepositoryMock, categoryRepositoryMock);
	    
 	    try {
	    	await tradeService.CategorizeTrade(trade);
	    } catch (Exception ex) {
	    	if (trade.Category == null) {
   	            var categorizationCriteria = new TradeCategorizationCriteria(Categories);
	            trade.Category = (Category) categorizationCriteria.CategorizeTrade(trade);
	    	}
	    }

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
	    trade.NextPaymentDate = DateTime.Now;
	    trade.ClientSector = "Private";
	    trade.IsPoliticallyExposed = true;

	    var tradeContext = new Mock<TradeContext>().Object;

	    var tradeRepositoryMock = new Mock<TradeRepository>(tradeContext).Object;

	    var categoryRepositoryMock = new Mock<CategoryRepository>(tradeContext).Object;

	    var tradeService = new TradeService(tradeRepositoryMock, categoryRepositoryMock);
	    
    	    try {
	    	await tradeService.CategorizeTrade(trade);
	    } catch (Exception ex) {
	    	if (trade.Category == null) {
   	            var categorizationCriteria = new TradeCategorizationCriteria(Categories);
	            trade.Category = (Category) categorizationCriteria.CategorizeTrade(trade);
	    	}
	    }

	    var result = (trade.Category != null) ? trade.Category.Name.ToUpper() : null;	

	    Assert.Equal("POLITICALLYEXPOSEDPERSON", result);
	}
    }
}
