using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR_2024.Ef.Migrations
{
    /// <inheritdoc />
    public partial class addtable_evaluation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vacations");

            migrationBuilder.CreateTable(
                name: "evaluations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    eval = table.Column<byte>(type: "tinyint", nullable: false),
                    year = table.Column<int>(type: "int", nullable: false),
                    id_emp = table.Column<int>(type: "int", nullable: false),
                    degree = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_evaluations", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "evaluations");

            migrationBuilder.CreateTable(
                name: "Vacations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date_insert = table.Column<DateTime>(type: "datetime2", nullable: false),
                    date_update = table.Column<DateTime>(type: "datetime2", nullable: false),
                    flag = table.Column<int>(type: "int", nullable: false),
                    id_emp = table.Column<int>(type: "int", nullable: false),
                    national_num = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type_vacation = table.Column<int>(type: "int", nullable: false),
                    vacation_count = table.Column<int>(type: "int", nullable: false),
                    vacation_end_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    vacation_start_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacations", x => x.Id);
                });
        }
    }
}
