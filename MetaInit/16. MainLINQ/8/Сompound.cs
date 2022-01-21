using System;
using System.Collections.Generic;
using System.Linq;
using MetaInit.common;

namespace LINQ
{
    public class Сompound
    {
        private static List<Team> _teams = new()
        {
            new Team {Name = "Бавария", Country = "Германия"},
            new Team {Name = "Барселона", Country = "Испания"}
        };

        private static List<Player> _players = new List<Player>()
        {
            new Player {Name = "Месси", Team = "Барселона"},
            new Player {Name = "Неймар", Team = "Барселона"},
            new Player {Name = "Роббен", Team = "Бавария"}
        };

        public static void Join()
        {
            //1 вариаинт
            /*var result =
                from pl in _players
                join team in _teams on pl.Team equals team.Name
                select new {Name = pl.Name, Team = pl.Team, Country = team.Country};*/
            //2 вариант 
            var result = _players.Join(_teams, //второй набор 
                p => p.Team, //свойство-селектор объекта из первого набора
                t => t.Name, //свойство-селектор объекта из второго набор
                (p, t) => new {p.Name, p.Team, t.Country} //результат
            );
            foreach (var item in result)
            {
                Console.WriteLine($"{item.Name} - {item.Team} ({item.Country})");
            }
        }

        public static void GroupJoin()
        {
            var result = _teams.GroupJoin(
                _players, //второй набор
                t => t.Name, //свойство-селектор объекта из первого набора
                pl => pl.Team, //свойство-селектор объекта из второго набора
                (teams, pls) => new //результирующий объект
                {
                    teams.Name,
                    teams.Country,
                    Players = pls.Select(p => p.Name)
                }
            );
            foreach (var team in result)
            {
                Console.WriteLine(team.Name);
                foreach (var player in team.Players)
                {
                    Console.WriteLine(player);
                }
            }
        }

        public static void Zip()
        {
            var result = _players.Zip(
                _teams,
                (player, team) => new
                {
                    Name = player.Name,
                    Team = team.Name,
                    team.Country
                }
            );
            foreach (var player in result)
            {
                Console.WriteLine($"{player.Name} - {player.Team} ({player.Country})");
            }
        }
    }
}