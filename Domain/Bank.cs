using System;

namespace TradeCategoryQuestion.Models {
    public class Bank : TEntity {
	private Int64 id;
	private String name;

	public Int64 Id {
	    get { return this.id; }
	    set { this.id = value; }
	}

	public String Name {
	    get { return this.name; }
	    set { this.name = value; }
	}
    }
}
