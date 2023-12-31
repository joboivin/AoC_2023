﻿using AoC_2023.Common;
using AoC_2023.Day9;

namespace AoC_2023;

class Program
{
    static async Task Main(string[] args)
    {
        //var solver = new Day1Solver(new RawInputProvider(@"Day1/Input.txt"), new CalibrationProvider(), new CalibrationFixer());
        //var solver = new Day2Solver(new RawInputProvider("Day2/Input.txt"), new GameProvider());
        //var solver = new Day3Solver(new InputProvider(new RawInputProvider("Day3/Input.txt")), new PartNumbersExtractor(), new GearRatioCalculator());
        //var solver = new Day4Solver(new RawInputProvider("Day4/Input.txt"), new CardProvider());
        //var solver = new Day5Solver(new DestinationCalculator(), new AlmanacProvider(new RawInputProvider("Day5/Input.txt")));
        //var solver = new Day6Solver(new RaceProvider(new RawInputProvider("Day6/Input.txt")), new WinningWaysCalculator());
        //var solver = new Day7Solver(new HandsProvider(new RawInputProvider("Day7/Input.txt")), new HandComparer(), new BonusHandComparer());
        //var solver = new Day8Solver(new NetworkProvider(new RawInputProvider("Day8/Input.txt")), new NetworkNavigator());
        var solver = new Day9Solver(new HistoriesProvider(new RawInputProvider("Day9/Input.txt")), new HistoryAnalyzer());

        await RunAsync(solver);
    }

    async static Task RunAsync(IDaySolver solver)
    {
        Console.WriteLine($"Solution is: {await solver.SolveAsync()}");
        Console.WriteLine($"Bonus solution is: {await solver.SolveBonusAsync()}");
    }
}
