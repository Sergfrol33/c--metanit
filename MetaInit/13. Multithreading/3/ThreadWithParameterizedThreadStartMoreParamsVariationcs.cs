using System;
using System.Threading;


namespace Multithreading
{
    class ThreadWithParameterizedThreadStartMoreParamsVariation
    {
        public void Start()
        {
            Counter counter = new(5, 4);
            Thread thread = new(counter.Count);
            thread.Start();
            for (var i = 1; i < 9; i++)
            {
               
                Console.WriteLine("Главный поток:");
                Console.WriteLine(i * i);
                Thread.Sleep(300);
            }
        }
        private class Counter
        {
            private readonly int _x;
            private readonly int _y;

            public Counter(int x, int y)
            {
                _x = x;
                _y = y;
            }

            public void Count()
            {
                for (var i = 1; i < 9; i++)
                {
                    Console.WriteLine("Второй поток:");
                    Console.WriteLine(i * _x * _y);
                    Thread.Sleep(400);
                }
            }
        }
    }
}