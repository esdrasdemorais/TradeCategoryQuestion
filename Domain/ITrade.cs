using System;

namespace TradeCategoryQuestion.Models {
    public interface ITrade
    {
        public Double Value { get; set; } //indicates the transaction amount in dollars
        public String ClientSector { get; set; } //indicates the client´s sector which can be "Public" or "Private"
        public DateTime NextPaymentDate { get; set; } //indicates when the next payment from the client to the bank is expected
	public Category Category { get; set; }
	public Boolean IsPoliticallyExposed { get; set; }
    }
}
