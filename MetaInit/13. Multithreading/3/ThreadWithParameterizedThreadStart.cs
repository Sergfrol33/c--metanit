using System;
using System.Threading;


namespace Multithreading
{
    class ThreadWithParameterizedThreadStart
    {
        public void Start()
        {
            var number = 4;
            // создаем новый поток
            Thread thread = new(Count);
            thread.Start(number);
            for (var i = 1; i < 9; i++)
            {
               
                Console.WriteLine("Главный поток:");
                Console.WriteLine(i * i);
                Thread.Sleep(300);
            }
        }

        private void Count(object? x)
        {
            for (var i = 1; i < 9; i++)
            {
                var n = (int?) x;
                Console.WriteLine("Второй поток:");
                Console.WriteLine(i * n);
                Thread.Sleep(400);
            }
        }
    }
}