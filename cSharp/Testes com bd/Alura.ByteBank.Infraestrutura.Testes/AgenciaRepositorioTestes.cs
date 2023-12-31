﻿using System;
using System.Collections.Generic;
using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Entidades;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Xunit;
using Xunit.Abstractions;

namespace Alura.ByteBank.Infraestrutura.Testes;

public class AgenciaRepositorioTestes
{
    private IAgenciaRepositorio _repositorio;

    public ITestOutputHelper SaidaConsoleTest {get; set;}

    public AgenciaRepositorioTestes(ITestOutputHelper saidaConsoleTest)
    {
        SaidaConsoleTest = saidaConsoleTest;
        SaidaConsoleTest.WriteLine("Construtor invocado ...");
        var servico = new ServiceCollection();
        servico.AddTransient<IAgenciaRepositorio, AgenciaRepositorio>();

        var provedor = servico.BuildServiceProvider();
        _repositorio = provedor.GetService<IAgenciaRepositorio>();
    }

    [Fact]
    public void TestaObterTodasAgencias()
    {
        //Arrange
        _repositorio = new AgenciaRepositorio();

        //Act
        List<Agencia> lista = _repositorio.ObterTodos();

        //Assert
        Assert.NotNull(lista);
    }

    [Fact]
    public void TestaObterAgenciaPorId()
    {
        //Arrange
        _repositorio = new AgenciaRepositorio();

        //Act
        var agencia = _repositorio.ObterPorId(1);

        //Assert
        Assert.NotNull(agencia);
    }

    [Theory]
    [InlineData(1)]
    public void TestaObterAgenciasPorVariosId(int id)
    {
        //Arrange
        _repositorio = new AgenciaRepositorio();

        //Act
        var agencia = _repositorio.ObterPorId(id);

        //Assert
        Assert.NotNull(agencia);
    }

    [Fact]
    public void TestaAtualizacaoInformacaoDeterminadaAgencia()
    {
        //Arrange
        var agencia = _repositorio.ObterPorId(1);
        var nomeNovo = "Agencia Nova";
        agencia.Nome = nomeNovo;

        //Act
        var atualizado = _repositorio.Atualizar(1, agencia);

        //Assert
        Assert.True(atualizado);
    }

    [Fact]
    public void TestaAdiconarAgenciaMock()
    {
        // Arrange
        var agencia = new Agencia()
        {
            Nome = "Agência Amaral",
            Identificador = Guid.NewGuid(),
            Id = 4,
            Endereco = "Rua Arthur Costa",
            Numero = 6497
        };

        var repositorioMock = new ByteBankRepositorio();

        //Act
        var adicionado = repositorioMock.AdicionarAgencia(agencia);

        //Assert
        Assert.True(adicionado);
    }

    [Fact]
    public void TestaRemoverFormacaoDeterminadaAgencia()
    {
        var atualizado = _repositorio.Excluir(3);
        Assert.True(atualizado);
    }

    [Fact]
    public void TestaExcecaoConsultaAgenciaPorId()
    {
        var teste = _repositorio.ObterPorId(33);
        Assert.Null(teste);
    }

    [Fact]
    public void TestaAdicionarAgenciaMock()
    {
        var agencia = new Agencia()
        {
            Nome = "Agencia amaral",
            Identificador = Guid.NewGuid(),
            Id = 4,
            Endereco = "Rua Mariakkkkkkkkkkkkkkkkkkkkkkk",
            Numero = 12345
        };

        var repositorioMock = new ByteBankRepositorio();
        var adicionado = repositorioMock.AdicionarAgencia(agencia);
        Assert.True(adicionado);
    }

    [Fact]
    public void TestaObterAgenciasMock()
    {
        var bytebankRepositorioMock = new Mock<IByteBankRepositorio>();
        var mock = bytebankRepositorioMock.Object;

        var lista = mock.BuscarAgencias();
        bytebankRepositorioMock.Verify(b => b.BuscarAgencias());
    }
}