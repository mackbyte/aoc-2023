using System;
using aoc_2023.common.part;

namespace aoc_2023 {
    internal static class Program {
        public static void Main(string[] args) {
            if (!args.Length.Equals(2)) {
                Console.WriteLine("Please specify day and part numbers");
                Environment.Exit(1);
            }

            int dayNum = int.Parse(args[0]);
            int partNum = int.Parse(args[1]);

            Part part = PartFactory.Create(dayNum, partNum);
            string result = part.Run();
            Console.WriteLine(result);
        }
    }
}