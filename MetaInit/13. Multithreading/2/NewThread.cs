using System;
using System.Threading;

//Используя класс Thread, мы можем выделить в приложении несколько потоков, которые будут выполняться одновременно.
namespace Multithreading
{
    class NewThread
    {
        public void Start()
        {
            // создаем новый поток
            Thread myThread = new(Count);
            myThread.Start(); // запускаем поток
            for (var i = 0; i < 9; i++)
            {
                Console.WriteLine("Главный поток:");
                Console.WriteLine(i * i);
                Thread.Sleep(300);
            }
            
        }

        private static void Count()
        {
            for (var i = 0; i < 9; i++)
            {
                Console.WriteLine("Второй поток:");
                Console.WriteLine(i * i);
                Thread.Sleep(400);
            }
        }
    }

}