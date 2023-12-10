using AoC_2023.Day9;

namespace AoC_2023_Tests.Day9;

public class HistoryAnalyzerTests
{
    private readonly HistoryAnalyzer _subject = new HistoryAnalyzer();

    [Fact]
    public void DetermineNextValue_WhenUsingFirstExample_ThenReturns18()
    {
        var history = new [] { 0L, 3L, 6L, 9L, 12L, 15L };

        var result = _subject.DetermineNextValue(history);

        result.Should().Be(18);
    }

    [Fact]
    public void DetermineNextValue_WhenUsingSecondExample_ThenReturns28()
    {
        var history = new [] { 1L, 3L, 6L, 10L, 15L, 21L };

        var result = _subject.DetermineNextValue(history);

        result.Should().Be(28);
    }

    [Fact]
    public void DetermineNextValue_WhenUsingThirdExample_ThenReturns68()
    {
        var history = new [] { 10L, 13L, 16L, 21L, 30L, 45L };

        var result = _subject.DetermineNextValue(history);

        result.Should().Be(68);
    }

    [Fact]
    public void DeterminePreviousValue_WhenUsingFirstExample_ThenReturnsMinus3()
    {
        var history = new [] { 0L, 3L, 6L, 9L, 12L, 15L };

        var result = _subject.DeterminePreviousValue(history);

        result.Should().Be(-3);
    }

    [Fact]
    public void DeterminePreviousValue_WhenUsingSecondExample_ThenReturns0()
    {
        var history = new [] { 1L, 3L, 6L, 10L, 15L, 21L };

        var result = _subject.DeterminePreviousValue(history);

        result.Should().Be(0);
    }

    [Fact]
    public void DeterminePreviousValue_WhenUsingThirdExample_ThenReturns5()
    {
        var history = new [] { 10L, 13L, 16L, 21L, 30L, 45L };

        var result = _subject.DeterminePreviousValue(history);

        result.Should().Be(5);
    }
}