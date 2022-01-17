using System;
using System.Threading;
using System.Threading.Tasks;
using static System.Int32;

namespace Async
{
    public class AsyncMethods
    {
        public void Start()
        {
            Console.WriteLine("Введите число:");

            var n = Parse(Console.ReadLine() ?? string.Empty);
            FactorialAsync(n); //вызывается асинхронный метод
            Console.WriteLine($"Квадрат числа равен {n * n}");

            Console.Read();
        }

        public async void StartWhenAllAsync()
        {
            Task t1 = Task.Run(() =>
            {
                var result = Factorial(4);
                Console.WriteLine($"factorial {result}");
            });
            Task t2 = Task.Run(() =>
            {
                var result = Factorial(3);
                Console.WriteLine($"factorial {result}");
            });
            Task t3 = Task.Run(() =>
            {
                var result = Factorial(5);
                Console.WriteLine($"factorial {result}");
            });
            await Task.WhenAll(t1, t2, t3);
            Console.Read();
        }

        private int Factorial(int x)
        {
            if (x == 0) return 1;
            return Factorial(x - 1) * x;
        }

        private async void FactorialAsync(int x)
        {
            Console.WriteLine("Начало метода FactorialAsync"); // выполняется синхронно
            var result = await Task.Run(() => Factorial(5)); //выполняется асинхронно
            Thread.Sleep(8000);
            Console.WriteLine($"Факториал равен {result}");
        }
    }
}