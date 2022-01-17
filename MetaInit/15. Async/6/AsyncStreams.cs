using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Async
{
    public class AsyncStreams
    {
        public static async void Run()
        {
            await foreach (var number in GetNumberAsync())
            {
                Console.WriteLine(number);
            }
        }

        private static async IAsyncEnumerable<int> GetNumberAsync()
        {
            for (var i = 0; i < 10; i++)
            {
                await Task.Delay(1000);
                yield return i;
            }
        }

        public static async void GetData()
        {
            Repository repo = new();
            IAsyncEnumerable<string> data = repo.GetDataAsync();
            await foreach (var name in data)
            {
                Console.WriteLine(name);
            }
        }
    }
    class Repository
    {
        private readonly List<string> data = new() {"Tom", "Sam", "Kate", "Alice"};

        public  async IAsyncEnumerable<string> GetDataAsync()
        {
            for (var index = 0; index < data.Count; index++)
            {
                Console.WriteLine($"Получаем {index + 1} элемент");
                await Task.Delay(1000);
                yield return data[index];
            }
        }
    }
}