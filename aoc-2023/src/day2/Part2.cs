using System.Collections.Generic;
using System.Linq;
using aoc_2023.common.input;
using aoc_2023.common.part;

namespace aoc_2023.day2 {
    public class Part2 : Part {
        public Part2(Input input) : base(input) { }
        public override string Run() {
            IEnumerable<string> lines = Input.GetInputLines();
            List<Game> games = Day.GetGames(lines);

            return games.Select(game => game.Red * game.Green * game.Blue)
                .Sum()
                .ToString();
        }
    }
}