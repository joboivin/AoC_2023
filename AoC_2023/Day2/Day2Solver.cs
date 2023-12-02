
using AoC_2023.Common;

namespace AoC_2023.Day2;

internal class Day2Solver(IRawInputProvider rawInputProvider, IGameProvider gameProvider) : IDaySolver
{
    private readonly IRawInputProvider _rawInputProvider = rawInputProvider;
    private readonly IGameProvider _gameProvider = gameProvider;

    public async Task<int> SolveAsync()
    {
        var validGamesSum = 0;

        await foreach(var line in _rawInputProvider.ProvideRawInputAsync())
        {
            var game = _gameProvider.ProvideGame(line);

            if(IsValid(game))
                validGamesSum += game.Id;
        }

        return validGamesSum;
    }

    public async Task<int> SolveBonusAsync()
    {
        var sumOfPowers = 0;

        await foreach(var line in _rawInputProvider.ProvideRawInputAsync())
        {
            var game = _gameProvider.ProvideGame(line);

            sumOfPowers += PowerOfMinimumCubes(game);
        }

        return sumOfPowers;
    }

    private static bool IsValid(Game game)
    {
        const int maxBlue = 14;
        const int maxGreen = 13;
        const int maxRed = 12;

        foreach(var set in game.Sets)
        {
            if(set[Color.Blue] > maxBlue)
                return false;
            
            if(set[Color.Green] > maxGreen)
                return false;

            if(set[Color.Red] > maxRed)
                return false;
        }

        return true;
    }

    private static int PowerOfMinimumCubes(Game game)
    {
        var minBlue = 0;
        var minGreen = 0;
        var minRed = 0;

        foreach(var set in game.Sets)
        {
            if(set[Color.Blue] > minBlue)
                minBlue = set[Color.Blue];
            
            if(set[Color.Green] > minGreen)
                minGreen = set[Color.Green];

            if(set[Color.Red] > minRed)
                minRed = set[Color.Red];
        }

        return minBlue * minGreen * minRed;
    }
}