using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AmdarisProject.DataAccess.Migrations
{
    public partial class _changeNodeOnSection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Nodes_NodeId",
                table: "Rooms");

            migrationBuilder.DropTable(
                name: "Nodes");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_NodeId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "NodeId",
                table: "Rooms");

            migrationBuilder.AddColumn<int>(
                name: "SectionId",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NodeNumber = table.Column<int>(type: "int", nullable: false),
                    HasShower = table.Column<bool>(type: "bit", nullable: false),
                    HasToiler = table.Column<bool>(type: "bit", nullable: false),
                    FloorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sections_Floors_FloorId",
                        column: x => x.FloorId,
                        principalTable: "Floors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_SectionId",
                table: "Rooms",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_FloorId",
                table: "Sections",
                column: "FloorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Sections_SectionId",
                table: "Rooms",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Sections_SectionId",
                table: "Rooms");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_SectionId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "SectionId",
                table: "Rooms");

            migrationBuilder.AddColumn<int>(
                name: "NodeId",
                table: "Rooms",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Nodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FloorId = table.Column<int>(type: "int", nullable: false),
                    HasShower = table.Column<bool>(type: "bit", nullable: false),
                    HasToiler = table.Column<bool>(type: "bit", nullable: false),
                    NodeNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nodes_Floors_FloorId",
                        column: x => x.FloorId,
                        principalTable: "Floors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_NodeId",
                table: "Rooms",
                column: "NodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Nodes_FloorId",
                table: "Nodes",
                column: "FloorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Nodes_NodeId",
                table: "Rooms",
                column: "NodeId",
                principalTable: "Nodes",
                principalColumn: "Id");
        }
    }
}
