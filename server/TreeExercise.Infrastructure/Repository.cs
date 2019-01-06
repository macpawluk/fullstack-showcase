using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace TreeExercise.Infrastructure
{
	public abstract class Repository : IRepository
	{
		private readonly DbContext _dbContext;

		protected Repository(DbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<IList<TEntity>> GetAllAsync<TEntity>(
			Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
			where TEntity : class
		{
			IQueryable<TEntity> query = _dbContext.Set<TEntity>();

			if (include != null)
			{
				query = include(query);
			}

			return await query.ToListAsync();
		}

		public async Task<IList<TEntity>> WhereAsync<TEntity>(
			Expression<Func<TEntity, bool>> filter,
			Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
			where TEntity : class
		{
			IQueryable<TEntity> query = _dbContext.Set<TEntity>();

			if (include != null)
			{
				query = include(query);
			}

			return await query
				.Where(filter)
				.ToListAsync();
		}

		public async Task<IList<TSelect>> SelectAsync<TEntity, TSelect>(
			Expression<Func<TEntity, TSelect>> select,
			Expression<Func<TEntity, bool>> filter = null,
			Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
			where TEntity : class
		{
			IQueryable<TEntity> query = _dbContext.Set<TEntity>();

			if (include != null)
			{
				query = include(query);
			}
			if (filter != null)
			{
				query = query.Where(filter);
			}
			if (orderBy != null)
			{
				query = orderBy(query);
			}

			return await query
				.Select(select)
				.ToListAsync();
		}
	}
}
