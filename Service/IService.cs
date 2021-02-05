using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TradeCategoryQuestion.Models;

namespace TradeCategoryQuestion.Services {
    public interface IService<TEntity> {
	public Boolean Create(TEntity entity);
	public TEntity Read(Int64 id);
	public IEnumerable<TEntity> Read();
	public Boolean Update(TEntity entity);
	public Boolean Delete(TEntity entity);
    }
}
