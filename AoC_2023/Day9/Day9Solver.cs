
namespace AoC_2023.Day9;

internal class Day9Solver(IHistoriesProvider historiesProvider, IHistoryAnalyzer historyAnalyzer) : IDaySolver
{
    private readonly IHistoriesProvider _historiesProvider = historiesProvider;
    private readonly IHistoryAnalyzer _historyAnalyser = historyAnalyzer;

    public Task<long> SolveAsync()
    {
        return _historiesProvider.ProvideHistoriesAsync().Select(x => _historyAnalyser.DetermineNextValue(x)).SumAsync().AsTask();
    }

    public Task<long> SolveBonusAsync()
    {
        return _historiesProvider.ProvideHistoriesAsync().Select(x => _historyAnalyser.DeterminePreviousValue(x)).SumAsync().AsTask();
    }
}