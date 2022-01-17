using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelProgramming
{
    public class ParallelForEach
    {
        public void Start()
        {
            Parallel.ForEach(
                new List<int>{1,2,3,4}, (x) =>
                {
                    var result = Factorial(x);
                    Console.WriteLine($"Выполняется задача {Task.CurrentId}");
                    Console.WriteLine($"Факториал числа {x} равен {result}");
                    Thread.Sleep(3000);
                }
                );
        }
        private static int Factorial(int x)
        {
            if (x == 0) return 1;
            return Factorial(x - 1) * x;
            
        }
      
    }
}