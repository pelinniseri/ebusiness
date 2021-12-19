using Microsoft.EntityFrameworkCore.Migrations;

namespace EBusiness.Migrations
{
    public partial class mymigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>("Role", "Users", "varchar(255)",
        unicode: false, maxLength: 255, nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
