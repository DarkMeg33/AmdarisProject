using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AmdarisProject.DataAccess.Migrations
{
    public partial class _changeFieldNameInSectionEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NodeNumber",
                table: "Sections",
                newName: "SectionNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SectionNumber",
                table: "Sections",
                newName: "NodeNumber");
        }
    }
}
