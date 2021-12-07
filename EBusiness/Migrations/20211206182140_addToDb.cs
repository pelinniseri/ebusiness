using Microsoft.EntityFrameworkCore.Migrations;

namespace EBusiness.Migrations
{
    public partial class addToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Userid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserAd = table.Column<string>(type: "Varchar(30)", maxLength: 30, nullable: true),
                    UserSoyad = table.Column<string>(type: "Varchar(30)", maxLength: 30, nullable: false),
                    UserSehir = table.Column<string>(type: "Varchar(13)", maxLength: 13, nullable: true),
                    UserMail = table.Column<string>(type: "Varchar(50)", maxLength: 50, nullable: true),
                    UserSifre = table.Column<string>(type: "Varchar(10)", maxLength: 10, nullable: true),
                    Durum = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Userid);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
