using MongoDB.Bson;
using MongoDB.Driver;

namespace ExemplosMongodb;

public class ManipulandoClasses
{
    public static void MainProgramAsync(string[] args)
    {
        Task T = MainASync(args);
        Console.WriteLine("Pressione enter");
        Console.ReadLine();
    }

    private static async Task MainASync(string[] args)
    {
//        var doc = new BsonDocument
//        {
//            { "Titulo", "Guerra dos tronos" }
//        };
//        doc.Add("Autor", "George R R Martin");
//        doc.Add("Ano", 1956);
//        doc.Add("Paginas", 856);
//
//        var assuntoArray = new BsonArray();
//        assuntoArray.Add("Fantasia");
//        assuntoArray.Add("Ação");
//
//        doc.Add("Assunto", assuntoArray);
//
//        Console.WriteLine(doc);
        
        Livro livro = new Livro();
        livro.Titulo = "Sob a redoma";
        livro.Autor = "Stephan King";
        livro.Ano = 2012;
        livro.Paginas = 679;
        
        List<string> listaAssuntos = new List<string>();
        listaAssuntos.Add("Ficço cientifica");
        listaAssuntos.Add("Terror~");
        listaAssuntos.Add("Aço~");
        
        livro.Assunto = listaAssuntos;

        var stringConexao = "mongodb://localhost:27017";
        IMongoClient client = new MongoClient(stringConexao);
        IMongoDatabase bancoDados = client.GetDatabase("Blibioteca");
        IMongoCollection<Livro> collection = bancoDados.GetCollection<Livro>("Livros");
        await collection.InsertOneAsync(livro);
        Console.WriteLine("Documento incluido ...");
    }
}