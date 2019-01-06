using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace TreeExercise.Api.Utils
{
	public static class ConfigurationExtensions
	{
		public static void SetDataDirectory(this IHostingEnvironment environment, string relativePath)
		{
			var dataDirectory = Path.GetFullPath(Path.Combine(environment.ContentRootPath, relativePath));
			AppDomain.CurrentDomain.SetData("DataDirectory", dataDirectory);
		}

		public static DbContextOptionsBuilder UseSqlServer(
			this DbContextOptionsBuilder optionsBuilder,
			IConfiguration configuration,
			string connectionStringKey)
		{
			const string DataDirectoryToken = "|DataDirectory|";
			var connectionString = configuration.GetConnectionString(connectionStringKey);

			if (connectionString.Contains(DataDirectoryToken))
			{
				var dataDirectory = AppDomain.CurrentDomain.GetData("DataDirectory").ToString();
				connectionString = connectionString.Replace("|DataDirectory|", dataDirectory);
			}

			optionsBuilder.UseSqlServer(connectionString);
			return optionsBuilder;
		}
	}
}
