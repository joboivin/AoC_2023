using AoC_2023.Day1;

namespace AoC_2023;

class Program
{
    static async Task Main(string[] args)
    {
        IDaySolver solver = new Day1Solver();
        await RunAsync(solver);
    }

    async static Task RunAsync(IDaySolver solver)
    {
        Console.WriteLine($"Solution is: {await solver.SolveAsync()}");
        Console.WriteLine($"Bonus solution is: {await solver.SolveBonusAsync()}");
    }
}
