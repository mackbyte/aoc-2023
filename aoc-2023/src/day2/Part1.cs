using System.Collections.Generic;
using System.Linq;
using aoc_2023.common.input;
using aoc_2023.common.part;

namespace aoc_2023.day2 {
    public class Part1 : Part {
        public Part1(Input input) : base(input) { }

        public override string Run() {
            IEnumerable<string> lines = Input.GetInputLines();
            List<Game> games = Day.GetGames(lines);

            const int redLimit = 12;
            const int greenLimit = 13;
            const int blueLimit = 14;

            return games.Where(game => game.Red <= redLimit && game.Green <= greenLimit && game.Blue <= blueLimit)
                .Select(game => game.Id)
                .Sum()
                .ToString();
        }
    }
}