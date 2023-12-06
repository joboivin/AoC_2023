using AoC_2023.Day6;
using FluentAssertions;
using Xunit;

namespace AoC_2023_Tests.Day6;

public class WinningWaysCalculatorTests
{
    private readonly WinningWaysCalculator _subject = new WinningWaysCalculator();

    [Fact]
    public void CalculateWinningWays_WhenUsingFirstExample_Then4WinningWays()
    {
        var race = new Race { Time = 7, Distance = 9 };

        var result = _subject.CalculateWinningWays(race);

        result.Should().Be(4);
    }

    [Fact]
    public void CalculateWinningWays_WhenUsingSecondExample_Then8WinningWays()
    {
        var race = new Race { Time = 15, Distance = 40 };

        var result = _subject.CalculateWinningWays(race);

        result.Should().Be(8);
    }

    [Fact]
    public void CalculateWinningWays_WhenUsingThirdExample_Then9WinningWays()
    {
        var race = new Race { Time = 30, Distance = 200 };

        var result = _subject.CalculateWinningWays(race);

        result.Should().Be(9);
    }
}