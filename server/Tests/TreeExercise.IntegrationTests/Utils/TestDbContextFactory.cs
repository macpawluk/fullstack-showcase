using Microsoft.EntityFrameworkCore;
using System;
using TreeExercise.Models;

namespace TreeExercise.IntegrationTests.Utils
{
	public static class TestDbContextFactory
	{
		public static ContactsContext CreateContext()
		{
			var options = new DbContextOptionsBuilder<ContactsContext>()
				.UseInMemoryDatabase(databaseName: $"InMemoryDB_{Guid.NewGuid().ToString("N")}")
				.Options;

			return new ContactsContext(options);
		}
	}
}
