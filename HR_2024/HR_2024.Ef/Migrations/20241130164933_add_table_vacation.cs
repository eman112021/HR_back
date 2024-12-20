using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR_2024.Ef.Migrations
{
    /// <inheritdoc />
    public partial class add_table_vacation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vacations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vacation_start_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    vacation_end_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    vacation_count = table.Column<int>(type: "int", nullable: false),
                    national_num = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    id_emp = table.Column<int>(type: "int", nullable: false),
                    type_vacation = table.Column<int>(type: "int", nullable: false),
                    flag = table.Column<int>(type: "int", nullable: false),
                    date_insert = table.Column<DateTime>(type: "datetime2", nullable: false),
                    date_update = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacations", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vacations");
        }
    }
}
