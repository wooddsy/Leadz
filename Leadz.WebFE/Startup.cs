using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Leadz.WebFE.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Leadz.Api;

namespace Leadz.WebFE
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
					
					services.AddScoped<Lead, Lead>();
					
					services.AddScoped(_ =>
					  new HttpClient
					  {
								 BaseAddress = new Uri(Configuration["serviceUrl"])
						});
					services.AddScoped<IApiClient<Lead>, ApiClient<Lead>>();
					services.AddScoped<IApiClient<Canvasser>, ApiClient<Canvasser>>();

						services.AddMvc();
				}
				
				// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
				public void Configure(IApplicationBuilder app, IHostingEnvironment env)
				{
				
					if (env.IsDevelopment())
					{
								
							app.UseDeveloperExceptionPage();
					}
					else
					{
							app.UseExceptionHandler("/Error");
					}

					app.UseStaticFiles();
                    app.UseAuthentication();

                    app.UseMvc();
				}
		}
}
