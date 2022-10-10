using Microsoft.EntityFrameworkCore.Migrations;

namespace Client.Migrations
{
    public partial class addingPropertyToSupplier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "supplier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Telepon",
                table: "supplier",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "supplier");

            migrationBuilder.DropColumn(
                name: "Telepon",
                table: "supplier");
        }
    }
}
