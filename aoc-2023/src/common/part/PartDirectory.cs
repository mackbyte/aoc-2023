using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace aoc_2023.common.part {
    public static class PartDirectory {
        private static readonly Dictionary<int, Day> Directory = new Dictionary<int, Day>();

        private static void AddPart(string partPath) {
            string[] dayAndPart = partPath.Split('.');
            int dayNum = int.Parse(dayAndPart[0].Remove(0, 3)); // Remove day prefix
            int partNum = int.Parse(dayAndPart[1].Remove(0, 4)); // Remove part prefix

            Day day;
            if (Directory.TryGetValue(dayNum, out day)) {
                day.SetPart(partNum);
            } else {
                day = new Day(dayNum);
                day.SetPart(partNum);
                Directory[dayNum] = day;
            }
        }
        
        public static void LoadParts() {
            Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.IsClass && !t.Namespace.EndsWith("part") && typeof(Part).IsAssignableFrom(t))
                .Select(t => t.FullName.Remove(0, 9)) // remove aoc_2023. prefix of the namespace
                .ToList()
                .ForEach(AddPart);
        }

        public static List<int> GetDayNums() {
            return Directory.Keys.OrderBy(i => i).ToList();
        }

        public static List<int> GetPartNums(int dayNum) {
            return Directory[dayNum].GetPartList();
        }
    }

    public class Day {
        public int Num { get; }
        private readonly bool[] parts = { false, false };

        public Day(int num) {
            Num = num;
        }

        public void SetPart(int num) {
            parts[num-1] = true;
        }

        public List<int> GetPartList() {
            return parts.Where(isPart => isPart).Select((_, index) => index+1).ToList();
        }
    }
}