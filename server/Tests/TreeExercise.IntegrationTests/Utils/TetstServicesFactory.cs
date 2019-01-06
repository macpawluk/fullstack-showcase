using Microsoft.Extensions.DependencyInjection;
using TreeExercise.Infrastructure;
using TreeExercise.Models;
using TreeExercise.Services;
using TreeExercise.Services.Strategies;

namespace TreeExercise.IntegrationTests.Utils
{
	public static class TetstServicesFactory
	{
		public static IPersonsService CreatePersonsService(ContactsContext dbContext)
		{
			var serviceProviderBuilder = new TestServiceProviderBuilder();

			serviceProviderBuilder.AddTrasient<IPersonsService, PersonsService>();
			serviceProviderBuilder.AddTrasient<IContactsRepository, ContactsRepository>();
			serviceProviderBuilder.AddTrasient<ISearchContactsStrategyResolver, SearchContactsStrategyResolver>();
			serviceProviderBuilder.AddTrasient<EqualRangeTypeSearchContactsStrategy, EqualRangeTypeSearchContactsStrategy>();
			serviceProviderBuilder.AddTrasient<LessOrEqualRangeTypeSearchContactsStrategy, LessOrEqualRangeTypeSearchContactsStrategy>();

			serviceProviderBuilder.AddDbContext(dbContext);

			var serviceProvider = serviceProviderBuilder.BuildServiceProvider();

			return serviceProvider.GetService<IPersonsService>();
		}
	}
}
