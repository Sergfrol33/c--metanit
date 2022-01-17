using System;
using System.Threading.Tasks;

namespace ParallelProgramming
{
    public class ParallelBreak
    {
        public void Start()
        {
            var result = Parallel.For(1, 10, (x,pls) =>
            {
                if (x == 5)
                {
                    pls.Break();
                }
                var result = Factorial(x);
                Console.WriteLine($"Выполняется задача {Task.CurrentId}");
                Console.WriteLine($"Факториал числа {x} равен {result}");
            });
            if (!result.IsCompleted)
            {
                Console.WriteLine($"Выполнение цикла завершено на итерации {result.LowestBreakIteration}");
            }
        }

        private static int Factorial(int x)
        {
            if (x == 0) return 1;
            return Factorial(x - 1) * x;
            
        }
    }
}