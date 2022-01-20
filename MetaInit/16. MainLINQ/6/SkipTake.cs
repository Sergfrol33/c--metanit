using System;
using System.Linq;

namespace LINQ
{
    public class SkipTake
    {
        private static int[] _numbers = {-3,-2,-1,1,0,2,3};
        private static string[] _teams =
        {
            "Бавария", "Боруссия", "Реал Мадрид", 
            "Манчестер Сити", "ПСЖ", "Барселона"
        };
        public static void Take()
        {
            var result = _numbers.Take(3);
            foreach (var i in result)
            {
                Console.WriteLine(i);
            }
        }

        public static void Skip()
        {
            var result = _numbers.Skip(3);
            foreach (var i in result)
            {
                Console.WriteLine(i);
            }
        }

        public static void SkipAndTake()
        {
            var result = _numbers.Skip(4).Take(3);
            foreach (var i in result)
            {
                Console.WriteLine(i);
            }
        }

        public static void TakeWhile()
        {
            foreach (var t in _teams.TakeWhile(x => x.StartsWith("Б")))
            {
                Console.WriteLine(t);
            }
        }
        public static void SkipWhile()
        {
            foreach (var t in _teams.SkipWhile(x => x.StartsWith("Б")))
            {
                Console.WriteLine(t);
            }
        }
    }
}