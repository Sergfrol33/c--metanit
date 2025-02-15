﻿using System;
using System.Threading;
using System.Threading.Tasks;
using MetaInit.common;

namespace Async
{
    public class CancellationAsync
    {
        void Factorial(int n, CancellationToken token)
        {
            int result = 1;
            for (int i = 1; i <= n; i++)
            {
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("Операция прервана токеном");
                    return;
                }

                result *= i;
                Console.WriteLine($"Факториал числа {i} равен {result}");
                Thread.Sleep(1000);
            }
        }

        public async void FactorialAsync(int n, CancellationToken token)
        {
            if (token.IsCancellationRequested) return;
            await Task.Run(() => Factorial(n, token), token);
        }
    }
}