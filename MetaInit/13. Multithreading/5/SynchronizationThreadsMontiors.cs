using System;
using System.Threading;

namespace Multithreading
{
    public class ThreadAutoResetEvent
    {
        private static int _x = 0;
        private static AutoResetEvent waitHandler = new AutoResetEvent(true);

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
            waitHandler.WaitOne();
            _x = 1;
            for (int i = 0; i < 9; i++)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name}: {_x}");
                _x++;
                Thread.Sleep(100);
            }

            waitHandler.Set();
        }
    }
}