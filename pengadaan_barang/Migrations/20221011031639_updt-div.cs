using Microsoft.EntityFrameworkCore.Migrations;

namespace Client.Migrations
{
    public partial class updtdiv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AnggaraanTetap",
                table: "divisi",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnggaraanTetap",
                table: "divisi");
        }
    }
}
