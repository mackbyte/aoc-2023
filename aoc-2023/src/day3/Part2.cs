using System;
using System.Collections.Generic;
using System.Linq;
using aoc_2023.common.input;
using aoc_2023.common.output;
using aoc_2023.common.part;

namespace aoc_2023.day3 {
    public class Part2 : Part {
        public Part2(Input input) : base(input) { }
        public override string Run() {
            IEnumerable<string> lines = Input.GetInputLines();
            Grid grid = new Grid();

            lines.ToList().ForEach(line => { grid.AddLine(line); });
            
            int lineNum = 0;
            int total = 0;
            grid.Lines.ForEach(line => {
                int linePosition = 0;
                line.UniqueItems.ForEach(item => {
                    if (item.Type == GridItemType.Symbol) {
                        if (item.Value == "*") {
                            List<int> adjacentNumbers = grid.AdjacentNumbers(lineNum, linePosition);

                            if (adjacentNumbers.Count == 2) {
                                total += adjacentNumbers[0] * adjacentNumbers[1];
                                Output.WriteInColor(item.Value, ConsoleColor.Green);
                            } else {
                                Output.WriteInColor(item.Value, ConsoleColor.Red);
                            }
                        } else {
                            Output.WriteInColor(item.Value, ConsoleColor.Red);
                        }

                        linePosition++;
                    } else if(item.Type == GridItemType.Number) {
                        Output.WriteInColor(item.Value, ConsoleColor.Yellow);
                        linePosition += item.Value.Length;
                    } else {
                        Console.Write(item.Value);
                        linePosition++;
                    }
                });
                Console.WriteLine();
                lineNum++;
            });

            return total.ToString();
        }
    }
}