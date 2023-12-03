using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace aoc_2023.day2 {
    public class Day {
        public static List<Game> GetGames(IEnumerable<string> lines) {
            List<Game> games = new List<Game>();

            foreach (string line in lines) {
                Match match = Regex.Match(line, "Game (\\d+): (.+)");

                int gameNum = int.Parse(match.Groups[1].Value);
                string gameRounds = match.Groups[2].Value;
                string[] rounds = gameRounds.Split(';');

                Game game = new Game(gameNum);

                foreach (string round in rounds) {
                    Regex.Matches(round, @"(\d+) (red|green|blue)")
                        .OfType<Match>()
                        .ToList()
                        .ForEach(m => game.SetColorMax(m.Groups[2].Value, int.Parse(m.Groups[1].Value)));
                }

                games.Add(game);
            }

            return games;
        }
    }
    
    public class Game {
        public int Id { get; }
        public int Red { get; private set; } = 0;
        public int Green { get; private set; } = 0;
        public int Blue { get; private set; } = 0;

        public Game(int id) {
            Id = id;
        }

        public void SetColorMax(string color, int count) {
            switch (color) {
                case "red":
                    Red = Math.Max(Red, count);
                    break;
                case "green":
                    Green = Math.Max(Green, count);
                    break;
                case "blue":
                    Blue = Math.Max(Blue, count);
                    break;
            }
        }

        public override string ToString() {
            return $"Game {Id}: Red: {Red}, Green: {Green}, Blue:{Blue}";
        }
    }
}