
using System.Security.Cryptography.X509Certificates;

namespace AoC_2023.Day6;

internal class Day6Solver(IRaceProvider raceProvider, IWinningWaysCalculator winningWaysCalculator) : IDaySolver
{
    private readonly IRaceProvider _raceProvider = raceProvider;
    private readonly IWinningWaysCalculator _winningWaysCalculator = winningWaysCalculator;

    public Task<long> SolveAsync()
    {
        return _raceProvider.ProvideRacesAsync()
            .Select(x => _winningWaysCalculator.CalculateWinningWays(x))
            .AggregateAsync(1L, (x, y) => x * y).AsTask();
    }

    public async Task<long> SolveBonusAsync()
    {
        return _winningWaysCalculator.CalculateWinningWays(await _raceProvider.ProvideSingleRaceAsync());
    }
}