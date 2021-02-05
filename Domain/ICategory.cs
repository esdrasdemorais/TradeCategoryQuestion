using System;

namespace TradeCategoryQuestion.Models {
    public interface ICategory {
	public Int16 Period { get; set; }
	public Double GreaterThan { get; set; }
	public Sector Sector { get; set; }
    }
}
