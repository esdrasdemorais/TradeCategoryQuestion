using System;
using TradeCategoryQuestion.Models;
using TradeCategoryQuestion.Data;

namespace TradeCategoryQuestion.Repositories {
    public class CategoryRepository : Repository<Category> {
	public CategoryRepository(TradeContext context) : base(context) {
	    this.context = context;
	}
    }
}
