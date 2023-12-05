
namespace AoC_2023.Day5;

internal class Day5Solver (IDestinationCalculator destinationCalculator, IAlmanacProvider almanacProvider): IDaySolver
{
    private readonly IDestinationCalculator _destinationCalculator = destinationCalculator;
    private readonly IAlmanacProvider _almanacProvider = almanacProvider;

    public async Task<long> SolveAsync()
    {
        var almanac = await _almanacProvider.ProvideAlmanacAsync();
        var seedsNumbers = new Dictionary<long, long>();

        foreach(var seed in almanac.Seeds)
            seedsNumbers.Add(seed, seed );
        
        foreach(var map in almanac.Maps)
        {
            foreach(var seed in almanac.Seeds)
            {
                seedsNumbers[seed] = _destinationCalculator.CalculateDestination(seedsNumbers[seed], map);
            }
        }

        return seedsNumbers.Values.Min();
    }

    public Task<long> SolveBonusAsync()
    {
        return Task.FromResult(0L);
    }
}