using MongoDB.Bson;
using MongoDB.Driver;

namespace ExemplosMongodb;

public class ListandoDocumentosFiltroBson
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
        Console.WriteLine("Listando documentos autor Machado de assis ...");
        var filtro = new BsonDocument
        {
            {"Autor", "Machado de Assis"}  
        };

        var lista = await conexao.Livros.Find(filtro).ToListAsync();
        foreach (var doc in lista)
        {
            Console.WriteLine(doc.ToJson());
        }

        Console.WriteLine("Fim da lista");
    }
}