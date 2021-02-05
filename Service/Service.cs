using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TradeCategoryQuestion.Models;
using TradeCategoryQuestion.Repositories;

namespace TradeCategoryQuestion.Services
{
    public abstract class Service<T> : IService<T> where T : TEntity {
	protected Repository<T> repository;

	public Service(Repository<T> repository) {
	    this.repository = repository;
	}

	public Boolean Create(T entity) {
	    return repository.Create(entity);
	}

	public T Read(Int64 id) {
	    return repository.Read(id);
	}

	public IEnumerable<T> Read() {
	    return repository.Read();
	}

	public Boolean Update(T entity) {
	    return repository.Update(entity);
	}

	public Boolean Delete(T entity) {
	    return repository.Delete(entity);
	}
    }
}
