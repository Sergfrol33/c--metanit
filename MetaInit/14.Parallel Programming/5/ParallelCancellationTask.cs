using System;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelProgramming
{
    public class ParallelCancellationTask
    {
        public void Start()
        {
            CancellationTokenSource source = new();
            var token = source.Token;
            var number = 6;

            var task = new Task(() =>
            {
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("Операция прервана");
                    return;
                }
                var result = Factorial(number);
                Console.WriteLine($"Факториал числа {number} равен {result}");
                Thread.Sleep(5000);
            });
            task.Start();
            
            Console.WriteLine("Введите Y для отмены операции или другой символ для её продолжения");
            if (Console.ReadLine() == "Y") source.Cancel();
            Console.Read();
        }

        private int Factorial(int x)
        {
            if (x == 0) return 1;
            return Factorial(x - 1) * x;
            
        }
    }
}