using System;

namespace TradeCategoryQuestion.Models {
    public class Trade : TEntity, ITrade {
	private Int64 id;
	private Client client;
	private Bank bank;

	private Double @value;
	private String clientSector;
	private DateTime nextPaymentDate;
	private Category category;

	private Boolean isPoliticallyExposed = false;

	public Int64 Id {
	    get { return this.id; }
	    set { this.id = @value; }
	}

	public Client Client {
	    get { return this.client; }
	    set { this.client = value; }
	}

	public Bank Bank {
	    get { return this.bank; }
	    set { this.bank = value; }
	}

	public Double Value {
	    get { return this.value; }
	    set { this.@value = value; }
	}

	public String ClientSector {
	    get { return this.clientSector; }
	    set { this.clientSector = value; }
	}

	public DateTime NextPaymentDate {
	    get { return this.nextPaymentDate; }
	    set { this.nextPaymentDate = value; }
	}

	public Category Category {
	    get { return this.category; }
	    set { this.category = value; }
	}

	public Boolean IsPoliticallyExposed {
	    get { return this.isPoliticallyExposed; }
	    set { this.isPoliticallyExposed = value; }
	}
    }
}
