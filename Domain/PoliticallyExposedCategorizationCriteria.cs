using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TradeCategoryQuestion.Models {
    public class PoliticallyExposedCategorizationCriteria : CategorizationCriteria, 
	ICategorizationCriteria
    {
	public PoliticallyExposedCategorizationCriteria(ICollection<Category> categories) : 
	    base (categories)
	{

	}

	public Category MountCriteria(Trade trade) {
	    var category = categories.SingleOrDefault(
		c => c.Name.ToUpper() == "POLITICALLYEXPOSEDPERSON"
	    );
	    
	    if (trade.IsPoliticallyExposed == true)
		return category;

	    return null;
	}
    }
}
