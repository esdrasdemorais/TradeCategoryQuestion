using System;
using System.Threading.Tasks;
using TradeCategoryQuestion.Models;
using TradeCategoryQuestion.Data;

namespace TradeCategoryQuestion.Repositories {
    public class TradeRepository : Repository<Trade>, ITradeRepository {
	public TradeRepository(TradeContext context) : base(context) {
	    this.context = context;
	}

	public async Task<Boolean> PersistCategorizedTrades() {
	    return true;
	}
    }
}
