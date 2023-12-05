using AoC_2023.Day5;
using Xunit;
using FluentAssertions;
using AoC_2023.Common;
using NSubstitute;

namespace AoC_2023_Tests.Day5;

public class AlmanacProviderTests
{
    private readonly IRawInputProvider _rawInputProvider;
    
    private readonly AlmanacProvider _subject;

    public AlmanacProviderTests()
    {
        _rawInputProvider = Substitute.For<IRawInputProvider>();

        _subject = new AlmanacProvider(_rawInputProvider);
    }

    [Fact]
    public async Task ProvideAlmanacAsync_WhenUsingExampleInput_Then4SeedsPresent()
    {
        SetupRawInputProvider();

        var result = await _subject.ProvideAlmanacAsync();

        result.Seeds.Should().HaveCount(4);
        result.Seeds.Should().Contain(79);
        result.Seeds.Should().Contain(14);
        result.Seeds.Should().Contain(55);
        result.Seeds.Should().Contain(13);
    }

    [Fact]
    public async Task ProvideAlmanacAsync_WhenUsingExampleInput_Then2MapsPresent()
    {
        SetupRawInputProvider();

        var result = await _subject.ProvideAlmanacAsync();

        result.Maps.Should().HaveCount(2);
        result.Maps[0].Entries.Should().HaveCount(2);
        result.Maps[1].Entries.Should().HaveCount(3);
    }

    private void SetupRawInputProvider()
    {
        _rawInputProvider.ProvideRawInputAsync().Returns(new List<string> {
            "seeds: 79 14 55 13",
            "",
            "seed-to-soil map:",
            "50 98 2",
            "52 50 48",
            "",
            "soil-to-fertilizer map:",
            "0 15 37",
            "37 52 2",
            "39 0 15"
        }.ToAsyncEnumerable());
    }
}