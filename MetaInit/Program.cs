using ParallelLinq;

namespace MetaInit
{
    class Program
    {
        static void Main(string[] args)
        {
            AsParallel.AsOrdered();
            Console.Read();
        }
    }
}