using System.IO;

namespace Advent
{
    public abstract class AdventDay
    {
        public string Input => DebugInput ?? File.ReadAllText($"../../../Inputs/{_day}.txt");
        public string DebugInput { get; set; }
        private int _day { get; set; }

        public AdventDay(int day)
        {
            _day = day;
        }

        public string Solve()
        {
            return $@"PART ONE:
{SolvePartOne()}

PART TWO:
{SolvePartTwo()}";
        }

        protected abstract string SolvePartOne();

        protected abstract string SolvePartTwo();
    }
}