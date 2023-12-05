namespace ExemplosMongodb;

class Program
{
    public static void Main(string[] args)
    {
//        MainSync(args);
//        Console.WriteLine("Pressione enter");
//        Console.ReadLine();

        ListandoDocumentosFiltroBson.MainProgramAsync(args);
    }

    private static void MainSync(string[] args)
    {
        Console.WriteLine("Esperando 10s ...");
        System.Threading.Thread.Sleep(10000);
        Console.WriteLine("Esperei 10s ...");
    }
}