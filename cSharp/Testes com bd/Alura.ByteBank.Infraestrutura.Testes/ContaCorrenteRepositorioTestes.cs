using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Entidades;
using Moq;
using System;
using System.Collections.Generic;
using Alura.ByteBank.Infraestrutura.Testes.DTO;
using Xunit;

namespace Alura.ByteBank.Infraestrutura.Testes;

public class ContaCorrenteRepositorioTestes
{
    private ContaCorrenteRepositorio _repositorio;

    [Fact]
    public void TestaObterTodasContasCorrentes()
    {
        //Arrange
        _repositorio = new ContaCorrenteRepositorio();

        //Act
        List<ContaCorrente> lista = _repositorio.ObterTodos();

        //Assert
        Assert.NotNull(lista);
    }

    [Fact]
    public void TestaObterContaCorrentePorId()
    {
        //Arrange
        _repositorio = new ContaCorrenteRepositorio();

        //Act
        var conta = _repositorio.ObterPorId(1);

        //Assert
        Assert.NotNull(conta);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void TestaObterContasCorrentesPorVariosId(int id)
    {
        //Arrange
        _repositorio = new ContaCorrenteRepositorio();

        //Act
        var conta = _repositorio.ObterPorId(id);

        //Assert
        Assert.NotNull(conta);
    }

    [Fact]
    public void TestaAtualizaSaldoDeterminadaConta()
    {
        //Arrange
        _repositorio = new ContaCorrenteRepositorio();
        var conta = _repositorio.ObterPorId(2);
        double saldoNovo = 15;
        conta.Saldo = saldoNovo;

        //Act
        var atualizado = _repositorio.Atualizar(2, conta);

        //Assert
        Assert.True(atualizado);
    }

    // Testes com Mock
    [Fact]
    public void TestaObterContasMock()
    {
        //Arange
        var bytebankRepositorioMock = new Mock<IByteBankRepositorio>();
        var mock = bytebankRepositorioMock.Object;

        //Act
        mock.BuscarContasCorrentes();

        //Assert - Verificando o comportamento
        bytebankRepositorioMock.Verify(b => b.BuscarContasCorrentes());
    }

    [Fact]
    public void TestaConsultaPixMock()
    {
        //Arange
        var pixRepositorioMock = new Mock<IPixRepositorio>();
        var mock = pixRepositorioMock.Object;

        //Act
        mock.consultaPix(new Guid("a0b80d53-c0dd-4897-ab90-c0615ad80d5a"));

        //Assert - Verificando o comportamento
        pixRepositorioMock.Verify(b => b.consultaPix(new Guid("a0b80d53-c0dd-4897-ab90-c0615ad80d5a")));
    }

    [Fact]
    public void TestaInsereUmaNovaContaCorrenteNoBanciDeDados()
    {
        var conta = new ContaCorrente
        {
            Saldo = 10,
            Identificador = Guid.NewGuid(),
            Cliente = new Cliente
            {
                Nome = "Kent Nelson",
                CPF = "486.074.980-45",
                Identificador = Guid.NewGuid(),
                Profissao = "Bancario",
                Id = 1
            },
            Agencia = new Agencia
            {
                Nome = "Agencia central",
                Identificador = Guid.NewGuid(),
                Id = 1,
                Endereco = "Rua testeteeeeeeeeeeeeeeeee",
                Numero = 147
            }
        };

        var retorno = _repositorio.Adicionar(conta);
        Assert.True(retorno);
    }

    [Fact]
    public void TestaConsultaPix()
    {
        var guid = new Guid("a0b80d53-c0dd-4897-ab90-c0615ad80d5a");
        var pix = new PixDTO {Chave = guid, Saldo = 10};

        var pixRepositorioMock = new Mock<IPixRepositorio>();
        pixRepositorioMock.Setup(x => x.consultaPix(It.IsAny<Guid>())).Returns(pix);

        var mock = pixRepositorioMock.Object;

        var saldo = mock.consultaPix(guid).Saldo;
        Assert.Equal(10, saldo);
    }
}