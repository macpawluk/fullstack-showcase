using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TreeExercise.Api.Extensions;
using TreeExercise.Api.Utils;

namespace TreeExercise.Api
{
	public class Startup
	{
		private const string AllowAllCorsPolicyName = "AllowAll";

		public Startup(IConfiguration configuration, IHostingEnvironment environment)
		{
			Configuration = configuration;
			environment.SetDataDirectory("..\\..\\db");
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
			services.Configure<MvcOptions>(options =>
			{
				options.Filters.Add(new CorsAuthorizationFilterFactory(AllowAllCorsPolicyName));
			});

			services.AddCors(options =>
			{
				options.AddPolicy(AllowAllCorsPolicyName,
					builder => builder
							.AllowAnyOrigin()
							.AllowAnyMethod()
							.AllowAnyHeader());
			});

			services.RegisterDbContexts(Configuration);
			services.RegisterAppDependencies();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseMvc();
		}
	}
}
