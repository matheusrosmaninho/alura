using System.Collections.Generic;
using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Entidades;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Microsoft.Extensions.DependencyInjection;

namespace Alura.ByteBank.Dominio.Testes.Alura.ByteBank.Infraestrutura.Testes;

public class ClienteRepositorioTestes
{
    private readonly IClienteRepositorio _repositorio;

    public ClienteRepositorioTestes()
    {
        var servico = new ServiceCollection();
        servico.AddTransient<IClienteRepositorio, ClienteRepositorio>();
        var provedor = servico.BuildServiceProvider();
        _repositorio = provedor.GetService<IClienteRepositorio>();
    }

    [Fact]
    public void TestaObterTodosClientes()
    {
        List<Cliente> lista = _repositorio.ObterTodos();
        Assert.NotNull(lista);
    }
}