namespace ConsoleApp;

public class DisposeableClassTest:IDisposable
{
    public void Dispose()
    {
        Console.WriteLine("Dispose metodu çalıştı");
    }
}