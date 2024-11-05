using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SustenAI.Migrations
{
    /// <inheritdoc />
    public partial class InitialDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_sustenAIarquivos",
                table: "sustenAIarquivos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_sustenAI_produtos",
                table: "sustenAI_produtos");

            migrationBuilder.RenameTable(
                name: "sustenAIarquivos",
                newName: "sustenAI_arquivos");

            migrationBuilder.RenameTable(
                name: "sustenAI_produtos",
                newName: "susten_produtos");

            migrationBuilder.AlterColumn<decimal>(
                name: "precisao_prev",
                table: "sustenAI_previsoes",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "preco",
                table: "susten_produtos",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_sustenAI_arquivos",
                table: "sustenAI_arquivos",
                column: "id_arq");

            migrationBuilder.AddPrimaryKey(
                name: "PK_susten_produtos",
                table: "susten_produtos",
                column: "id_prod");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_sustenAI_arquivos",
                table: "sustenAI_arquivos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_susten_produtos",
                table: "susten_produtos");

            migrationBuilder.RenameTable(
                name: "sustenAI_arquivos",
                newName: "sustenAIarquivos");

            migrationBuilder.RenameTable(
                name: "susten_produtos",
                newName: "sustenAI_produtos");

            migrationBuilder.AlterColumn<decimal>(
                name: "precisao_prev",
                table: "sustenAI_previsoes",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "preco",
                table: "sustenAI_produtos",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_sustenAIarquivos",
                table: "sustenAIarquivos",
                column: "id_arq");

            migrationBuilder.AddPrimaryKey(
                name: "PK_sustenAI_produtos",
                table: "sustenAI_produtos",
                column: "id_prod");
        }
    }
}
