using System;
using System.Threading.Tasks;

namespace TradeCategoryQuestion {
    public interface ITradeService {
	Task<String> CategorizeTrades();
    }
}
