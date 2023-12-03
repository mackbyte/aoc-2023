using aoc_2023.common.input;

namespace aoc_2023.common.part {
    public abstract class Part {
        protected readonly Input Input;

        protected Part(Input input) {
            Input = input;
        }
        
        public abstract string Run();
    }
}