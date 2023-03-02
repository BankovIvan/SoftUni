using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P01_HospitalDatabase.Migrations
{
    public partial class DoctorsAdded2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Speciality",
                table: "Doctors",
                newName: "Specialty");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Specialty",
                table: "Doctors",
                newName: "Speciality");
        }
    }
}
