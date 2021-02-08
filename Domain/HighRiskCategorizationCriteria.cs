using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TradeCategoryQuestion.Models {
    public class HighRiskCategorizationCriteria : CategorizationCriteria, ICategorizationCriteria {
	public HighRiskCategorizationCriteria(ICollection<Category> categories) : 
	    base (categories)
	{

	}

	public Category MountCriteria(Trade trade) {
	    var category = categories.SingleOrDefault(c => c.Name.ToUpper() == "HIGHRISK");

	    if (trade.ClientSector.ToLower() == category.Sector.ToString().ToLower()
		&& trade.Value >= category.GreaterThan) return category;

	    return null;
	}
    }
}
