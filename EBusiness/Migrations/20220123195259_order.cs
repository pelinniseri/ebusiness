using Microsoft.EntityFrameworkCore.Migrations;

namespace EBusiness.Migrations
{
    public partial class order : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    City = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    State = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    CardName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    CardNumber = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    ExpMonat = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    ExpJahr = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    SameAddr = table.Column<bool>(type: "bit", maxLength: 300, nullable: false),
                    CVV = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
