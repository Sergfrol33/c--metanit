using System;
using System.Linq;

namespace LINQ
{
    public class Deletegates
    {
        private static int[] _numbers = {1, 2, 3, 4, 10, 34, 55, 66, 77, 88};

        private static Func<int, bool> MoreThanTen = delegate(int i) { return i > 10; };

        public static void Delegate()
        {
            var result = _numbers.Where(MoreThanTen);
            foreach (var i in result)
            {
                Console.WriteLine(i);
            }
        }
    }
}