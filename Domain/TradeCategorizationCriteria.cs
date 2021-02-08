using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TradeCategoryQuestion.Models {
    public class TradeCategorizationCriteria : CategorizationCriteria {
	public TradeCategorizationCriteria(ICollection<Category> categories) : 
	    base (categories)
	{
	    MountCategorizationCriteria();
	}

	private void MountCategorizationCriteria() {
	    foreach (var category in this.categories) {
	    	switch (category.Name.ToUpper()) {
		    case "DEFAULTED":
			categorizationCriteria.Add(new DefaultedCategorizationCriteria(categories));
			break;
		    case "MEDIUMRISK":
			categorizationCriteria.Add(new MediumRiskCategorizationCriteria(categories));
			break;
		    case "HIGHRISK":
			categorizationCriteria.Add(new HighRiskCategorizationCriteria(categories));
			break;
		    case "POLITICALLYEXPOSEDPERSON":
			categorizationCriteria.Add(new PoliticallyExposedCategorizationCriteria(categories));
			break;
		}
	    }
	}
    }
}
