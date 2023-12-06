namespace ExemplosMongodb;

public class ProgramAsync
{
    public static void MainProgramAsync(string[] args)
    {
        Task T = MainASync(args);
        Console.WriteLine("Pressione enter");
        Console.ReadLine();
    }

    private static async Task MainASync(string[] args)
    {
        Console.WriteLine("Esperando 10s ...");
        await Task.Delay(10000);
        Console.WriteLine("Esperei 10s ...");
    }
}