using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TreeExercise.Infrastructure
{
	public interface IRepository
	{
		Task<IList<TEntity>> GetAllAsync<TEntity>(
			Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
			where TEntity : class;

		Task<IList<TEntity>> WhereAsync<TEntity>(
			Expression<Func<TEntity, bool>> filter,
			Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
			where TEntity : class;

		Task<IList<TSelect>> SelectAsync<TEntity, TSelect>(
			Expression<Func<TEntity, TSelect>> select,
			Expression<Func<TEntity, bool>> filter = null,
			Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
			where TEntity : class;
	}
}
