using aoc_2023.common.input;

namespace aoc_2023.common.part {
    public abstract class Part {
        protected readonly Input input;

        protected Part(Input input) {
            this.input = input;
        }
        
        public abstract string Run();
    }
}