namespace ExemplosMongodb;

public class ValoresLivros
{
    public static Livro IncluiValoresLivro(string titulo, string autor, int ano, int paginas, string assuntos)
    {
        Livro livro = new Livro();
        livro.Titulo = titulo;
        livro.Autor = autor;
        livro.Ano = ano;
        livro.Paginas = paginas;
        string[] vetAssunto = assuntos.Split(',');
        List<string> vetAssunto2 = new List<string>();
        for (int i = 0; i <= vetAssunto.Length - 1; i++)
        {
            vetAssunto2.Add(vetAssunto[i].Trim());
        }

        livro.Assunto = vetAssunto2;
        return livro;
    }
}