using System;

namespace aoc_2023.common.output {
    public class Output {
        public static void WriteInColor(string text, ConsoleColor color) {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }
    }
}