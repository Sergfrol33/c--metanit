namespace Garbage;

public class ManagerMemory
{
    public static void Test()
    {
        using (var user = new User() {Name = "Tom"})
        {
            Console.WriteLine($"Некоторые действия с объектом User. Получим его имя: {user.Name}");
        }
        Console.WriteLine("Конец метода Test");
    }

    class User: MetaInit.common.User, IDisposable
    {
        public void Dispose()
        {
            Console.WriteLine("Disposed");
        }
    }
}