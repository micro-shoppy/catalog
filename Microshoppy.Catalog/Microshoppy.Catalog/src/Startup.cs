using System;
using MassTransit;
using MediatR;
using Microshoppy.Catalog.CQRS.Command;
using Microshoppy.Catalog.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Microshoppy.Catalog
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{

			services.AddControllers();
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "Microshoppy.Catalog", Version = "v1" });
			});
			services.AddMediatR(typeof(CreateCatalogProductCommand));
			services.AddTransient<ICatalogRepository, InMemoryCatalogRepository>();
			var rabbitOptions = new RabbitMqOptions();
			Configuration.GetSection("RabbitMq").Bind(rabbitOptions);
			services.AddMassTransit(x =>
			{
				x.UsingRabbitMq((context, cfg) =>
				{
					cfg.Host(new Uri(rabbitOptions.Host));
					cfg.ConfigureEndpoints(context);
				});
			});
			services.AddMassTransitHostedService();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Microshoppy.Catalog v1"));
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
