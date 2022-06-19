using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleTarefas.Data.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TarefaPrioridade",
                columns: table => new
                {
                    CodTarefaPrioridade = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TarefaPrioridade", x => x.CodTarefaPrioridade);
                });

            migrationBuilder.CreateTable(
                name: "TarefasStatus",
                columns: table => new
                {
                    CodTarefaStatus = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TarefasStatus", x => x.CodTarefaStatus);
                });

            migrationBuilder.CreateTable(
                name: "Tarefa",
                columns: table => new
                {
                    CodTarefa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "NVARCHAR(80)", maxLength: 80, nullable: false),
                    Descricao = table.Column<string>(type: "NVARCHAR(250)", maxLength: 250, nullable: false),
                    DataInsercao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CodTarefaPrioridade = table.Column<int>(type: "int", nullable: false),
                    CodTarefaStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarefa", x => x.CodTarefa);
                    table.ForeignKey(
                        name: "FK_Tarefa_TarefaPrioridade_CodTarefaPrioridade",
                        column: x => x.CodTarefaPrioridade,
                        principalTable: "TarefaPrioridade",
                        principalColumn: "CodTarefaPrioridade",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tarefa_TarefasStatus_CodTarefaStatus",
                        column: x => x.CodTarefaStatus,
                        principalTable: "TarefasStatus",
                        principalColumn: "CodTarefaStatus",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "I_Tarefa_CodTarefa",
                table: "Tarefa",
                column: "CodTarefa",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tarefa_CodTarefaPrioridade",
                table: "Tarefa",
                column: "CodTarefaPrioridade");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefa_CodTarefaStatus",
                table: "Tarefa",
                column: "CodTarefaStatus");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tarefa");

            migrationBuilder.DropTable(
                name: "TarefaPrioridade");

            migrationBuilder.DropTable(
                name: "TarefasStatus");
        }
    }
}
