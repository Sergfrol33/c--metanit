using System;
using System.Threading;

namespace Multithreading
{
    public class ThreadSemaphore
    {
        public void Start()
        {
            for (int i = 0; i < 5; i++)
            {
                Reader reader = new(i);
            }
        }

        private class Reader
        {
            //создаем семафор
            private static Semaphore _semaphore = new(3,3);
            private Thread myThread;
            private int _count = 3; //счётчик чтения

            public Reader(int i)
            {
                myThread = new Thread(Read){Name = $"Читатель {i}"};
                myThread.Start();
            }

            private void Read()
            {
                while (_count > 0)
                {
                    _semaphore.WaitOne();
                    
                    Console.WriteLine($"{Thread.CurrentThread.Name} входит в библиотеку");
                    
                    Console.WriteLine($"{Thread.CurrentThread.Name} читает");
                    Thread.Sleep(1000);
                    
                    Console.WriteLine($"{Thread.CurrentThread.Name} покидает библиотеку");

                    _semaphore.Release();

                    _count--;
                    Thread.Sleep(1000);
                }
            }
        }
    }
}