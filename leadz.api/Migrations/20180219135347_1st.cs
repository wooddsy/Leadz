using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leadz.Api.Migrations
{
	public partial class _1st : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
			                             name: "Canvasser",
			                             columns: table => new
			                                               {
				                                               CanvasserId = table.Column<string>(nullable: false),
				                                               Address     = table.Column<string>(nullable: true),
				                                               Name        = table.Column<string>(nullable: true),
				                                               PhoneNo     = table.Column<long>(nullable: false),
				                                               Role        = table.Column<string>(nullable: true),
				                                               TeamId      = table.Column<int>(nullable: false)
			                                               },
			                             constraints: table => { table.PrimaryKey("PK_Canvasser", x => x.CanvasserId); });

			migrationBuilder.CreateTable(
			                             name: "Lead",
			                             columns: table => new
			                                               {
				                                               LeadId              = table.Column<Guid>(nullable: false),
				                                               AppointmentDateTime = table.Column<DateTime>(nullable: false),
				                                               CanvasserId         = table.Column<string>(nullable: true),
				                                               HouseNumber         = table.Column<int>(nullable: false),
				                                               NoOfDoors           = table.Column<int>(nullable: false),
				                                               NoOfWindows         = table.Column<int>(nullable: false),
				                                               Notes               = table.Column<string>(nullable: true),
				                                               PostCode            = table.Column<string>(nullable: true),
				                                               Status              = table.Column<string>(nullable: true),
				                                               Street              = table.Column<string>(nullable: true),
				                                               Surname             = table.Column<string>(nullable: true),
				                                               Town                = table.Column<string>(nullable: true)
			                                               },
			                             constraints: table =>
			                             {
				                             table.PrimaryKey("PK_Lead", x => x.LeadId);
				                             table.ForeignKey(
				                                              name: "FK_Lead_Canvasser_CanvasserId",
				                                              column: x => x.CanvasserId,
				                                              principalTable: "Canvasser",
				                                              principalColumn: "CanvasserId",
				                                              onDelete: ReferentialAction.Restrict);
			                             });

			migrationBuilder.CreateIndex(
			                             name: "IX_Lead_CanvasserId",
			                             table: "Lead",
			                             column: "CanvasserId");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
			                           name: "Lead");

			migrationBuilder.DropTable(
			                           name: "Canvasser");
		}
	}
}