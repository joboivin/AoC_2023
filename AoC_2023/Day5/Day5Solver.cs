
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

    public async Task<long> SolveBonusAsync()
    {
        var almanac = await _almanacProvider.ProvideAlmanacAsync();
        var minimumCalculationTasks = new List<Task<long>>();

        for(var i = 0; i < almanac.Seeds.Count; i += 2)
        {
            var index = i;
            minimumCalculationTasks.Add(GetMinimumLocationForSeedAsync(almanac.Seeds[index], almanac.Seeds[index + 1], almanac.Maps));
        }

        await Task.WhenAll(minimumCalculationTasks);

        return minimumCalculationTasks.Min(x => x.Result);
    }

    private async Task<long> GetMinimumLocationForSeedAsync(long seedStart, long seedRange, IReadOnlyCollection<Map> maps)
    {
        const long maximumSeedsInTask = 100000000;

        var minimumCalculationTasks = new List<Task<long>>();
        var seedStartAdjusted = seedStart;
        var seedRangeAdjusted = seedRange;
        var stillSeedsToProcess = true;

        do
        {
            var seedStartCopy = seedStartAdjusted;
            var seedRangeCopy = seedRangeAdjusted;

            if(seedRangeAdjusted > maximumSeedsInTask)
            {
                minimumCalculationTasks.Add(Task.Run(() => GetMinimumLocationForSeed(seedStartCopy, maximumSeedsInTask, maps)));

                seedStartAdjusted += maximumSeedsInTask;
                seedRangeAdjusted -= maximumSeedsInTask;
            }
            else
            {
                minimumCalculationTasks.Add(Task.Run(() => GetMinimumLocationForSeed(seedStartCopy, seedRangeCopy, maps)));
                stillSeedsToProcess = false;
            }
        }
        while(stillSeedsToProcess);

        await Task.WhenAll(minimumCalculationTasks);

        return minimumCalculationTasks.Min(x => x.Result);
    }

    private long GetMinimumLocationForSeed(long seedStart, long seedRange, IReadOnlyCollection<Map> maps)
    {
        var minimumLocation = long.MaxValue;

        for(var i = 0L; i < seedRange; i++)
        {
            var number = seedStart + i;

            foreach(var map in maps)
                number = _destinationCalculator.CalculateDestination(number, map);
            
            if(number < minimumLocation)
                minimumLocation = number;
        }

        return minimumLocation;
    }
}