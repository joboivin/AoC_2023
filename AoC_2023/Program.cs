using AoC_2023.Common;
using AoC_2023.Day3;

namespace AoC_2023;

class Program
{
    static async Task Main(string[] args)
    {
        //var solver = new Day1Solver(new RawInputProvider(@"Day1/Input.txt"), new CalibrationProvider(), new CalibrationFixer());
        //var solver = new Day2Solver(new RawInputProvider("Day2/Input.txt"), new GameProvider());
        var solver = new Day3Solver(new InputProvider(new RawInputProvider("Day3/Input.txt")), new PartNumbersExtractor(), new GearRatioCalculator());

        await RunAsync(solver);
    }

    async static Task RunAsync(IDaySolver solver)
    {
        Console.WriteLine($"Solution is: {await solver.SolveAsync()}");
        Console.WriteLine($"Bonus solution is: {await solver.SolveBonusAsync()}");
    }
}
