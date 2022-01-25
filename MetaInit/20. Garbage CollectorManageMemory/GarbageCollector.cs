namespace Garbage
{
    public class GarbageCollector
    {
        public static void CreateDestructor()
        {
            Test();
            GC.Collect();
        }

        public static void Test()
        {
            User user = null;
            try
            {
                user = new User();
            }
            finally
            {
                user?.Dispose();
            }
        }

        class User : MetaInit.common.User, IDisposable
        {
            public void Dispose()
            {
                Console.Beep();
                Console.WriteLine("Dispodes");
            }
        }
    }
}