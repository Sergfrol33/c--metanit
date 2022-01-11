using System;
using System.Threading;


namespace Multithreading
{
    class ThreadWithParameterizedThreadStartMoreParams
    {
        public void Start()
        {
            Counter counter = new()
            {
                X = 4,
                Y = 5
            };
            Thread thread = new(Count);
            thread.Start(counter);
            for (var i = 1; i < 9; i++)
            {
               
                Console.WriteLine("Главный поток:");
                Console.WriteLine(i * i);
                Thread.Sleep(300);
            }
        }

        private void Count(object? obj)
        {
            var c = obj as Counter;
            for (var i = 1; i < 9; i++)
            {
                Console.WriteLine("Второй поток:");
                Console.WriteLine(i * c?.X * c?.Y);
                Thread.Sleep(400);
            }
        }

        private class Counter
        {
            public int X;
            public int Y;
        }
    }
}