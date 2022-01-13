using System;
using System.Threading.Tasks;

namespace ParallelProgramming
{
    class WaitingTask
    {
        public void Start()
        {
            Task task = new Task(Display);
            task.Start();
            task.Wait();
            Console.WriteLine("Завершение метода main");
        }

        private void Display()
        {
            Console.WriteLine("Начало работы метода Display");
            Console.WriteLine("Завершение работы метода Display");
        }
    }
}