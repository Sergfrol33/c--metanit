using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    public class MainLINQ
    {
        public static void Project()
        {
            List<User> users = new()
            {
                new User {Name = "SAm", Age = 25},
                new User {Name = "Tom", Age = 32},
            };
            var names = users.Select(u => u.Name);
            var items = users.Select(u => new
            {
                FirstName = u.Name,
                DateOfBirth = DateTime.Now.Year - u.Age
            });
            foreach (var n in names)
            {
                Console.WriteLine(n);
            }

            foreach (var item in items)
            {
                Console.WriteLine($"{item.FirstName} - {item.DateOfBirth}");
            }
        }

        public static void Project(bool stringType)
        {
            List<User> users = new()
            {
                new User {Name = "SAm", Age = 25},
                new User {Name = "Tom", Age = 32},
            };

            var names =
                from user in users
                select user.Name;
            var items = from u in users
                select new
                {
                    FirstName = u.Name,
                    DateOfBirth = DateTime.Now.Year - u.Age
                };
            foreach (var n in names)
            {
                Console.WriteLine(n);
            }

            foreach (var item in items)
            {
                Console.WriteLine($"{item.FirstName} - {item.DateOfBirth}");
            }
        }

        public static void WithOperatorLet()
        {
            List<User> users = new()
            {
                new User {Name = "SAm", Age = 25},
                new User {Name = "Tom", Age = 32},
            };
            var people =
                from user in users
                let name = $"Mr.{user.Name}"
                select new
                {
                    Name = name, user.Age
                };
            foreach (var item in people)
            {
                Console.WriteLine(item);
            }
        }

        public static void WorkWithMultipleSources()
        {
            List<User> users = new()
            {
                new User {Name = "SAm", Age = 25},
                new User {Name = "Tom", Age = 32},
            };
            List<Phone> phones = new()
            {
                new Phone {Name = "Lumia", Company = "microsoft"},
                new Phone {Name = "Iphone 6", Company = "apple"},
            };
            var people =
                from phone in phones
                from user in users
                select new {user.Name, Phone = phone.Name};
            foreach (var p in people)
            {
                Console.WriteLine($"{p.Name} - {p.Phone}");
            }
        }

        class Phone
        {
            public string Name { get; set; }
            public string Company { get; set; }
        }
    }
}