using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace API_6._0_2.Migrations
{
    public partial class IntialDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tinh",
                columns: table => new
                {
                    Tid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Tname = table.Column<string>(type: "text", nullable: false),
                    Tdes = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tinh", x => x.Tid);
                });

            migrationBuilder.CreateTable(
                name: "Huyen",
                columns: table => new
                {
                    Hid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Hname = table.Column<string>(type: "text", nullable: false),
                    Hdes = table.Column<string>(type: "text", nullable: false),
                    Tid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Huyen", x => x.Hid);
                    table.ForeignKey(
                        name: "FK_Huyen_Tinh_Tid",
                        column: x => x.Tid,
                        principalTable: "Tinh",
                        principalColumn: "Tid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Xa",
                columns: table => new
                {
                    Xid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Xname = table.Column<string>(type: "text", nullable: false),
                    Xdes = table.Column<string>(type: "text", nullable: false),
                    Hid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Xa", x => x.Xid);
                    table.ForeignKey(
                        name: "FK_Xa_Huyen_Hid",
                        column: x => x.Hid,
                        principalTable: "Huyen",
                        principalColumn: "Hid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Huyen_Tid",
                table: "Huyen",
                column: "Tid");

            migrationBuilder.CreateIndex(
                name: "IX_Xa_Hid",
                table: "Xa",
                column: "Hid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Xa");

            migrationBuilder.DropTable(
                name: "Huyen");

            migrationBuilder.DropTable(
                name: "Tinh");
        }
    }
}
