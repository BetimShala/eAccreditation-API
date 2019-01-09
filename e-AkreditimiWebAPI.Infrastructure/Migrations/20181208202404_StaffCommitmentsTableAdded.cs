using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace e_AkreditimiWebAPI.Infrastructure.Migrations
{
    public partial class StaffCommitmentsTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcademicStaffCommitments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StaffId = table.Column<int>(nullable: false),
                    StaffId1 = table.Column<string>(nullable: true),
                    FacultyId = table.Column<int>(nullable: false),
                    AcademicYear = table.Column<string>(nullable: true),
                    DeclarationDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicStaffCommitments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AcademicStaffCommitments_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AcademicStaffCommitments_AspNetUsers_StaffId1",
                        column: x => x.StaffId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcademicStaffCommitments_FacultyId",
                table: "AcademicStaffCommitments",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicStaffCommitments_StaffId1",
                table: "AcademicStaffCommitments",
                column: "StaffId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcademicStaffCommitments");
        }
    }
}
