using System.IO;
using Leadz.Api.Data;
using Leadz.Api.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
namespace Leadz.Api
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
			services.AddMvc()
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<Context>(options =>
			{
				options.UseSqlite(Configuration.GetConnectionString("leadzapicoreContext"));
				
			});
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            // Register the Identity services.
            //services.AddIdentity<ApplicationUser, IdentityRole>()
            //    .AddEntityFrameworkStores<Context>()
            //    .AddDefaultTokenProviders();
            //services.AddAuthentication()
            //        .AddGoogle(options =>
            //        {
            //            options.ClientId = "325834425027-rt5njkperehc34fo028k6hjmkt2inga3.apps.googleusercontent.com";
            //            options.ClientSecret = "RJ4deIyjXT723Yh5o7rauEYP";
            //        });

			
			
		
				services.AddScoped<ICanvasserRepo, CanvasserRepo>();
			services.AddScoped<ILeadRepo, LeadRepo>();


			
																						
			services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new Info {Title = "LeadzAPI", Version = "v1"}); });
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
                app.UseHsts();
            }
            //app.UseAuthentication();
		    app.UseSwagger();
            app.UseHttpsRedirection();
            app.UseCookiePolicy();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "LeadzAPI V1"); });

			
			if (!File.Exists("Data.db"))
			{
				Context.seeddata(app.ApplicationServices);
			}
            app.UseMvc();
		}
	}
}