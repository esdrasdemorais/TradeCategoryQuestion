using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TradeCategoryQuestion.Models {
    public class DefaultedCategorizationCriteria : CategorizationCriteria, ICategorizationCriteria
    {
	private ICollection<Category> categories;

	public DefaultedCategorizationCriteria(ICollection<Category> categories) : 
    	    base (categories)
	{
	    this.categories = categories;
	}

	public Category MountCriteria(Trade trade) {
	    var category = categories.SingleOrDefault(c => c.Name.ToUpper() == "DEFAULTED");
	    
	    if (trade.NextPaymentDate > DateTime.Now.AddDays(category.Period) 
	        && trade.Value >= category.GreaterThan) return category;

	    return null;
	}
    }
}
