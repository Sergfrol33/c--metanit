using System;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelProgramming
{
    public class ParallelClass
    {
        public void Start()
        {
            Parallel.Invoke(Display, () =>
            {
                Console.WriteLine($"Выполняется задача {Task.CurrentId}");
                Thread.Sleep(3000);
            }, () =>
            {
                var result = Factorial(5);
                Console.WriteLine($"Выполняется задача {Task.CurrentId}");
                Thread.Sleep(3000);
                Console.WriteLine($"Результат {result}");
            });
        }
        private static int Factorial(int x)
        {
            if (x == 0) return 1;
            return Factorial(x - 1) * x;
            
        }
        private void Display()
        {
            Console.WriteLine($"Выполняется задача {Task.CurrentId}");
            Thread.Sleep(3000);
        }
    }
}