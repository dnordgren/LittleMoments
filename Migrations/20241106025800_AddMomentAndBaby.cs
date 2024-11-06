using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LittleMoments.Migrations
{
    /// <inheritdoc />
    public partial class AddMomentAndBaby : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Babies",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Birthday = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Babies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Moments",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    MomentTimestamp = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CareGiverId = table.Column<string>(type: "TEXT", nullable: false),
                    BabyId = table.Column<string>(type: "TEXT", nullable: false),
                    MomentActivityType = table.Column<int>(type: "INTEGER", nullable: false),
                    MomentActivity = table.Column<string>(type: "TEXT", nullable: false),
                    Location = table.Column<string>(type: "TEXT", nullable: true),
                    BabyMood = table.Column<string>(type: "TEXT", nullable: true),
                    Tags = table.Column<string>(type: "TEXT", nullable: true),
                    MomentMemo = table.Column<string>(type: "TEXT", nullable: true),
                    RelatedMomentId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Moments_AspNetUsers_CareGiverId",
                        column: x => x.CareGiverId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Moments_Babies_BabyId",
                        column: x => x.BabyId,
                        principalTable: "Babies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Moments_Moments_RelatedMomentId",
                        column: x => x.RelatedMomentId,
                        principalTable: "Moments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Moments_BabyId",
                table: "Moments",
                column: "BabyId");

            migrationBuilder.CreateIndex(
                name: "IX_Moments_CareGiverId",
                table: "Moments",
                column: "CareGiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Moments_RelatedMomentId",
                table: "Moments",
                column: "RelatedMomentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Moments");

            migrationBuilder.DropTable(
                name: "Babies");
        }
    }
}
