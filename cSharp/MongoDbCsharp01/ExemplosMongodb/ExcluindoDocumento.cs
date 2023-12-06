using MongoDB.Bson;
using MongoDB.Driver;

namespace ExemplosMongodb;

public class ExcluindoDocumento
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
        Console.WriteLine("Listando os livros de T. Flaming ...");
        var construtor = Builders<Livro>.Filter;
        var condicao = construtor.Eq(x => x.Autor, "T. Flaming");

        var lista = await conexao.Livros.Find(condicao).ToListAsync();
        foreach (var doc in lista)
        {
            Console.WriteLine(doc.ToJson());
        }
        Console.WriteLine("Fim da lista");
        
        Console.WriteLine("Excluindo os livros");
        await conexao.Livros.DeleteManyAsync(condicao);
        
        Console.WriteLine("Listando os livros de T. Flaming ...");
        construtor = Builders<Livro>.Filter;
        condicao = construtor.Eq(x => x.Autor, "T. Flaming");

        lista = await conexao.Livros.Find(condicao).ToListAsync();
        foreach (var doc in lista)
        {
                Console.WriteLine(doc.ToJson());
        }
        Console.WriteLine("Fim da lista");
    }
}