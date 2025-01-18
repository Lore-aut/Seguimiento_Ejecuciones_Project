using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeguimientoEjecuciones.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Inicio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Execution",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    post_entity = table.Column<Guid>(type: "TEXT", nullable: false),
                    actual_entity = table.Column<Guid>(type: "TEXT", nullable: false),
                    beggin = table.Column<DateTime>(type: "datetime", nullable: true),
                    end = table.Column<DateTime>(type: "datetime", nullable: true),
                    state = table.Column<string>(type: "TEXT", nullable: false),
                    execType = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Execution", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fase",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Identifier = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fase", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Operation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Identifier = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Procedure",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Identifier = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Procedure", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OperationPhasesId",
                columns: table => new
                {
                    fasesId = table.Column<Guid>(type: "TEXT", nullable: false),
                    operationsId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationPhasesId", x => new { x.fasesId, x.operationsId });
                    table.ForeignKey(
                        name: "FK_OperationPhasesId_Fase_fasesId",
                        column: x => x.fasesId,
                        principalTable: "Fase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OperationPhasesId_Operation_operationsId",
                        column: x => x.operationsId,
                        principalTable: "Operation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OperationProccessId",
                columns: table => new
                {
                    operationsId = table.Column<Guid>(type: "TEXT", nullable: false),
                    procsId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationProccessId", x => new { x.operationsId, x.procsId });
                    table.ForeignKey(
                        name: "FK_OperationProccessId_Operation_operationsId",
                        column: x => x.operationsId,
                        principalTable: "Operation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OperationProccessId_Procedure_procsId",
                        column: x => x.procsId,
                        principalTable: "Procedure",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OperationPhasesId_operationsId",
                table: "OperationPhasesId",
                column: "operationsId");

            migrationBuilder.CreateIndex(
                name: "IX_OperationProccessId_procsId",
                table: "OperationProccessId",
                column: "procsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Execution");

            migrationBuilder.DropTable(
                name: "OperationPhasesId");

            migrationBuilder.DropTable(
                name: "OperationProccessId");

            migrationBuilder.DropTable(
                name: "Fase");

            migrationBuilder.DropTable(
                name: "Operation");

            migrationBuilder.DropTable(
                name: "Procedure");
        }
    }
}
