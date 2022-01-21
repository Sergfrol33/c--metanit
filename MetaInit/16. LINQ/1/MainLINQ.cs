namespace LINQ
{
    public class MainLINQ
    {
        public static void Sort()
        {
            string[] teams =
            {
                "Бавария", "Боруссия", "Реал Мадрид", "Манчестер Сити", "ПСЖ", "Барселона"
            };
            var selectedTeams = from team in teams //определяем каждый объект из teams как team
                where team.ToUpper().StartsWith("Б") //фильтрация по критерию
                orderby team //упорядочиваем по возрастанию 
                select team;
            foreach (var team in selectedTeams)
            {
                Console.WriteLine(team);
            }
        }

        public static void SortAlterSyntax()
        {
            string[] teams =
            {
                "Бавария", "Боруссия", "Реал Мадрид", "Манчестер Сити", "ПСЖ", "Барселона"
            };
            var selectedTeams = teams
                .Where(s => s.ToUpper().StartsWith("Б"))
                .OrderBy(t => t);
            foreach (var t in selectedTeams)
            {
                Console.WriteLine(t);
            }
        }

        public static void Filter()
        {
            int[] numbers = {1, 2, 3, 4, 5, 6, 7, 8, 9, 12, 23, 65, 123};
            /*var evens = 
                from number in numbers 
                where number % 2 == 0 && number > 10 
                select number;*/
            var evens = numbers.Where(n => n % 2 == 0 && n > 10);
            foreach (var even in evens)
            {
                Console.WriteLine(even);
            }
        }

        public static void FilterUsers()
        {
            List<User> users = new()
            {
                new User {Name = "Том", Age = 25, Languages = new List<string> {"английский", "немецкий"}},
                new User {Name = "Боб", Age = 27, Languages = new List<string> {"английский", "французский"}},
                new User {Name = "Джон", Age = 29, Languages = new List<string> {"английский", "испанский"}},
                new User {Name = "Элис", Age = 24, Languages = new List<string> {"испанский", "немецкий"}}
            };
            var selectedUsers = users.Where(user => user.Age > 25);
            foreach (var user in selectedUsers)
            {
                Console.WriteLine($"{user.Name} - {user.Age}");
            }
        }

        public static void ComplexFilter()
        {
            List<User> users = new()
            {
                new User {Name = "Том", Age = 25, Languages = new List<string> {"английский", "немецкий"}},
                new User {Name = "Боб", Age = 27, Languages = new List<string> {"английский", "французский"}},
                new User {Name = "Джон", Age = 29, Languages = new List<string> {"английский", "испанский"}},
                new User {Name = "Элис", Age = 24, Languages = new List<string> {"испанский", "немецкий"}}
            };
            /*var selectedUsers =
                from user in users
                from language in user.Languages
                where user.Age < 28
                where language == "английский"
                select user;*/
            var selectedUsers = users.SelectMany(
                    u => u.Languages, 
                    (user, s) => new {User = user, Lang = s}
                    )
                .Where(u => u.Lang == "английский" && u.User.Age < 28)
                .Select(u => u.User);
            foreach (var user in selectedUsers)
            {
                Console.WriteLine($"{user.Name} - {user.Age}");
            }
        }

        class User
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public List<string> Languages { get; set; }

            public User()
            {
                Languages = new List<string>();
            }
        }
    }
}