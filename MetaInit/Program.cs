using FileSystem;
using Garbage;


namespace MetaInit
{
    class Program    
    {
        static void Main(string[] args)
        {
            FileSystem.File file = new( @"C:\apache\hta.txt");
            file.DeleteFile();
            Console.Read();
        }
    }
}