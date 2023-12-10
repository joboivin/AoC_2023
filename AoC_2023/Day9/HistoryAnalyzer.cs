
namespace AoC_2023.Day9;

internal class HistoryAnalyzer : IHistoryAnalyzer
{
    public long DetermineNextValue(IEnumerable<long> history)
    {
        var differenceOfValues = AnalyzeDifferences(history.ToList());

        return DeterminetNextValue(differenceOfValues);
    }

    private static IList<IList<long>> AnalyzeDifferences(IList<long> history)
    {
        var differenceOfValues = new List<IList<long>>() { history.ToList() };
        var numberOfSteps = 0;
        var numberOfValues = differenceOfValues[0].Count;

        while(differenceOfValues[numberOfSteps].Any(x => x != 0))
        {
            numberOfValues--;

            var newDifferenceOfValues = new List<long>();

            for(var i = 0; i < numberOfValues; i++)
            {
                newDifferenceOfValues.Add(differenceOfValues[numberOfSteps][i + 1] - differenceOfValues[numberOfSteps][i]);
            }

            numberOfSteps++;
            differenceOfValues.Add(newDifferenceOfValues);
        }

        return differenceOfValues;
    }

    private static long DeterminetNextValue(IList<IList<long>> differenceOfValues)
    {
        differenceOfValues.Last().Add(0);

        for(var i = differenceOfValues.Count - 2; i >= 0; i--)
        {
            var difference = differenceOfValues[i + 1].Last();
            differenceOfValues[i].Add(differenceOfValues[i].Last() + difference);
        }

        return differenceOfValues[0].Last();
    }

    public long DeterminePreviousValue(IEnumerable<long> history)
    {
        var differenceOfValues = AnalyzeDifferences(history.ToList());
        
        return DeterminePreviousValue(differenceOfValues);
    }

    private static long DeterminePreviousValue(IList<IList<long>> differenceOfValues)
    {
        differenceOfValues.Last().Add(0);

        for(var i = differenceOfValues.Count - 2; i >= 0; i--)
        {
            var difference = differenceOfValues[i + 1].Last();
            differenceOfValues[i].Add(differenceOfValues[i][0] - difference);
        }

        return differenceOfValues[0].Last();
    }
}