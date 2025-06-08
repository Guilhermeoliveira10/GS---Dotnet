using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
public partial class InitialCreate : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Alerts",
            columns: table => new
            {
                Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                    .Annotation("Oracle:Identity", "1, 1"),
                Titulo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                Tipo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                Data = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Alerts", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "HelpRequests",
            columns: table => new
            {
                Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                    .Annotation("Oracle:Identity", "1, 1"),
                Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                TipoAjuda = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                Localizacao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                DataSolicitacao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_HelpRequests", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "RiskZones",
            columns: table => new
            {
                Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                    .Annotation("Oracle:Identity", "1, 1"),
                Local = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                NivelRisco = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                Latitude = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                Longitude = table.Column<double>(type: "BINARY_DOUBLE", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_RiskZones", x => x.Id);
            });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(name: "Alerts");
        migrationBuilder.DropTable(name: "HelpRequests");
        migrationBuilder.DropTable(name: "RiskZones");
    }
}
