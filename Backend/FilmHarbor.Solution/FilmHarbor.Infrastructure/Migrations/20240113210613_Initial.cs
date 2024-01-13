using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FilmHarbor.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ReleaseYear = table.Column<int>(type: "int", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Action" },
                    { 2, "Drama" },
                    { 3, "Comedy" },
                    { 4, "Sci-Fi" },
                    { 5, "Thriller" },
                    { 6, "Horror" },
                    { 7, "Romance" },
                    { 8, "Adventure" },
                    { 9, "Fantasy" },
                    { 10, "Animation" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "ReleaseYear", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Opis filmu Incepcja", "https://example.com/inception.jpg", 2010, "Incepcja" },
                    { 2, 2, "Opis filmu Forest Gump", "https://example.com/forestgump.jpg", 1994, "Forest Gump" },
                    { 3, 1, "Opis filmu Szklana Pułapka", "https://example.com/diehard.jpg", 1988, "Szklana Pułapka" },
                    { 4, 1, "Opis filmu Matrix", "https://example.com/matrix.jpg", 1999, "Matrix" },
                    { 5, 3, "Opis filmu Nietykalni", "https://example.com/intouchables.jpg", 2011, "Nietykalni" },
                    { 6, 2, "Opis filmu Labirynt Fauna", "https://example.com/pan.jpg", 2006, "Labirynt Fauna" },
                    { 7, 1, "Opis filmu Gladiator", "https://example.com/gladiator.jpg", 2000, "Gladiator" },
                    { 8, 2, "Opis filmu Szeregowiec Ryan", "https://example.com/savingprivateryan.jpg", 1998, "Szeregowiec Ryan" },
                    { 9, 2, "Opis filmu Forrest Gump", "https://example.com/forrestgump.jpg", 1994, "Forrest Gump" },
                    { 10, 1, "Opis filmu Interstellar", "https://example.com/interstellar.jpg", 2014, "Interstellar" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_CategoryId",
                table: "Movies",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
