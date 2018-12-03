using System;
using System.Globalization;
using Leadz.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Leadz.Api.Data
{
	public class Context : DbContext
	{
		public Context(DbContextOptions<Context> options)
			: base(options)
		{ }

		public Context()
		{ }

		public DbSet<Canvasser> Canvasser { get; set; }

		public DbSet<Lead> Lead { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite("Data Source=Data.db");
			
		}

		public static void seeddata(IServiceProvider serviceProvider)
		{
			IFormatProvider culter = new CultureInfo("en-UK");
			using (var serviceScope = serviceProvider
			                          .GetRequiredService<IServiceScopeFactory>().CreateScope())
			{
				var _context = serviceScope
				               .ServiceProvider.GetService<Context>();

				_context.Database.EnsureCreated();

				_context.Canvasser.AddRange(new Canvasser
				                            {
																				Name = "wood",
																				Address = "2 canvasser street",
																				Id = 1,
																				PhoneNo = 07754326781,
																				TeamId = 1,
																				Role = "Team Leader"
				                            }, 
				                            new Canvasser
				                            {
					                              Name    = "Toward",
					                              Address = "3 canvasser street",
					                              Id      = 2,
					                              PhoneNo = 07754326771,
					                              TeamId  = 1,
					                              Role    = "Canvasser"
																		});
				_context.Lead.AddRange(new Lead
				                          {
					                          Surname     = "jones",
					                          HouseNumber = 1,
					                          Street      = "teststreet",
					                          Town        = "testtown",
					                          PostCode    = "ne17 9nx",
					                          AppointmentDateTime =
						                          DateTime.ParseExact("16/06/2018 17:00", "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),
					                          NoOfDoors   = 2,
					                          NoOfWindows = 8,
					                          Notes       = "mrs only",
					                          Status      = "belled",
					                          DateTaken   = DateTime.Now,
					                          CanvasserId = "1"
				                          }, 
				                       new Lead
																	{
																		Surname     = "Williams",
																		HouseNumber = 2,
																		Street      = "teststreet",
																		Town        = "testtown",
																		PostCode    = "ne17 9nx",
																		AppointmentDateTime =
																				DateTime.ParseExact("15/06/2018 16:00", "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),


																		NoOfDoors   = 2,
																		NoOfWindows = 8,
																		Notes       = "very intrested had other quotes",
																		Status      = "PBO",
																		CanvasserId = "2"
																	});
				_context.SaveChanges();
			}
		}
	}
}