using AoC_2023.Day5;
using FluentAssertions;
using Xunit;

namespace AoC_2023_Tests.Day5;

public class DestinationCalculatorTests
{
    private readonly DestinationCalculator _subject = new DestinationCalculator();

    [Fact]
    public void CalculateDestination_WhenUsingFirstMapExampleAndSeed55_ThenDestinationIs57()
    {
        var map = CreateFirstExampleMap();

        var result = _subject.CalculateDestination(55, map);

        result.Should().Be(57);
    }

    [Fact]
    public void CalculateDestination_WhenUsingFirstMapExampleAndSeed14_ThenDestinationIs14()
    {
        var map = CreateFirstExampleMap();

        var result = _subject.CalculateDestination(14, map);

        result.Should().Be(14);
    }

    private Map CreateFirstExampleMap()
        => new Map
        {
            Entries = new List<MapEntry>()
            {
                new MapEntry {DestinationRangeStart = 50, SourceRangeStart = 98, RangeLength = 2},
                new MapEntry {DestinationRangeStart = 52, SourceRangeStart = 50, RangeLength = 48}
            }
        };
}