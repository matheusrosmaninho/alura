using System;
using Alura.ByteBank.Dados.Contexto;

namespace Alura.ByteBank.Dominio.Testes.Alura.ByteBank.Infraestrutura.Testes;

public class ByteBankContextoTestes
{
    [Fact]
    public void TestaConexaoContextoComMysql()
    {
        var contexto = new ByteBankContexto();
        bool conectado;

        try
        {
            conectado = contexto.Database.CanConnect();
        }
        catch (Exception e)
        {
            throw new Exception("Não foi possivel conectar na base de dados ...");
        }
        
        Assert.True(conectado);
    }
}