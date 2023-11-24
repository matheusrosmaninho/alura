using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;

namespace Alura.Estacionamento.Testes;

public class PatioTestes
{
    [Fact]
    public void ValidaFaturamento()
    {
        // Given
        var veiculo = new Veiculo();
        var estacionamento = new Patio();
        veiculo.Proprietario = "André Silva";
        veiculo.Tipo = TipoVeiculo.Automovel;
        veiculo.Cor = "Verde";
        veiculo.Modelo = "Fusca";
        veiculo.Placa = "asd-9999";

        estacionamento.RegistrarEntradaVeiculo(veiculo);
        estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

        // When
        double faturamento = estacionamento.TotalFaturado();

        // Then
        Assert.Equal(2, faturamento);
    }

    [Theory]
    [InlineData("Andre Silva", "asd-0000", "preto", "Gol")]
    [InlineData("José Silva", "pol-0000", "preto", "Fusca")]
    [InlineData("Mariana Silva", "prl-9090", "vermelha", "Mercedes")]
    [InlineData("Pedro Silva", "prl-9090", "vermelha", "Mercedes")]
    public void ValidaFaturamentoComVariosVeiculos(
        string proprietario,
        string placa,
        string cor,
        string modelo
    ) {
        // Arrange
        var estacionamento = new Patio();
        var veiculo = new Veiculo();
        veiculo.Proprietario = proprietario;
        veiculo.Placa = placa;
        veiculo.Cor = cor;
        veiculo.Modelo = modelo;

        estacionamento.RegistrarEntradaVeiculo(veiculo);
        estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

        // Act
        double faturamento = estacionamento.TotalFaturado();

        // Assert
        Assert.Equal(2, faturamento);
    }

    [Fact(Skip = "Teste ainda não implementado")]
    public void ValidaNomeProprietario()
    {
        // Given

        // When

        // Then
    }
}