using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InteriorDesignPlanner.API.Migrations
{
    /// <inheritdoc />
    public partial class AddTableRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DesignProjectId",
                table: "FurnitureItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "DesignProjects",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FurnitureItems_DesignProjectId",
                table: "FurnitureItems",
                column: "DesignProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_DesignProjects_RoomId",
                table: "DesignProjects",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_DesignProjects_Rooms_RoomId",
                table: "DesignProjects",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_FurnitureItems_DesignProjects_DesignProjectId",
                table: "FurnitureItems",
                column: "DesignProjectId",
                principalTable: "DesignProjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DesignProjects_Rooms_RoomId",
                table: "DesignProjects");

            migrationBuilder.DropForeignKey(
                name: "FK_FurnitureItems_DesignProjects_DesignProjectId",
                table: "FurnitureItems");

            migrationBuilder.DropIndex(
                name: "IX_FurnitureItems_DesignProjectId",
                table: "FurnitureItems");

            migrationBuilder.DropIndex(
                name: "IX_DesignProjects_RoomId",
                table: "DesignProjects");

            migrationBuilder.DropColumn(
                name: "DesignProjectId",
                table: "FurnitureItems");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "DesignProjects");
        }
    }
}
