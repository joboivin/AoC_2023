namespace AoC_2023.Day9;

internal interface IHistoryAnalyzer
{
    long DetermineNextValue(IEnumerable<long> history);
    long DeterminePreviousValue(IEnumerable<long> history);
}