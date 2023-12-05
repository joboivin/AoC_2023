namespace AoC_2023.Day5;

internal class DestinationCalculator : IDestinationCalculator
{
    public long CalculateDestination(long sourceNumber, Map map)
    {
        foreach(var entry in map.Entries)
        {
            if(sourceNumber >= entry.SourceRangeStart && sourceNumber < entry.SourceRangeStart + entry.RangeLength)
                return entry.DestinationRangeStart + (sourceNumber - entry.SourceRangeStart);
        }

        return sourceNumber;
    }
}