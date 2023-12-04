using System;
using System.Collections.Generic;
using aoc_2023.common.part;

namespace aoc_2023 {
    internal static class Program {
        public static void Main(string[] args) {
            PartDirectory.LoadParts();

            List<int> dayList = PartDirectory.GetDayNums();
            Console.WriteLine("Please choose from the available days:");
            dayList.ForEach(dayNum => Console.WriteLine($"[{dayNum}]: Day {dayNum}"));
            int dayChoice = int.Parse(Console.ReadLine());

            List<int> partList = PartDirectory.GetPartNums(dayChoice);
            Console.WriteLine("\nPlease choose from the available parts:");
            partList.ForEach(partNum => Console.WriteLine($"[{partNum}]: Part {partNum}"));
            int partChoice = int.Parse(Console.ReadLine());
            
            Console.WriteLine($"\nRunning Day {dayChoice} Part {partChoice}");
            Part part = PartFactory.Create(dayChoice, partChoice);
            string result = part.Run();
            Console.WriteLine($"Result: {result}");
        }
    }
}