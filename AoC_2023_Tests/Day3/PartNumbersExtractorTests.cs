using AoC_2023.Day3;
using FluentAssertions;

namespace AoC_2023_Tests.Day3;

public class PartNumbersExtractorTests
{
    private readonly PartNumbersExtractor _subject = new PartNumbersExtractor();
    
    [Fact]
    public void ExtractPartNumbers_When1LineWithNoPartNumbersAndConsiderAllSymbols_ThenReturnsEmptyList()
    {
        var engineSchematic = new [] {new [] {'6', '5', '4', '.', '.'}};

        var result = _subject.ExtractPartNumbers(engineSchematic, false);

        result.Should().BeEmpty();
    }

    [Fact]
    public void ExtractPartNumbers_When1LineWithAPartNumbersWithSymbolAfterAndConsiderAllSymbols_ThenReturnsPartNumber()
    {
        var engineSchematic = new [] {new [] {'6', '5', '4', '$', '.'}};

        var result = _subject.ExtractPartNumbers(engineSchematic, false);

        result.Should().ContainSingle().Which.Number.Should().Be(654);
    }

    [Fact]
    public void ExtractPartNumbers_When1LineWithAPartNumbersWithSymbolBeforeAndConsiderAllSymbols_ThenReturnsPartNumber()
    {
        var engineSchematic = new [] {new [] {'.', '$', '4', '.', '.'}};

        var result = _subject.ExtractPartNumbers(engineSchematic, false);

        result.Should().ContainSingle().Which.Number.Should().Be(4);
    }

    [Fact]
    public void ExtractPartNumbers_When2LinesWithAPartNumbersWithSymbolBeforeAndConsiderAllSymbols_ThenReturnsPartNumber()
    {
        var engineSchematic = new [] {new [] {'.', '.', '.', '*', '.', '.', '.', '.', '.', '.'},
            new [] {'.', '.', '3', '5', '.', '.', '6', '3', '3', '.'}};

        var result = _subject.ExtractPartNumbers(engineSchematic, false);

        result.Should().ContainSingle().Which.Number.Should().Be(35);
    }

    [Fact]
    public void ExtractPartNumbers_When2LinesWithAPartNumbersWithSymbolAfterAndConsiderAllSymbols_ThenReturnsPartNumber()
    {
        var engineSchematic = new [] {new [] {'4', '6', '7', '.', '.', '1', '1', '4', '.', '.'},
            new [] {'.', '.', '.', '*', '.', '.', '.', '.', '.', '.'}};

        var result = _subject.ExtractPartNumbers(engineSchematic, false);

        result.Should().ContainSingle().Which.Number.Should().Be(467);
    }

    [Fact]
    public void ExtractPartNumbers_When1LineWithNoPartNumbersAndConsiderOnlyGears_ThenReturnsEmptyList()
    {
        var engineSchematic = new [] {new [] {'6', '5', '4', '.', '.'}};

        var result = _subject.ExtractPartNumbers(engineSchematic, true);

        result.Should().BeEmpty();
    }

    [Fact]
    public void ExtractPartNumbers_When1LineWithAPartNumbersWithSymbolNotGearAfterAndConsiderOnlyGears_ThenReturnsEmptyList()
    {
        var engineSchematic = new [] {new [] {'6', '5', '4', '$', '.'}};

        var result = _subject.ExtractPartNumbers(engineSchematic, true);

        result.Should().BeEmpty();
    }

    [Fact]
    public void ExtractPartNumbers_When1LineWithAPartNumbersWithSymbolAfterAndConsiderOnlyGears_ThenReturnsPartNumber()
    {
        var engineSchematic = new [] {new [] {'6', '5', '4', '*', '.'}};

        var result = _subject.ExtractPartNumbers(engineSchematic, true);

        result.Should().ContainSingle().Which.Number.Should().Be(654);
        result.Single().NearbyGears.Should().ContainSingle().Which.Should().Be("0,3");
    }
}