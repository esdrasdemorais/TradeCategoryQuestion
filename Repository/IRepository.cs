using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TradeCategoryQuestion.Models;

namespace TradeCategoryQuestion.Repositories {
    public interface IRepository<TEntity> {
	public Boolean Create(TEntity entity);
	public TEntity Read(Int64 id);
	public IEnumerable<TEntity> Read();
	public Boolean Update(TEntity entity);
	public Boolean Delete(TEntity entity);
    }
}
