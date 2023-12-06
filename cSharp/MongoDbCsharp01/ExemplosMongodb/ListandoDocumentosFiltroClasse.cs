using MongoDB.Bson;
using MongoDB.Driver;

namespace ExemplosMongodb;

public class ListandoDocumentosFiltroClasse
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
        Console.WriteLine("Listando documentos autor Machado de assis classe ...");
        var construtor = Builders<Livro>.Filter;
        var condicao = construtor.Eq(x => x.Autor, "Machado de Assis");

        var lista = await conexao.Livros.Find(condicao).ToListAsync();
        foreach (var doc in lista)
        {
            Console.WriteLine(doc.ToJson());
        }

        Console.WriteLine("Fim da lista");

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Listando documentos a partir de 1999 e mais de 300 pginas ...");
        construtor = Builders<Livro>.Filter;
        condicao = construtor.Gte(x => x.Ano, 1999) & construtor.Gte(x => x.Paginas, 300);

        lista = await conexao.Livros.Find(condicao).ToListAsync();
        foreach (var doc in lista)
        {
            Console.WriteLine(doc.ToJson());
        }

        Console.WriteLine("Fim da lista");

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Listando documentos somente ficçao cientifica ...");
        construtor = Builders<Livro>.Filter;
        condicao = construtor.AnyEq(x => x.Assunto, "Ficção Científica");

        lista = await conexao.Livros.Find(condicao).SortBy(x => x.Titulo).ToListAsync();
        foreach (var doc in lista)
        {
            Console.WriteLine(doc.ToJson());
        }

        Console.WriteLine("Fim da lista");
    }
}