using AoC_2023.Common;
using AoC_2023;

namespace AoC_2023.Day3;

internal class Day3Solver(IInputProvider inputProvider, IPartNumbersExtractor partNumbersExtractor, IGearRatioCalculator gearRatioCalculator) : IDaySolver
{
    private readonly IInputProvider _inputProvider = inputProvider;
    private readonly IPartNumbersExtractor _partNumbersExtractor = partNumbersExtractor;
    private readonly IGearRatioCalculator _gearRatioCalculator = gearRatioCalculator;

    public async Task<int> SolveAsync()
    {
        var input = await _inputProvider.ProvideInputAsync();

        return _partNumbersExtractor.ExtractPartNumbers(input, false).Select(x => x.Number).Sum();
    }

    public async Task<int> SolveBonusAsync()
    {
        var input = await _inputProvider.ProvideInputAsync();

        var parts = _partNumbersExtractor.ExtractPartNumbers(input, true);

        return _gearRatioCalculator.CalculateGearRatio(parts);
    }
}