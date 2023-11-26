using Microsoft.EntityFrameworkCore.Migrations;

namespace Alura.ByteBank.Dados.Migrations
{
    public partial class PopularBancoByteBank : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "INSERT INTO bytebankBD.cliente (Id, CPF, Nome, Profissao, Identificador) VALUES(0, '12345678911', 'Bruno Mars', 'Cantor', UUID());");
            migrationBuilder.Sql(
                "INSERT INTO bytebankBD.cliente (Id, CPF, Nome, Profissao, Identificador) VALUES(0, '12345678915', 'Maria Mars', 'Cantora', UUID());");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
