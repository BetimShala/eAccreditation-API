using Microsoft.EntityFrameworkCore.Migrations;

namespace e_AkreditimiWebAPI.Infrastructure.Migrations
{
    public partial class esacadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Esac",
                table: "AccreditationStudyProgrammes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EsacField",
                table: "AccreditationStudyProgrammes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Esac",
                table: "AccreditationStudyProgrammes");

            migrationBuilder.DropColumn(
                name: "EsacField",
                table: "AccreditationStudyProgrammes");
        }
    }
}
