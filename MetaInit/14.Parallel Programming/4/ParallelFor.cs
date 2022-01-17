using System;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelProgramming
{
    public class ParallelFor
    {
        public void Start()
        {
            Parallel.For(1, 10, (x) =>
            {
                var result = Factorial(x);
                Console.WriteLine($"Выполняется задача {Task.CurrentId}");
                Console.WriteLine($"Факториал числа {x} равен {result}");
                Thread.Sleep(3000);
            });
        }
        private static int Factorial(int x)
        {
            if (x == 0) return 1;
            return Factorial(x - 1) * x;
            
        }
      
    }
}