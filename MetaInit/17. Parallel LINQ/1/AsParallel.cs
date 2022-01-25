using MetaInit.common;

namespace ParallelLinq
{
    public class AsParallel
    {
        private static int[] _numbers = {1, 2, 3, 4, 5, 6};

        public static void DoParallel()
        {
            //1 вариант
            /*var factorials = 
                from number in _numbers.AsParallel()
                select Calculation.Factorial(number);*/
            //2 вариант 
            var factorials = _numbers.AsParallel().Select(Calculation.Factorial);

            foreach (var n in factorials)
            {
                Console.WriteLine(n);
            }
        }

        public static void DoForAll()
        {
            (
                from number in _numbers.AsParallel()
                where number > 0
                select Calculation.Factorial(number)
            ).ForAll(Console.WriteLine);
        }

        public static void AsOrdered()
        {
            var factorials = 
                from n in _numbers.AsParallel().AsOrdered()
                where n >0
                select Calculation.Factorial(n);
            foreach (var n in factorials)
            {
                Console.WriteLine(n);
            }
        }
    }
}