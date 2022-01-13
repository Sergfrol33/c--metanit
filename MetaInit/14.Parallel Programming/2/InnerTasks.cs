using System;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelProgramming
{
    public class InnerTasks
    {
        public void Start()
        {
            var outer = Task.Factory.StartNew(() => //внешняя задача
            {
                Console.WriteLine("Внешняя задача");
                var inner = Task.Factory.StartNew(() => //вложенная задача
                {
                    Console.WriteLine("Inner task starting...");
                    Thread.Sleep(2000);
                    Console.WriteLine("Inner task finished");
                });
            }, TaskCreationOptions.AttachedToParent);
            outer.Wait(); //ожидаем выполнение внешней задачи
            Console.WriteLine("End of main");
        }
    }
}