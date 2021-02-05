using System;

namespace TradeCategoryQuestion.Models {
    public class Client : TEntity {
	private Int64 id;
	private String name;
	private Double salary;

	public Int64 Id {
	    get { return this.id; }
	    set { this.id = value; }
	}

	public String Name {
	    get { return this.name; }
	    set { this.name = value; }
	}

	public Double Salary {
	    get { return this.salary; }
	    set { this.salary = value; }
	}
    }
}
