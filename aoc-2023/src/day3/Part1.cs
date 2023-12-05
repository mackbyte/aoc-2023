using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using aoc_2023.common.input;
using aoc_2023.common.output;
using aoc_2023.common.part;

namespace aoc_2023.day3 {
    public class Part1 : Part {
        public Part1(Input input) : base(input) { }

        public override string Run() {
            IEnumerable<string> lines = Input.GetInputLines();
            Grid grid = new Grid();

            lines.ToList().ForEach(line => { grid.AddLine(line); });
            
            int lineNum = 0;
            int total = 0;
            grid.Lines.ForEach(line => {
                int linePosition = 0;
                line.UniqueItems.ForEach(item => {
                    if (item.Type == GridItemType.Number) {
                        bool hasAdjacentSymbol = false;
                        for (int digitPosition = linePosition; digitPosition <= linePosition + item.Value.Length - 1; digitPosition++) {
                            if (grid.HasAdjacentSymbol(lineNum, digitPosition)) {
                                hasAdjacentSymbol = true;
                                break;
                            }
                        }

                        if (hasAdjacentSymbol) {
                            int itemNum = int.Parse(item.Value);
                            total += itemNum;
                            Output.WriteInColor(item.Value, ConsoleColor.Green);
                        } else {
                            Output.WriteInColor(item.Value, ConsoleColor.Red);
                        }

                        linePosition += item.Value.Length;
                    } else if(item.Type == GridItemType.Symbol) {
                        Output.WriteInColor(item.Value, ConsoleColor.Yellow);
                        linePosition++;
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