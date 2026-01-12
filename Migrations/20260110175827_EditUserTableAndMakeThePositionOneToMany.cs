using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OmniSystem.Migrations
{
    /// <inheritdoc />
    public partial class EditUserTableAndMakeThePositionOneToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserPositions");

            migrationBuilder.AddColumn<int>(
                name: "PositionId",
                table: "AspNetUsers",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PositionId",
                table: "AspNetUsers",
                column: "PositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Positions_PositionId",
                table: "AspNetUsers",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Positions_PositionId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PositionId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PositionId",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "UserPositions",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    PositionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPositions", x => new { x.UserId, x.PositionId });
                    table.ForeignKey(
                        name: "FK_UserPositions_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPositions_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserPositions_PositionId",
                table: "UserPositions",
                column: "PositionId");
        }
    }
}
