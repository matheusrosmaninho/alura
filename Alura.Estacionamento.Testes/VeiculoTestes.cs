using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;

namespace Alura.Estacionamento.Testes;

public class VeiculoTestes
{
    [Fact]
    [Trait("Funcionalidade", "Acelerar")]
    public void TestaVeiculoAcelerar()
    {
        // Arrange
        var veiculo = new Veiculo();
        // Act
        veiculo.Acelerar(10);
        // Assert
        Assert.Equal(100, veiculo.VelocidadeAtual);
    }

    [Fact]
    [Trait("Funcionalidade", "Frear")]
    public void TestaVeiculoFrear()
    {
        // Arrange
        var veiculo = new Veiculo();
        // Act
        veiculo.Frear(10);
        // Assert
        Assert.Equal(-150, veiculo.VelocidadeAtual);
    }

    [Fact]
    public void TestaTipoVeiculo()
    {
        // Given
        var veiculo = new Veiculo();

        // When

        // Then
        Assert.Equal(TipoVeiculo.Automovel, veiculo.Tipo);
    }
}