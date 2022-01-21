using System;
using System.Collections.Generic;
using System.Linq;
using MetaInit.common;

namespace LINQ
{
    public class Group
    {
        private static List<Phone> _phones = new()
        {
            new Phone {Name = "Lumia 430", Company = "Microsoft"},
            new Phone {Name = "Mi 5", Company = "Xiaomi"},
            new Phone {Name = "LG G 3", Company = "LG"},
            new Phone {Name = "iPhone 5", Company = "Apple"},
            new Phone {Name = "Lumia 930", Company = "Microsoft"},
            new Phone {Name = "iPhone 6", Company = "Apple"},
            new Phone {Name = "Lumia 630", Company = "Microsoft"},
            new Phone {Name = "LG G 4", Company = "LG"}
        };

        public static void GroupBy()
        {
            //1 вариант
            /*var phoneGroups = 
                from phone in _phones
                group phone by phone.Company;*/
            // 2 вариант
            var phoneGroups = _phones.GroupBy(p => p.Company);
            foreach (var g in phoneGroups)
            {
                Console.WriteLine(g.Key);
                foreach (var t in g)
                {
                    Console.WriteLine(t.Name);
                }
            }
        }

        public static void CreateNewGroup()
        {
            //1 вариант
            /*var phoneGroups =
                from phone in _phones
                group phone by phone.Company
                into g
                select new { Name = g.Key, Count = g.Count()};*/
            //2 вариант
            var phoneGroups = _phones
                .GroupBy(p => p.Company)
                .Select(g => new {Name = g.Key, Count = g.Count()});

            foreach (var gGroup in phoneGroups)
            {
                Console.WriteLine($"{gGroup.Name}: {gGroup.Count}");
            }
        }

        public static void InnerGroupBy()
        {
            //1 вариант
            /*var phoneGroups =
                from phone in _phones
                group phone by phone.Company
                into g
                select new
                {
                    Name = g.Key,
                    Count = g.Count(),
                    Phones = from phone in g select phone
                };*/
            //2 вариант 
            var phoneGroups =
                from phone in _phones
                group phone by phone.Company
                into g
                select new
                {
                    Name = g.Key,
                    Count = g.Count(),
                    Phones = g.Select(p => p)
                };
            foreach (var group in phoneGroups)
            {
                Console.WriteLine($"{group.Name}: {group.Count}");
                foreach (var phone in group.Phones)
                {
                    Console.WriteLine(phone.Name);
                }
            }
        }
    }
}