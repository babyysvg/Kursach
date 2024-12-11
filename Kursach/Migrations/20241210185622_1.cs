using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kursach.Migrations
{
    /// <inheritdoc />
    public partial class _1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vhods",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kd = table.Column<double>(type: "float", nullable: false),
                    Kr = table.Column<int>(type: "int", nullable: false),
                    sigmaHP = table.Column<int>(type: "int", nullable: false),
                    u = table.Column<float>(type: "real", nullable: false),
                    T1 = table.Column<int>(type: "int", nullable: false),
                    Shir = table.Column<float>(type: "real", nullable: false),
                    Kbe = table.Column<float>(type: "real", nullable: false),
                    Khb = table.Column<float>(type: "real", nullable: false),
                    opora = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hardness = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    typeshi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vhods", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Vyhods",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Re = table.Column<float>(type: "real", nullable: false),
                    VhodId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vyhods", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Vyhods_Vhods_VhodId",
                        column: x => x.VhodId,
                        principalTable: "Vhods",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vyhods_VhodId",
                table: "Vyhods",
                column: "VhodId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vyhods");

            migrationBuilder.DropTable(
                name: "Vhods");
        }
    }
}
