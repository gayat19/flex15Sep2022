using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyFirstWebApp.Migrations
{
    public partial class UpdatedOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderNumber",
                table: "Pizzas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TotalAmount = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderNumber);
                    table.ForeignKey(
                        name: "FK_Orders_Users_Username",
                        column: x => x.Username,
                        principalTable: "Users",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderPizzas",
                columns: table => new
                {
                    PizzaId = table.Column<int>(type: "int", nullable: false),
                    OrderNumebr = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderPizzas", x => new { x.PizzaId, x.OrderNumebr });
                    table.ForeignKey(
                        name: "FK_OrderPizzas_Orders_OrderNumebr",
                        column: x => x.OrderNumebr,
                        principalTable: "Orders",
                        principalColumn: "OrderNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderPizzas_Pizzas_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "Pizzas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "Id", "Name", "OrderNumber", "Pic", "Price" },
                values: new object[] { 101, "Pan Pizza", null, "images/Pic1.jpg", 120.4f });

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "Id", "Name", "OrderNumber", "Pic", "Price" },
                values: new object[] { 102, "Veg Extravenzza", null, "images/Pic2.jpg", 450f });

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_OrderNumber",
                table: "Pizzas",
                column: "OrderNumber");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPizzas_OrderNumebr",
                table: "OrderPizzas",
                column: "OrderNumebr");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Username",
                table: "Orders",
                column: "Username");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Orders_OrderNumber",
                table: "Pizzas",
                column: "OrderNumber",
                principalTable: "Orders",
                principalColumn: "OrderNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Orders_OrderNumber",
                table: "Pizzas");

            migrationBuilder.DropTable(
                name: "OrderPizzas");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Pizzas_OrderNumber",
                table: "Pizzas");

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DropColumn(
                name: "OrderNumber",
                table: "Pizzas");
        }
    }
}
