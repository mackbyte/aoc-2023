using System;
using aoc_2023.common.input;

namespace aoc_2023.common.part {
    public static class PartFactory {
        public static Part Create(int day, int part) {
            Input input = new Input(day);
            Type t = Type.GetType($"aoc_2023.day{day}.Part{part}"); 
            return (Part)Activator.CreateInstance(t, input);
        }
    }
}