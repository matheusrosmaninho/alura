using System.Collections.Generic;
using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Entidades;

namespace Alura.ByteBank.Dominio.Testes.Alura.ByteBank.Infraestrutura.Testes;

public class ClienteRepositorioTestes {
    [Fact]
    public void TestaObterTodosClientes()
    {
        var repository = new ClienteRepositorio();
        
        List<Cliente> lista = repository.ObterTodos();
        Assert.NotNull(lista);
    }
}