using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DogFood.Migrations
{
    /// <inheritdoc />
    public partial class DogFoodLibrary7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DogFoods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DogFoodName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ingredients = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductionCompany = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DogFoods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReviewerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Review = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DogFoodModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_DogFoods_DogFoodModelId",
                        column: x => x.DogFoodModelId,
                        principalTable: "DogFoods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DogFoods",
                columns: new[] { "Id", "Description", "DogFoodName", "ImageURL", "Ingredients", "ProductionCompany" },
                values: new object[,]
                {
                    { 1, "Chicken Recipe, made with love", "Purina Pro Plan: Chicken and Rice Recipe", "https://s7d2.scene7.com/is/image/PetSmart/5135727?$CLEARjpg$", "Chicken, Rice, Whole Grain Wheat, Poultry By-Product, Soybean Meal", "Purina" },
                    { 2, "Candiae, also made with love", "Canidae: Salmon and Sweet Potato", "https://img.cdn4dd.com/cdn-cgi/image/fit=contain,width=1200,height=672,format=auto/https://doordash-static.s3.amazonaws.com/media/photosV2/478f1454-4f23-43f0-96b9-d68b45008397-retina-large.jpg", "Salmon, Barley, Salmon Meal, Lentils, Sweet Potato, Garbanzo beans", "Canidae" },
                    { 3, "Keep your dog healthy, happy and full with the 4health with Wholesome Grains Adult Salmon and Potato Formula Dry Dog Food. The wholesome, carefully selected ingredients provide optimal nutrition for adult dogs of any breed", "4Health: Salmon and Potato", "https://media.tractorsupply.com/is/image/TractorSupplyCompany/1424210?wid=456&hei=456&fmt=jpeg&qlt=100,0&resMode=sharp2&op_usm=0.9,1.0,8,0", "Salmon, ocean fish meal, potatoes, peas, cracked pearled barley, pea flour, egg product, canola oil", "Diamond Pet Foods Inc" }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "DogFoodModelId", "Review", "ReviewerName" },
                values: new object[,]
                {
                    { 1, 1, "This dog food sucks, it killed my dog!", "Steve Smith" },
                    { 2, 2, "This dog food is the best, it brought my dog back to life!", "Roger Rabbit" },
                    { 3, 3, "My vet says potatoes are a Very Common allergy.My dogs now have bald spots.", "Tim Horton" },
                    { 4, 1, "When the bag got delivered to the house, it had a RIP in it, and the DOG FOOD WAS REAL CRUNMBLY it just looked like it was STALE.", "Jackass666" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_DogFoodModelId",
                table: "Reviews",
                column: "DogFoodModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "DogFoods");
        }
    }
}
