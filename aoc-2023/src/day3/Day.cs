using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace aoc_2023.day3 {
    public class Grid {
        public List<GridLine> Lines { get; } = new List<GridLine>();

        public void AddLine(string line) {
            GridLine gridLine = new GridLine();

            Regex.Matches(line, @"(\.)|(\d+)|(.)")
                .OfType<Match>()
                .ToList()
                .ForEach(match => {
                    GridItem gridItem = GridItem.ToGridItem(match.Groups[0].Value);
                    gridLine.AddGridItem(gridItem);
                });

            Lines.Add(gridLine);
        }

        public bool HasAdjacentSymbol(int lineNum, int linePosition) {
            for (int i = Math.Max(lineNum - 1, 0); i <= Math.Min(lineNum + 1, Lines.Count - 1); i++) {
                for (int j = Math.Max(linePosition - 1, 0); j <= Math.Min(linePosition + 1, Lines[lineNum].Positions.Count - 1); j++) {
                    if (i == lineNum && j == linePosition) {
                        continue;
                    }

                    if (Lines[i].Positions[j].Type == GridItemType.Symbol) {
                        return true;
                    }
                }
            }

            return false;
        }

        public List<int> AdjacentNumbers(int lineNum, int linePosition) {
            HashSet<int> adjacentNumbers = new HashSet<int>();
            
            for (int i = Math.Max(lineNum - 1, 0); i <= Math.Min(lineNum + 1, Lines.Count - 1); i++) {
                for (int j = Math.Max(linePosition - 1, 0); j <= Math.Min(linePosition + 1, Lines[lineNum].Positions.Count - 1); j++) {
                    if (i == lineNum && j == linePosition) {
                        continue;
                    }

                    GridItem gridItem = Lines[i].Positions[j];
                    if (gridItem.Type == GridItemType.Number) {
                        adjacentNumbers.Add(int.Parse(gridItem.Value));
                    }
                }
            }

            return adjacentNumbers.ToList();
        }
    }

    public class GridLine {
        public List<GridItem> UniqueItems { get; }  = new List<GridItem>();
        public List<GridItem> Positions { get; } = new List<GridItem>();
        public void AddGridItem(GridItem gridItem) {
            UniqueItems.Add(gridItem);
            
            if (gridItem.Type == GridItemType.Number) {
                gridItem.Value.ToList().ForEach(_ => { Positions.Add(gridItem); });
            } else {
                Positions.Add(gridItem);
            }
        }
    }

    public class GridItem {
        public GridItemType Type { get; }
        public string Value { get; }

        public static GridItem ToGridItem(string type) {
            if (type.Equals(".")) {
                return new GridItem(GridItemType.Empty, ".");
            }

            if (int.TryParse(type, out int _)) {
                return new GridItem(GridItemType.Number, type);
            }

            return new GridItem(GridItemType.Symbol, type);
        }

        private GridItem(GridItemType type, string value) {
            Type = type;
            Value = value;
        }
    }

    public enum GridItemType {
        Empty = '.',
        Symbol = '*',
        Number = 'n'
    }
}