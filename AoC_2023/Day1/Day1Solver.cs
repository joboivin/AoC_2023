using AoC_2023;
using AoC_2023.Common;

namespace AoC_2023.Day1;

internal class Day1Solver : IDaySolver
{
    private readonly IRawInputProvider _rawInputProvider;
    private readonly ICalibrationProvider _calibrationProvider;
    private readonly ICalibrationFixer _calibrationFixer;

    public Day1Solver(IRawInputProvider rawInputProvider, ICalibrationProvider calibrationProvider, ICalibrationFixer calibrationFixer)
    {
        _rawInputProvider = rawInputProvider;
        _calibrationProvider = calibrationProvider;
        _calibrationFixer = calibrationFixer;
    }

    public async Task<long> SolveAsync()
    {
        var sum = 0;

        await foreach(var line in _rawInputProvider.ProvideRawInputAsync())
        {
            sum += _calibrationProvider.ProvideCalibration(line);
        }

        return sum;
    }

    public async Task<long> SolveBonusAsync()
    {
        var sum = 0;

        await foreach(var line in _rawInputProvider.ProvideRawInputAsync())
        {
            sum += _calibrationProvider.ProvideCalibration(_calibrationFixer.FixCalibrationLine(line));
        }

        return sum;
    }
}