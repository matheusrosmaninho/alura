using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Testes;

public class PatioTestes : IDisposable
{
    private Veiculo veiculo;

    public ITestOutputHelper SaidaConsoleTeste;

    public PatioTestes(ITestOutputHelper _saidaConsoleTeste)
    {
        SaidaConsoleTeste = _saidaConsoleTeste;
        veiculo = new Veiculo();
    }

    [Fact]
    public void ValidaFaturamentoDoEstacionamentoComVeiculo()
    {
        // Given
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
    public void ValidaFaturamentoDoEstacionamentoComVariosVeiculos(
        string proprietario,
        string placa,
        string cor,
        string modelo
    )
    {
        // Arrange
        var estacionamento = new Patio();
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

    [Theory]
    [InlineData("André Silva", "ASD-1498", "preto", "Gol")]
    public void LocalizaVeiculoNoPatioBaseadoNaPlaca(
        string proprietario,
        string placa,
        string cor,
        string modelo
    )
    {
        // Arrange
        var estacionamento = new Patio();
        veiculo.Proprietario = proprietario;
        veiculo.Placa = placa;
        veiculo.Cor = cor;
        veiculo.Modelo = modelo;

        estacionamento.RegistrarEntradaVeiculo(veiculo);

        // Act
        var consultado = estacionamento.PesquisaVeiculo(veiculo.Placa);

        // Assert
        Assert.Equal(placa, consultado.Placa);
    }

    [Fact]
    public void AlterarDadosDoProprioVeiculo()
    {
        var estacionamento = new Patio();
        veiculo.Proprietario = "André Silva";
        veiculo.Tipo = TipoVeiculo.Automovel;
        veiculo.Cor = "Verde";
        veiculo.Modelo = "Fusca";
        veiculo.Placa = "asd-9999";
        estacionamento.RegistrarEntradaVeiculo(veiculo);

        var veiculoAterado = new Veiculo();
        veiculoAterado.Proprietario = "André Silva";
        veiculoAterado.Tipo = TipoVeiculo.Automovel;
        veiculoAterado.Cor = "Azul";
        veiculoAterado.Modelo = "Mercedes";
        veiculoAterado.Placa = "asd-9999";

        Veiculo alterado = estacionamento.AlteraDadosVeiculo(veiculoAterado);
    }

    public void Dispose()
    {
        SaidaConsoleTeste.WriteLine("Dispose invocado ...");
    }
}
