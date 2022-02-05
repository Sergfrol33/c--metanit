using FileSystem;
using Garbage;


namespace MetaInit
{
    class Program    
    {
        static void Main(string[] args)
        {
            var fileStreaming = new FileStreaming();
            fileStreaming.Seek();
            Console.Read();
        }
    }
}