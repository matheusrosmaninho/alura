using MongoDB.Bson;
using MongoDB.Driver;

namespace ExemplosMongodb;

public class ListandoDocumentos
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

        Console.WriteLine("Listando documentos ...");

        var lista = await conexao.Livros.Find(new BsonDocument()).ToListAsync();
        foreach (var doc in lista)
        {
            Console.WriteLine(doc.ToJson());
        }
        
        Console.WriteLine("Fim da lista");
    }
}