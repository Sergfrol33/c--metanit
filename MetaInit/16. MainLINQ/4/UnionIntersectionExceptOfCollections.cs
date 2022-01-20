using System;
using System.Linq;

namespace LINQ
{
    public class UnionIntersectionExceptOfCollections
    {
        private static readonly string[] Soft = { "Microsoft", "Google", "Apple"};
        private static readonly string[] Hard = { "Apple", "IBM", "Samsung" };
        public static void SeeExcept()
        {
            //разность последовательностей
            var result = Soft.Except(Hard);
            foreach (var s in result)
            {
                Console.WriteLine(s);
            }
        }

        public static void SeeIntersect()
        {
            //пересечение последовательностей
            var result = Soft.Intersect(Hard);
            foreach (var s in result)
            {
                Console.WriteLine(s);
            }
        }

        public static void SeeUnion()
        {
            var result = Soft.Union(Hard);
            foreach (var s in result)
            {
                Console.WriteLine(s);
            }
        }
    }
}