using System;
using System.Collections.Generic;
using System.Linq;
using aoc_2023.common.input;
using aoc_2023.common.part;

namespace aoc_2023.day4 {
    public class Part2 : Part {
        public Part2(Input input) : base(input) { }

        public override string Run() {
            IEnumerable<string> lines = Input.GetInputLines();
            List<Card> cards = lines.Select(line => new Card(line)).ToList();

            Dictionary<int, int> copies = new Dictionary<int, int>();
            for (int i = 0; i < cards.Count; i++) {
                copies.Add(i, 1);
            }

            for (int i = 0; i < cards.Count; i++) {
                int matchingNumbers = cards[i].MatchingNumbers();
                for (int j = i + 1; j < i + 1 + matchingNumbers; j++) {
                    copies[j] += 1 * copies[i];
                }
            }

            foreach (int cardNum in copies.Keys) {
                Console.WriteLine($"{copies[cardNum]} instances of card {cardNum+1}");
            }

            return copies.Values.Sum().ToString();
        }
    }
}