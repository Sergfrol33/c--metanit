using System;
using System.Threading;

namespace Multithreading
{
    public class ThreadMutex
    {
        private static int _x = 0;
        private static readonly Mutex _mutex = new Mutex();

        public void Start()
        {
            for (int i = 0; i < 5; i++)
            {
                Thread thread = new(Count)
                {
                    Name = $"Поток {i}"
                };
                thread.Start();
            }
        }

        private void Count()
        {
            _mutex.WaitOne();
            _x = 1;
            for (int i = 0; i < 9; i++)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name}: {_x}");
                _x++;
                Thread.Sleep(100);
            }

            _mutex.ReleaseMutex();
        }
    }
}