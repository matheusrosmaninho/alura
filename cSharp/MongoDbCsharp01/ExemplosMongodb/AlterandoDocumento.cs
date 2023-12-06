using MongoDB.Bson;
using MongoDB.Driver;

namespace ExemplosMongodb;

public class AlterandoDocumento
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
            doc.Ano = 2000;
            doc.Paginas = 900;
            await conexao.Livros.ReplaceOneAsync(condicao, doc);
        }

        Console.WriteLine("Listando livro A Dança com os Dragões ...");
        construtor = Builders<Livro>.Filter;
        condicao = construtor.Eq(x => x.Titulo, "A Dança com os Dragões");

        lista = await conexao.Livros.Find(condicao).ToListAsync();
        foreach (var doc in lista)
        {
            Console.WriteLine(doc.ToJson());
        }

        Console.WriteLine("Fim da lista");
    }
}