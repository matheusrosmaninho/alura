using MongoDB.Bson;
using MongoDB.Driver;

namespace ExemplosMongodb;

public class AcessandoMongodb
{
    public static void MainProgramAsync(string[] args)
    {
        Task T = MainASync(args);
        Console.WriteLine("Pressione enter");
        Console.ReadLine();
    }

    private static async Task MainASync(string[] args)
    {
        var doc = new BsonDocument
        {
            { "Titulo", "Guerra dos tronos" }
        };
        doc.Add("Autor", "George R R Martin");
        doc.Add("Ano", 1956);
        doc.Add("Paginas", 856);

        var assuntoArray = new BsonArray();
        assuntoArray.Add("Fantasia");
        assuntoArray.Add("Ação");

        doc.Add("Assunto", assuntoArray);

        Console.WriteLine(doc);

        var stringConexao = "mongodb://localhost:27017";
        IMongoClient client = new MongoClient(stringConexao);
        IMongoDatabase bancoDados = client.GetDatabase("Blibioteca");
        IMongoCollection<BsonDocument> collection = bancoDados.GetCollection<BsonDocument>("Livros");
        await collection.InsertOneAsync(doc);
        Console.WriteLine("Documento incluido ...");
    }
}