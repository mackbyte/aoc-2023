using System.Collections.Generic;
using System.Linq;
using aoc_2023.common.input;
using aoc_2023.common.part;

namespace aoc_2023.day1 {
    public class Part2 : Part {
        public Part2(Input input) : base(input) {}

        public override string Run() {
            IEnumerable<string> lines = Input.GetInputLines();
            int total = lines.Select(line => Day.ExtractNumbers(line, "(?=([0-9]|one|two|three|four|five|six|seven|eight|nine))"))
                .Select(numbers => int.Parse($"{numbers[0]}{numbers[numbers.Length - 1]}"))
                .Sum();
            return total.ToString();
        }
    }
}