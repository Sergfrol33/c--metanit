using System;
using System.Threading;

namespace Multithreading
{
    
    public class SynchronizationThreadsMontiors
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
       
            var isAcquiredLock = false;
            try
            {
                Monitor.Enter(locker, ref isAcquiredLock);
                _x = 1;
                for (int i = 0; i < 9; i++)
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name}: {_x}");
                    _x++;
                    Thread.Sleep(100);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                if (isAcquiredLock) Monitor.Exit(locker);
            }
        }
    }
}