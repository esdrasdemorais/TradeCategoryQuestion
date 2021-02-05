using System;

namespace TradeCategoryQuestion.Models {
    public class Category : TEntity, ICategory {
 	private Int64 id;
	private String name;

	private Int16 period;
	private Double greaterThan;
	private Sector sector;

	public Int64 Id {
	    get { return this.id; }
	    set { this.id = value; }
	}

	public String Name {
	    get { return this.name; }
	    set { this.name = value; }
	}

	public Int16 Period { 
	    get { return this.period; }
       	    set { this.period = value; }
	}

	public Double GreaterThan {
	    get { return this.greaterThan; }
	    set { this.greaterThan = value; }
	}

	public Sector Sector {
	    get { return this.sector; }
	    set { this.sector = value; }
	}
    }
}
