using System;
using System.Threading;

namespace Multithreading
{
    //Нередко в потоках используются некоторые разделяемые ресурсы, общие для всей программы. Это могут быть общие переменные, файлы, другие ресурсы.
    public class SynchronizationOfThreads
    {
        private static int _x = 0;
        private static object locker = new object();
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
            _x = 1;
            
            lock(locker)
            {
                for (int i = 0; i < 9; i++)
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name}: {_x}");
                    _x++;
                    Thread.Sleep(100);
                }
            }
        }
    }
}