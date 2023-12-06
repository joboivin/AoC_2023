using AoC_2023.Common;
using AoC_2023.Day6;
using FluentAssertions;
using Xunit;
using NSubstitute;

namespace AoC_2023_Tests.Day6;

public class RaceProviderTests
{
    private readonly IRawInputProvider _rawInputProvider;

    private readonly RaceProvider _subject;

    public RaceProviderTests()
    {
        _rawInputProvider = Substitute.For<IRawInputProvider>();

        _subject = new RaceProvider(_rawInputProvider);
    }

    [Fact]
    public async Task ProvideRacesAsync_WhenUsingExampleInput_ThenExpectedRaces()
    {
        SetupRawInputProvider();

        var result = await _subject.ProvideRacesAsync().ToListAsync();

        result.Should().HaveCount(3);
        result.Should().Contain(x => x.Time == 7 && x.Distance == 9);
        result.Should().Contain(x => x.Time == 15 && x.Distance == 40);
        result.Should().Contain(x => x.Time == 30 && x.Distance == 200);
    }

    [Fact]
    public async Task ProvideSingleRaceAsync_WhenUsingExampleInput_ThenExpectedRace()
    {
        SetupRawInputProvider();

        var result = await _subject.ProvideSingleRaceAsync();

        result.Time.Should().Be(71530);
        result.Distance.Should().Be(940200);
    }

    private void SetupRawInputProvider()
    {
        _rawInputProvider.ProvideRawInputAsync().Returns(new List<string> {
            "Time:      7  15   30",
            "Distance:  9  40  200",
        }.ToAsyncEnumerable());
    }
}