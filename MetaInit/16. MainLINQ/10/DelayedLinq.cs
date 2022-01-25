using System;
using System.Linq;

namespace LINQ
{
    public class DelayedLinq
    {
        private static string[] _teams =
            {"Бавария", "Боруссия", "Реал Мадрид", "Манчестер Сити", "ПСЖ", "Барселона"};

        public static void Delayed()
        {
            var selectedTeams =
                from team in _teams
                where team.ToUpper().StartsWith("Б")
                orderby team
                select team;
            foreach (var team in selectedTeams)
            {
                Console.WriteLine(team);
            }
        }

        public static void Immediate()
        {
            var i = (
                from team in _teams
                where team.ToUpper().StartsWith("Б")
                orderby team
                select team
            ).Count();
            Console.WriteLine(i);//3
            _teams[1] = "Ювентус";
            Console.WriteLine(i);//3
        }
    }
}