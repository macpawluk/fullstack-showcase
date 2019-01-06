using Microsoft.EntityFrameworkCore.Query;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using TreeExercise.Infrastructure;

namespace TreeExercise.UnitTests.Utils
{
	public static class MockExtensions
	{
		public static void MockSelect<TRepository, TEntity, TSelect>(
			this Mock<TRepository> repositoryMock,
			IList<TSelect> returnValue)
				where TRepository : class, IRepository
				where TEntity : class
		{
			repositoryMock
				.Setup(r =>
					r.SelectAsync(
						It.IsAny<Expression<Func<TEntity, TSelect>>>(),
						It.IsAny<Expression<Func<TEntity, bool>>>(),
						It.IsAny<Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>>(),
						It.IsAny<Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>>()
					))
				.ReturnsAsync(returnValue);
		}

		public static void VerifySelect<TRepository, TEntity, TSelect>(
			this Mock<TRepository> repositoryMock,
			Func<Times> times,
			Expression<Func<TEntity, bool>> filter = null)
				where TRepository : class, IRepository
				where TEntity : class
		{
			var filterCheck = filter ?? It.IsAny<Expression<Func<TEntity, bool>>>();

			repositoryMock
				.Verify(r =>
					r.SelectAsync(
						It.IsAny<Expression<Func<TEntity, TSelect>>>(),
						filterCheck,
						It.IsAny<Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>>(),
						It.IsAny<Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>>()
					), 
				times);
		}
	}
}
