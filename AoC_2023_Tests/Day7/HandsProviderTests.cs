using AoC_2023.Common;
using AoC_2023.Day7;
using NSubstitute;

namespace AoC_2023_Tests.Day7;

public class HandsProviderTests
{
    private readonly IRawInputProvider _rawInputProvider;

    private readonly HandsProvider _subject;

    public HandsProviderTests()
    {
        _rawInputProvider = Substitute.For<IRawInputProvider>();

        _subject = new HandsProvider(_rawInputProvider);
    }

    [Fact]
    public async Task ProvideHandsAsync_WhenUsingExampleInput_ThenReturnsExpectedResult()
    {
        SetupRawInputProvider();

        var result = await _subject.ProvideHandsAsync().ToListAsync();

        result.Should().HaveCount(5);
        result.Should().Contain(x => x.Labels == "32T3K" && x.Bid == 765);
        result.Should().Contain(x => x.Labels == "KK677" && x.Bid == 28);
    }

    private void SetupRawInputProvider()
    {
        _rawInputProvider.ProvideRawInputAsync().Returns(new List<string> {
            "32T3K 765",
            "T55J5 684",
            "KK677 28",
            "KTJJT 220",
            "QQQJA 483"
        }.ToAsyncEnumerable());
    }
}