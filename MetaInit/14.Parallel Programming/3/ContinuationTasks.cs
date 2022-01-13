using System;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelProgramming
{
    public class ContinuationTasks
    {
        public void Start()
        {
            Task task = new(() => Console.WriteLine($"Id задачи: {Task.CurrentId}"));
            
            //задача продолжения
            Task task2 = task.ContinueWith(Display);
            task.Start();
            //ждем окончания второй задачи
            task2.Wait();
            Console.WriteLine("Выполняется работа метода main");
        }

        public void GetResultExample()
        {
            Task<int> task1 = new(() => Sum(5,4));
            
            //задача продолжения
            Task task2 = task1.ContinueWith(sum => Display(sum.Result));
            task1.Start();

            task2.Wait();
            Console.WriteLine("End of Main");

        }

        public void ChainsTasks()
        {
            Task task1 = new(() => Console.WriteLine($"Id задачи: {Task.CurrentId}"));
            
            //задача продолжения
            Task task2 = task1.ContinueWith(Display);
            Task task3 = task1.ContinueWith((_) => Console.WriteLine($"Id задачи: {Task.CurrentId}"));
            Task task4 = task2.ContinueWith((_) => Console.WriteLine($"Id задачи: {Task.CurrentId}"));
            task1.Start();
        }
        private int Sum(int x, int y) => x + y;
        private void Display(Task t)
        {
            Console.WriteLine($"Id задачи {Task.CurrentId}");
            Console.WriteLine($"Id предыдущей задачи {t.Id}");
            Thread.Sleep(3000);
        }

        private void Display(int sum) => Console.WriteLine($"Sum : {sum}");
    }
}