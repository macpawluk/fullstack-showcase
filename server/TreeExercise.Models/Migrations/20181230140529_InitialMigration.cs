using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TreeExercise.Models.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonContacts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Person1Id = table.Column<int>(nullable: false),
                    Person2Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonContacts_Persons_Person1Id",
                        column: x => x.Person1Id,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonContacts_Persons_Person2Id",
                        column: x => x.Person2Id,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Oliver", "-" },
                    { 20, "Margaret", "-" },
                    { 19, "Samantha", "-" },
                    { 18, "Kyle", "-" },
                    { 17, "Megan", "-" },
                    { 16, "Lily", "-" },
                    { 15, "William", "-" },
                    { 14, "James", "-" },
                    { 13, "Jessica", "-" },
                    { 12, "Anthony", "-" },
                    { 11, "Sophie", "-" },
                    { 10, "Thomas", "-" },
                    { 9, "Emily", "-" },
                    { 8, "Olivia", "-" },
                    { 7, "Charlie", "-" },
                    { 6, "Jacob", "-" },
                    { 5, "Harry", "-" },
                    { 4, "Jack", "-" },
                    { 3, "Mike", "-" },
                    { 2, "Amelia", "-" },
                    { 21, "David", "-" },
                    { 22, "Freddy", "-" }
                });

            migrationBuilder.InsertData(
                table: "PersonContacts",
                columns: new[] { "Id", "Person1Id", "Person2Id" },
                values: new object[,]
                {
                    { 1, 1, 2 },
                    { 22, 11, 16 },
                    { 62, 15, 14 },
                    { 61, 15, 12 },
                    { 59, 14, 15 },
                    { 17, 12, 15 },
                    { 58, 14, 12 },
                    { 16, 12, 14 },
                    { 26, 13, 3 },
                    { 25, 13, 11 },
                    { 24, 13, 12 },
                    { 21, 11, 13 },
                    { 15, 12, 13 },
                    { 6, 3, 13 },
                    { 20, 11, 12 },
                    { 14, 12, 11 },
                    { 60, 14, 16 },
                    { 13, 12, 3 },
                    { 65, 16, 11 },
                    { 23, 11, 17 },
                    { 32, 20, 19 },
                    { 31, 20, 13 },
                    { 30, 19, 20 },
                    { 28, 13, 20 },
                    { 29, 19, 13 },
                    { 27, 13, 19 },
                    { 73, 18, 15 },
                    { 72, 18, 17 },
                    { 71, 17, 18 },
                    { 64, 15, 18 },
                    { 70, 17, 16 },
                    { 69, 17, 15 },
                    { 68, 17, 11 },
                    { 67, 16, 17 },
                    { 63, 15, 17 },
                    { 66, 16, 14 },
                    { 5, 3, 12 },
                    { 40, 5, 11 },
                    { 19, 11, 5 },
                    { 44, 7, 5 },
                    { 43, 7, 4 },
                    { 38, 5, 7 },
                    { 34, 4, 7 },
                    { 39, 5, 3 },
                    { 37, 5, 4 },
                    { 36, 4, 5 },
                    { 11, 3, 5 },
                    { 33, 4, 3 },
                    { 12, 3, 4 },
                    { 77, 3, 1 },
                    { 4, 3, 2 },
                    { 3, 2, 3 },
                    { 76, 1, 3 },
                    { 2, 2, 1 },
                    { 10, 3, 8 },
                    { 41, 5, 8 },
                    { 45, 8, 3 },
                    { 46, 8, 5 },
                    { 18, 11, 3 },
                    { 7, 3, 11 },
                    { 57, 10, 8 },
                    { 56, 10, 3 },
                    { 49, 8, 10 },
                    { 8, 3, 10 },
                    { 55, 9, 5 },
                    { 74, 21, 22 },
                    { 54, 9, 6 },
                    { 52, 9, 3 },
                    { 51, 6, 9 },
                    { 48, 8, 9 },
                    { 42, 5, 9 },
                    { 9, 3, 9 },
                    { 50, 6, 8 },
                    { 47, 8, 6 },
                    { 53, 9, 8 },
                    { 75, 22, 21 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonContacts_Person2Id",
                table: "PersonContacts",
                column: "Person2Id");

            migrationBuilder.CreateIndex(
                name: "IX_PersonContacts_Person1Id_Person2Id",
                table: "PersonContacts",
                columns: new[] { "Person1Id", "Person2Id" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonContacts");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
