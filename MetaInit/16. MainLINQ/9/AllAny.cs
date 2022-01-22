using System;
using System.Collections.Generic;
using System.Linq;
using MetaInit.common;

namespace LINQ
{
    public class AllAny
    {
        private static List<User> _users = new()
        {
            new User {Name = "Tom", Age = 23},
            new User {Name = "Sam", Age = 43},
            new User {Name = "Bill", Age = 35}
        };

        public static void All()
        {
            var result1 = _users.All(u => u.Age > 28); //true
            Console.WriteLine(result1
                ? "У всех пользователей возраст больше 20"
                : "Есть пользователи с возрастом меньше 20");

            var result2 = _users.All(u => u.Name.StartsWith("Т"));
            Console.WriteLine(result2
                ? "У всех пользователей имя начинается с T"
                : "Не у всех пользователей имя начинается с T");
        }

        public static void Any()
        {
            var result1 = _users.Any(u => u.Age < 20); //false
            Console.WriteLine(result1
                ? "Есть пользователи с возрастом меньше 20"
                : "У всех пользователей возраст больше 20");

            var result2 = _users.Any(u => u.Name.StartsWith("Т"));//true
            Console.WriteLine(result2
                ? "Есть пользователи, у которых имя начинается с T"
                : "Отсутствуют пользователи, у которых имя начинается с T");
        }
    }
}