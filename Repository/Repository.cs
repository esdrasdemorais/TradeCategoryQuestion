using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TradeCategoryQuestion.Models;

namespace TradeCategoryQuestion.Repositories {
    public abstract class Repository<T> : IRepository<T> where T : TEntity {
	protected DbContext context;

	public Repository(DbContext context) {
	    this.context = context;
	}

	public Boolean Create(T entity) {
	    context.Set<T>().Add(entity);
	    context.SaveChanges();
	    return true;
	}

	public T Read(Int64 id) {
	    return context.Set<T>().SingleOrDefault(t => t.Id == id);
	}

	public IEnumerable<T> Read() {
	    return context.Set<T>().AsEnumerable<T>().ToList();
	}

	public Boolean Update(T entity) {
	    context.Set<T>().Update(entity);
	    context.SaveChanges();
	    return true;
	}

	public Boolean Delete(T entity) {
	    context.Set<T>().Remove(entity);
	    context.SaveChanges();
	    return true;
	}
    }
}
