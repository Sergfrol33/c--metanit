using System;
using System.Threading.Tasks;

namespace ParallelProgramming
{
    public class ArrayTasks
    {
        public void LoopStart()
        {
            Task[] tasks = new Task[3]
            {
                new Task(() => Console.WriteLine("First Task")),
                new Task(() => Console.WriteLine("Second Task")),
                new Task(() => Console.WriteLine("Third Task")),
            };
            foreach (var task in tasks)
            {
                task.Start();
            }

            Task.WaitAll(tasks);
            
            Task[] tasks2 = new Task[3];
            var j = 1;
            for (int i = 0; i < tasks2.Length; i++)
            {
                tasks2[i] = Task.Factory.StartNew(() => Console.WriteLine($"Task {j++}"));
            }
            Console.WriteLine("Завершение метода main");
        }

        public void StructStart()
        {
            Task<int> task = new(() => Factorial(5));
            task.Start();
            Console.WriteLine($"Факториал чисел 5 равен {task.Result}");

            Task<Book> task2 = new(() =>
                new Book(){Title = "Война и мир", Author = "Л.Толстой"}
                );
            task2.Start();
            Book b = task2.Result; // ожидаем получение результата
            Console.WriteLine($"Название книги {b.Title}, автор {b.Author}");
        }
        
        private static int Factorial(int x)
        {
            if (x == 0) return 1;
            return Factorial(x - 1) * x;
        }

        class Book
        {
            public string Title { get; set; }
            public string Author { get; set; }
        }
    }
}