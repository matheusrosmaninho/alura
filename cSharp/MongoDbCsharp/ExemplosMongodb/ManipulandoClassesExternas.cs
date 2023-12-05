using MongoDB.Driver;

namespace ExemplosMongodb;

public class ManipulandoClassesExternas
{
    public static void MainProgramAsync(string[] args)
    {
        Task T = MainASync(args);
        Console.WriteLine("Pressione enter");
        Console.ReadLine();
    }

    private static async Task MainASync(string[] args)
    {
        Livro livro = new Livro();
        livro.Titulo = "Star Wars Legends";
        livro.Autor = "Timothy Zahn";
        livro.Ano = 2010;
        livro.Paginas = 245;
        List<string> listaAssuntos = new List<string>();
        listaAssuntos.Add("Ficção Científica");
        listaAssuntos.Add("Ação");
        livro.Assunto = listaAssuntos;

        var conexao = new ConectandoMongoDb();
        await conexao.Livros.InsertOneAsync(livro);
        Console.WriteLine("Documento incluido ...");
    }
}