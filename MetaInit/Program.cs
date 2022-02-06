using FileSystem;
using Garbage;
using JSONSerializer;


namespace MetaInit
{
    class Program    
    {
        static void Main(string[] args)
        {
            Serializer.ReadAndWriteAsync();
            Console.Read();
        }
    }
}