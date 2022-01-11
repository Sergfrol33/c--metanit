using System;
using System.Threading;

namespace Multithreading
{
    public class ThreadTimer
    {
        public void Start()
        {
            const int num = 0; 
            // создаем таймер
            Timer timer = new(Count, num, 0, 2000);
            Console.ReadLine();
        }

        private void Count(object? obj)
        {
            var x = (int?)obj;
            for (var i = 1; i < 9; i++, x++)
            {
                Console.WriteLine($"{x * i}");      
            }
        }
    }
}