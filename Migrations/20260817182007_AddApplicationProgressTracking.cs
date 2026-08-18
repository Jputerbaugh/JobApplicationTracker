using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobApplicationTracker.Migrations
{
    /// <inheritdoc />
    public partial class AddApplicationProgressTracking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "JobApplications",
                newName: "Stage");

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "JobApplications",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FurthestInterviewRound",
                table: "JobApplications",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Outcome",
                table: "JobApplications",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FurthestInterviewRound",
                table: "JobApplications");

            migrationBuilder.DropColumn(
                name: "Outcome",
                table: "JobApplications");

            migrationBuilder.RenameColumn(
                name: "Stage",
                table: "JobApplications",
                newName: "Status");

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "JobApplications",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }
    }
}
