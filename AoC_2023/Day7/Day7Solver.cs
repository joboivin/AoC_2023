
namespace AoC_2023.Day7;

internal class Day7Solver(IHandsProvider handsProvider, IComparer<Hand> handsComparer, IComparer<Hand> bonusHandsComparer) : IDaySolver
{
    private readonly IHandsProvider _handsProvider = handsProvider;
    private readonly IComparer<Hand> _handsComparer = handsComparer;
    private readonly IComparer<Hand> _bonusHandsComparer = bonusHandsComparer;

    public Task<long> SolveAsync()
        => SolveAsync(_handsComparer);

    public Task<long> SolveBonusAsync()
        => SolveAsync(_bonusHandsComparer);

    private async Task<long> SolveAsync(IComparer<Hand> comparer)
    {
        var result = 0L;
        var orderedHands = await _handsProvider.ProvideHandsAsync().OrderBy(x => x, comparer).ToListAsync();

        for(var i = 0; i < orderedHands.Count; i++)
            result += (i + 1) * orderedHands[i].Bid;

        return result;
    }
}