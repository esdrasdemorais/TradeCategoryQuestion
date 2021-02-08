using System;

namespace TradeCategoryQuestion.Models {
    public interface ICategorizationCriteria {
	public Category MountCriteria(Trade trade);
    }
}
