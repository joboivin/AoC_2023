using System.Text.RegularExpressions;
using AoC_2023.Common;

namespace AoC_2023.Day6;

internal class RaceProvider(IRawInputProvider rawInputProvider) : IRaceProvider
{
    private readonly IRawInputProvider _rawInputProvider = rawInputProvider;

    public async IAsyncEnumerable<Race> ProvideRacesAsync()
    {
        var input = await _rawInputProvider.ProvideRawInputAsync().ToListAsync();

        var allTimes = ProvideInfo(input[0]).ToList();
        var allDistances = ProvideInfo(input[1]).ToList();

        for(var i = 0; i < allTimes.Count; i++)
            yield return new Race { 
                Time = long.Parse(allTimes[i]),
                Distance = long.Parse(allDistances[i])
            };
    }

    public async Task<Race> ProvideSingleRaceAsync()
    {
        var input = await _rawInputProvider.ProvideRawInputAsync().ToListAsync();

        var singleTime = ProvideActualInfo(input[0]);
        var singleDistance = ProvideActualInfo(input[1]);

        return new Race {
            Time = long.Parse(singleTime),
            Distance = long.Parse(singleDistance)
        };
    }

    private static IEnumerable<string> ProvideInfo(string input)
    {
        const int lineDescriptionLength = 11;

        var inputWithoutDescription = input[lineDescriptionLength..];

        return inputWithoutDescription.Split(' ').Where(x => !string.IsNullOrWhiteSpace(x));
    }

    private static string ProvideActualInfo(string input)
    {
        const int lineDescriptionLength = 11;

        var inputWithoutDescription = input[lineDescriptionLength..];

        return inputWithoutDescription.Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)).Aggregate(string.Empty, (x, y) => $"{x}{y}");
    }
}