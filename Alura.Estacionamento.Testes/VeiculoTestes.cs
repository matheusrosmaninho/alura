using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;

namespace Alura.Estacionamento.Testes;

public class VeiculoTestes
{
    [Fact]
    public void TestaVeiculoAcelerarComParametro10()
    {
        // Arrange
        var veiculo = new Veiculo();
        // Act
        veiculo.Acelerar(10);
        // Assert
        Assert.Equal(100, veiculo.VelocidadeAtual);
    }

    [Fact]
    public void TestaVeiculoFrearComParametro10()
    {
        // Arrange
        var veiculo = new Veiculo();
        // Act
        veiculo.Frear(10);
        // Assert
        Assert.Equal(-150, veiculo.VelocidadeAtual);
    }

    [Fact(Skip = "Teste ainda não implementado")]
    public void ValidaNomeProprietarioDoVeiculo()
    {
    }

    [Fact]
    public void TestaTipoVeiculo()
    {
        // Given
        var veiculo = new Veiculo();

        // Then
        Assert.Equal(TipoVeiculo.Automovel, veiculo.Tipo);
    }

    [Fact]
    public void ImprimeFichaVisualizacaoVeiculo()
    {
        // Arrange
        var carro = new Veiculo();
        carro.Proprietario = "Carlos Silva";
        carro.Tipo = TipoVeiculo.Automovel;
        carro.Placa = "qwe-1234";
        carro.Cor = "Verde";
        carro.Modelo = "Variance";

        // Act
        string dados = carro.ToString();

        // Assert
        Assert.Contains("Ficha do Veículo", dados);
    }
}