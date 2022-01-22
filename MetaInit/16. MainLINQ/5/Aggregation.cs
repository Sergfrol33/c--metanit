using MetaInit.common;

namespace LINQ
{
    public class Aggregation
    {
        private static readonly int[] _numbers = {1,2,3,4,77,65,123,22 };

        public static void Aggregate()
        {
            var deduction = _numbers.Aggregate((x,y) => x -y);
            Console.WriteLine($"вычитание - {deduction}");
            
            var sum = _numbers.Aggregate((x,y) => x + y);
            Console.WriteLine($"сложение - {sum}");
        }

        public static void GetCount()
        {
            var size = _numbers.Count((i) => i % 2 == 0 && i > 10);
            Console.WriteLine(size);
        }

        public static void GetSum()
        {
            List<User> users = new()
            {
                new User { Name = "Tom", Age = 23 },
                new User { Name = "Sam", Age = 43 },
                new User { Name = "Bill", Age = 35 }
            };
            var sum1 = _numbers.Sum();
            var sum2 = users.Sum(u => u.Age);
            Console.WriteLine($"numbers - {sum1}\nusers age - {sum2}");
        }

        public static void GetMinMaxAverageValue()
        {
            List<User> users = new()
            {
                new User { Name = "Tom", Age = 23 },
                new User { Name = "Sam", Age = 43 },
                new User { Name = "Bill", Age = 35 }
            };
            var min1 = _numbers.Min();
            var min2 = users.Min(n => n.Age); //минимальный возраст
            Console.WriteLine($" min:\n numbers - {min1}\n users age - {min2}");

            var max1 = _numbers.Max();
            var max2 = users.Max(n => n.Age); //максимальный возраст
            Console.WriteLine($" max:\n numbers - {max1}\n users age - {max2}");

            var avr1 = _numbers.Average();
            var avr2 = users.Average(n => n.Age); // средний возраст
            Console.WriteLine($" avr:\n numbers - {avr1}\n users age - {avr2}");
        }
    }

   
}