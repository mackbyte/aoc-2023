using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using aoc_2023.common.output;

namespace aoc_2023.day4 {
    public class Card {
        private readonly int number;
        private readonly List<int> winningNumbers;
        private readonly List<int> cardNumbers;

        public Card(string card) {
            List<Match> matches = Regex.Matches(card, @"Card\s+(\d+):\s+(.*) \| (.*)").OfType<Match>().ToList();
            number = int.Parse(matches[0].Groups[1].Value);

            winningNumbers = matches[0].Groups[2].Value.Split(' ')
                .Where(num => !string.IsNullOrEmpty(num))
                .Select(num => int.Parse(num))
                .ToList();

            cardNumbers = matches[0].Groups[3].Value.Split(' ')
                .Where(num => !string.IsNullOrEmpty(num))
                .Select(num => int.Parse(num))
                .ToList();
        }

        public int GetScore() {
            return (int)Math.Pow(2, MatchingNumbers() - 1);
        }

        public int MatchingNumbers() {
            return cardNumbers.Where(num => winningNumbers.Contains(num))
                .ToList()
                .Count;
        }

        public void PrintCard() {
            string winningNumbersText = string.Join(" ", winningNumbers
                .Select(num => num.ToString().PadLeft(2, ' '))
                .ToArray());
            Console.Write($"Card {number,3}: {winningNumbersText} | ");
            cardNumbers.ForEach(num => {
                if (winningNumbers.Contains(num)) {
                    Output.WriteInColor($"{num.ToString(),2} ", ConsoleColor.Green);
                } else {
                    Console.Write($"{num,2} ");
                }
            });
            Console.WriteLine($"=> {GetScore()}");
        }
    }
}