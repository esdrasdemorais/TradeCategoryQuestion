using System;
using System.Threading.Tasks;

namespace TradeCategoryQuestion.Repositories {
    public interface ITradeRepository {
	public Task<Boolean> PersistCategorizedTrades();
    }
}
