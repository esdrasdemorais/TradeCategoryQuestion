using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TradeCategoryQuestion.Models {
    public abstract class CategorizationCriteria {
    	protected readonly ICollection<Category> categories;

	protected readonly ICollection<ICategorizationCriteria> categorizationCriteria;

	public CategorizationCriteria(ICollection<Category> categories)
	{
	    this.categories = categories;
	    this.categorizationCriteria = new Collection<ICategorizationCriteria>();
	}

	public Category CategorizeTrade(Trade trade) {
	    var category = new Category();

	    foreach (ICategorizationCriteria categorizationCritery in categorizationCriteria) {
		category = categorizationCritery.MountCriteria(trade);
		if (category != null) return category;
	    }

	    return null;
	}
    }
}
