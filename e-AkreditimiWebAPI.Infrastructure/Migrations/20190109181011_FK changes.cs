using Microsoft.EntityFrameworkCore.Migrations;

namespace e_AkreditimiWebAPI.Infrastructure.Migrations
{
    public partial class FKchanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AcademicStaffCommitments_AspNetUsers_StaffId1",
                table: "AcademicStaffCommitments");

            migrationBuilder.DropForeignKey(
                name: "FK_AccrStudyProgrammesSubjects_AspNetUsers_ProfessorId1",
                table: "AccrStudyProgrammesSubjects");

            migrationBuilder.DropIndex(
                name: "IX_AccrStudyProgrammesSubjects_ProfessorId1",
                table: "AccrStudyProgrammesSubjects");

            migrationBuilder.DropIndex(
                name: "IX_AcademicStaffCommitments_StaffId1",
                table: "AcademicStaffCommitments");

            migrationBuilder.DropColumn(
                name: "ProfessorId1",
                table: "AccrStudyProgrammesSubjects");

            migrationBuilder.DropColumn(
                name: "StaffId1",
                table: "AcademicStaffCommitments");

            migrationBuilder.AlterColumn<string>(
                name: "ProfessorId",
                table: "AccrStudyProgrammesSubjects",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "StaffId",
                table: "AcademicStaffCommitments",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_AccrStudyProgrammesSubjects_ProfessorId",
                table: "AccrStudyProgrammesSubjects",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicStaffCommitments_StaffId",
                table: "AcademicStaffCommitments",
                column: "StaffId");

            migrationBuilder.AddForeignKey(
                name: "FK_AcademicStaffCommitments_AspNetUsers_StaffId",
                table: "AcademicStaffCommitments",
                column: "StaffId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AccrStudyProgrammesSubjects_AspNetUsers_ProfessorId",
                table: "AccrStudyProgrammesSubjects",
                column: "ProfessorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AcademicStaffCommitments_AspNetUsers_StaffId",
                table: "AcademicStaffCommitments");

            migrationBuilder.DropForeignKey(
                name: "FK_AccrStudyProgrammesSubjects_AspNetUsers_ProfessorId",
                table: "AccrStudyProgrammesSubjects");

            migrationBuilder.DropIndex(
                name: "IX_AccrStudyProgrammesSubjects_ProfessorId",
                table: "AccrStudyProgrammesSubjects");

            migrationBuilder.DropIndex(
                name: "IX_AcademicStaffCommitments_StaffId",
                table: "AcademicStaffCommitments");

            migrationBuilder.AlterColumn<int>(
                name: "ProfessorId",
                table: "AccrStudyProgrammesSubjects",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfessorId1",
                table: "AccrStudyProgrammesSubjects",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StaffId",
                table: "AcademicStaffCommitments",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StaffId1",
                table: "AcademicStaffCommitments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccrStudyProgrammesSubjects_ProfessorId1",
                table: "AccrStudyProgrammesSubjects",
                column: "ProfessorId1");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicStaffCommitments_StaffId1",
                table: "AcademicStaffCommitments",
                column: "StaffId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AcademicStaffCommitments_AspNetUsers_StaffId1",
                table: "AcademicStaffCommitments",
                column: "StaffId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AccrStudyProgrammesSubjects_AspNetUsers_ProfessorId1",
                table: "AccrStudyProgrammesSubjects",
                column: "ProfessorId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
