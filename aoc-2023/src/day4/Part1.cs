using System.Collections.Generic;
using System.Linq;
using aoc_2023.common.input;
using aoc_2023.common.part;

namespace aoc_2023.day4 {
    public class Part1 : Part {
        public Part1(Input input) : base(input) { }

        public override string Run() {
            IEnumerable<string> lines = Input.GetInputLines();

            List<Card> cards = lines.Select(line => new Card(line)).ToList();
            cards.ForEach(card => card.PrintCard());

            return cards.Select(card => card.GetScore())
                .Sum()
                .ToString();
        }
    }
}