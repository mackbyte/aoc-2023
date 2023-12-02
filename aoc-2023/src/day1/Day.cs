using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace aoc_2023.day1 {
    public static class Day {
        private static readonly Dictionary<string, int> Nums = new Dictionary<string, int> {
            { "one", 1 },
            { "two", 2 },
            { "three", 3 },
            { "four", 4 },
            { "five", 5 },
            { "six", 6 },
            { "seven", 7 },
            { "eight", 8 },
            { "nine", 9 }
        };
        
        private static int ParseNumber(string num) {
            return Nums.TryGetValue(num, out int number) ? number : int.Parse(num);
        }
        
        public static int[] ExtractNumbers(string line, string pattern) {
            return Regex.Matches(line, pattern)
                .OfType<Match>()
                .Select(m => ParseNumber(m.Groups[1].Value))
                .ToArray();
        }
    }
}