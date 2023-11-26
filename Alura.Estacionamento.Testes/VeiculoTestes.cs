using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Testes;

public class VeiculoTestes : IDisposable
{
    private Veiculo veiculo;

    public ITestOutputHelper SaidaConsoleTeste;

    public VeiculoTestes(ITestOutputHelper _saidaConsoleTeste)
    {
        SaidaConsoleTeste = _saidaConsoleTeste;
        SaidaConsoleTeste.WriteLine("Construtor invocado ...");
        veiculo = new Veiculo();
    }

    [Fact]
    public void TestaVeiculoAcelerarComParametro10()
    {
        veiculo.Acelerar(10);
        // Assert
        Assert.Equal(100, veiculo.VelocidadeAtual);
    }

    [Fact]
    public void TestaVeiculoFrearComParametro10()
    {
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
        Assert.Equal(TipoVeiculo.Automovel, veiculo.Tipo);
    }

    [Fact]
    public void ImprimeFichaVisualizacaoVeiculo()
    {
        veiculo.Proprietario = "Carlos Silva";
        veiculo.Tipo = TipoVeiculo.Automovel;
        veiculo.Placa = "qwe-1234";
        veiculo.Cor = "Verde";
        veiculo.Modelo = "Variance";

        // Act
        string dados = veiculo.ToString();

        // Assert
        Assert.Contains("Ficha do Veículo", dados);
    }

    public void Dispose()
    {
        SaidaConsoleTeste.WriteLine("Dispose invocado ...");
    }
}