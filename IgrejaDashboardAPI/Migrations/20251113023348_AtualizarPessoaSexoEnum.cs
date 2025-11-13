using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IgrejaDashboardAPI.Migrations
{
    /// <inheritdoc />
    public partial class AtualizarPessoaSexoEnum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.RenameColumn(
              //name: "Id",
              //table: "Pessoas",
              //newName: "Codigo");

            migrationBuilder.AlterColumn<int>(
                name: "Sexo",
                table: "Pessoas",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Codigo",
                table: "Pessoas",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Sexo",
                table: "Pessoas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
