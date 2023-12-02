using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace aoc_2023.common.input {
    public class Input {
        private readonly int day;

        public Input(int day) {
            this.day = day;
        }
        
        public IEnumerable<string> GetInputLines() {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), $@"src\day{day}\input.txt");
            return File.ReadAllLines(path);
        }
    }
}