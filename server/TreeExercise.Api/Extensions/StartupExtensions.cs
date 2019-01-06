using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TreeExercise.Api.Utils;
using TreeExercise.Api.ViewModels.Utils;
using TreeExercise.Infrastructure;
using TreeExercise.Models;
using TreeExercise.Services;
using TreeExercise.Services.Strategies;

namespace TreeExercise.Api.Extensions
{
	public static class StartupExtensions
	{
		public static void RegisterAppDependencies(this IServiceCollection services)
		{
			services.AddTransient<IContactsRepository, ContactsRepository>();
			services.AddTransient<IPersonsService, PersonsService>();

			services.AddTransient<ISearchContactsStrategyResolver, SearchContactsStrategyResolver>();
			services.AddTransient<LessOrEqualRangeTypeSearchContactsStrategy>();
			services.AddTransient<EqualRangeTypeSearchContactsStrategy>();

			services.AddTransient<IViewModelConverterFactory, ViewModelConverterFactory>();
		}

		public static void RegisterDbContexts(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<ContactsContext>(options => options.UseSqlServer(
				configuration, 
				AppConsts.DefaultConnectionStringKey));
		}
	}
}
