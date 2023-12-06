using MongoDB.Bson;

namespace ExemplosMongodb;

public class ManipulandoDocumentos
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
    }
}