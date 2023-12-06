using MongoDB.Bson;
using MongoDB.Driver;

namespace ExemplosMongodb;

public class AlterandoDocumentoClasse
{
    public static void MainProgramAsync(string[] args)
    {
        Task T = MainASync(args);
        Console.WriteLine("Pressione enter");
        Console.ReadLine();
    }

    private static async Task MainASync(string[] args)
    {
        var conexao = new ConectandoMongoDb();
        Console.WriteLine("Listando e alterando livro A Dança com os Dragões ...");
        var construtor = Builders<Livro>.Filter;
        var condicao = construtor.Eq(x => x.Titulo, "A Dança com os Dragões");

        var lista = await conexao.Livros.Find(condicao).ToListAsync();
        foreach (var doc in lista)
        {
            Console.WriteLine(doc.ToJson());
        }

        Console.WriteLine("Fim da lista");

        var construtorAlteracao = Builders<Livro>.Update;
        var condicaoAlteracao = construtorAlteracao.Set(x => x.Ano, 2001);
        await conexao.Livros.UpdateOneAsync(condicao, condicaoAlteracao);
        Console.WriteLine("Registro alterado ...");

        Console.WriteLine("Listando livro A Dança com os Dragões ...");
        construtor = Builders<Livro>.Filter;
        condicao = construtor.Eq(x => x.Titulo, "A Dança com os Dragões");

        lista = await conexao.Livros.Find(condicao).ToListAsync();
        foreach (var doc in lista)
        {
            Console.WriteLine(doc.ToJson());
        }

        Console.WriteLine("Fim da lista");

        Console.WriteLine("Listando livro de Iam Fleming ...");
        construtor = Builders<Livro>.Filter;
        condicao = construtor.Eq(x => x.Autor, "Iam Fleming");

        lista = await conexao.Livros.Find(condicao).ToListAsync();
        foreach (var doc in lista)
        {
            Console.WriteLine(doc.ToJson());
        }

        Console.WriteLine("Fim da lista");

        construtorAlteracao = Builders<Livro>.Update;
        condicaoAlteracao = construtorAlteracao.Set(x => x.Autor, "T. Flaming");
        await conexao.Livros.UpdateManyAsync(condicao, condicaoAlteracao);
        Console.WriteLine("Registros alterado ...");
    }
}