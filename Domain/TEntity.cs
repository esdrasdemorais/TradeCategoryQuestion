using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TradeCategoryQuestion.Models {
    public abstract class TEntity {
	[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public Int64 Id { get; }
    }
}
