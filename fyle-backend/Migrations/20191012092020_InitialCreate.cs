using Microsoft.EntityFrameworkCore.Migrations;

namespace fyle_backend.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AlterDatabase()
            //    .Annotation("Npgsql:PostgresExtension:adminpack", ",,");

            //migrationBuilder.CreateTable(
            //    name: "bank_branches",
            //    columns: table => new
            //    {
            //        ifsc = table.Column<string>(maxLength: 11, nullable: true),
            //        bank_id = table.Column<long>(nullable: true),
            //        branch = table.Column<string>(maxLength: 74, nullable: true),
            //        address = table.Column<string>(maxLength: 195, nullable: true),
            //        city = table.Column<string>(maxLength: 50, nullable: true),
            //        district = table.Column<string>(maxLength: 50, nullable: true),
            //        state = table.Column<string>(maxLength: 26, nullable: true),
            //        bank_name = table.Column<string>(maxLength: 49, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //    });

            //migrationBuilder.CreateTable(
            //    name: "banks",
            //    columns: table => new
            //    {
            //        id = table.Column<long>(nullable: false),
            //        name = table.Column<string>(maxLength: 49, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_banks", x => x.id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "branches",
            //    columns: table => new
            //    {
            //        ifsc = table.Column<string>(maxLength: 11, nullable: false),
            //        bank_id = table.Column<long>(nullable: true),
            //        branch = table.Column<string>(maxLength: 74, nullable: true),
            //        address = table.Column<string>(maxLength: 195, nullable: true),
            //        city = table.Column<string>(maxLength: 50, nullable: true),
            //        district = table.Column<string>(maxLength: 50, nullable: true),
            //        state = table.Column<string>(maxLength: 26, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("branches_ifsc_pkey", x => x.ifsc);
            //        table.ForeignKey(
            //            name: "branches_banks_fkey",
            //            column: x => x.bank_id,
            //            principalTable: "banks",
            //            principalColumn: "id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_branches_bank_id",
            //    table: "branches",
            //    column: "bank_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "bank_branches");

            //migrationBuilder.DropTable(
            //    name: "branches");

            //migrationBuilder.DropTable(
            //    name: "banks");
        }
    }
}
