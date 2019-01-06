using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace TreeExercise.IntegrationTests.Utils
{
	public class TestServiceProviderBuilder
	{
		private readonly ServiceCollection _services;

		public TestServiceProviderBuilder()
		{
			_services = new ServiceCollection();
		}

		public void AddTrasient<TService, TImplementation>()
			where TService : class
			where TImplementation : class, TService
		{
			_services.AddTransient<TService, TImplementation>();
		}

		public void AddDbContext<TDbContext>(TDbContext dbContext)
			where TDbContext : DbContext
		{
			_services.AddScoped(provider => dbContext);
		}

		public IServiceProvider BuildServiceProvider()
		{
			var serviceProviderFactory = new DefaultServiceProviderFactory();
			return serviceProviderFactory.CreateServiceProvider(_services);
		}
	}
}
