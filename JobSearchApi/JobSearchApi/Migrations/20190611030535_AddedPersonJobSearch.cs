using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JobSearchApi.Migrations
{
    public partial class AddedPersonJobSearch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonProfiles_Persons_PersonID",
                table: "PersonProfiles");

            migrationBuilder.RenameColumn(
                name: "PersonID",
                table: "PersonProfiles",
                newName: "PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_PersonProfiles_PersonID",
                table: "PersonProfiles",
                newName: "IX_PersonProfiles_PersonId");

            migrationBuilder.CreateTable(
                name: "JobTypes",
                columns: table => new
                {
                    Id = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonJobSearches",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PersonId = table.Column<int>(nullable: false),
                    JobTitle = table.Column<string>(nullable: true),
                    JobTypeId = table.Column<string>(nullable: true),
                    JobLocation = table.Column<string>(nullable: true),
                    PostedDate = table.Column<DateTime>(nullable: false),
                    JobTypeId1 = table.Column<short>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonJobSearches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonJobSearches_JobTypes_JobTypeId1",
                        column: x => x.JobTypeId1,
                        principalTable: "JobTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonJobSearches_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "JobTypes",
                columns: new[] { "Id", "Description" },
                values: new object[] { (short)1, "Full Time" });

            migrationBuilder.InsertData(
                table: "JobTypes",
                columns: new[] { "Id", "Description" },
                values: new object[] { (short)2, "Part Time" });

            migrationBuilder.InsertData(
                table: "JobTypes",
                columns: new[] { "Id", "Description" },
                values: new object[] { (short)3, "Contract" });

            migrationBuilder.CreateIndex(
                name: "IX_PersonJobSearches_JobTypeId1",
                table: "PersonJobSearches",
                column: "JobTypeId1");

            migrationBuilder.CreateIndex(
                name: "IX_PersonJobSearches_PersonId",
                table: "PersonJobSearches",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonProfiles_Persons_PersonId",
                table: "PersonProfiles",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonProfiles_Persons_PersonId",
                table: "PersonProfiles");

            migrationBuilder.DropTable(
                name: "PersonJobSearches");

            migrationBuilder.DropTable(
                name: "JobTypes");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "PersonProfiles",
                newName: "PersonID");

            migrationBuilder.RenameIndex(
                name: "IX_PersonProfiles_PersonId",
                table: "PersonProfiles",
                newName: "IX_PersonProfiles_PersonID");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonProfiles_Persons_PersonID",
                table: "PersonProfiles",
                column: "PersonID",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
