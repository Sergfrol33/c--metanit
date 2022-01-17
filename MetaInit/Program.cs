using System;
using System.Collections.Generic;
using System.Threading;
using Async;

namespace MetaInit
{
    class Program
    {
        static void Main(string[] args)
        {
            AsyncStreams.GetData();
            Console.Read();
        }
    }
}