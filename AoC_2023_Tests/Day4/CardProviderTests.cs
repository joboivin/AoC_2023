using AoC_2023.Day4;
using FluentAssertions;

namespace AoC_2023_Tests.Day4;

public class CardProviderTests
{
    private readonly CardProvider _subject = new();

    [Fact]
    public void ProvideCard_WhenLineHasId1_ThenCardIdIs1()
    {
        var line = "Card  1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53";

        var result = _subject.ProvideCard(line);

        result.Id.Should().Be(1);
    }

    [Fact]
    public void ProvideCard_WhenLineHasId2_ThenCardIdIs2()
    {
        var line = "Card  2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19";

        var result = _subject.ProvideCard(line);

        result.Id.Should().Be(2);
    }

    [Fact]
    public void ProvideCard_WhenLineHasId12_ThenCardIdIs12()
    {
        var line = "Card 12: 13 32 20 16 61 | 61 30 68 82 17 32 24 19";

        var result = _subject.ProvideCard(line);

        result.Id.Should().Be(12);
    }

    [Fact]
    public void ProvideCard_WhenLineHas1WinningNumber_ThenCardHas1WinningNumber()
    {
        var line = "Card  2: 11 | 61 30 68 82 17 32 24 19";

        var result = _subject.ProvideCard(line);

        result.WinningNumbers.Should().ContainSingle().Which.Should().Be(11);
    }

    [Fact]
    public void ProvideCard_WhenLineHas2WinningNumbers_ThenCardHas2WinningNumbers()
    {
        var line = "Card  2: 11  2 | 61 30 68 82 17 32 24 19";

        var result = _subject.ProvideCard(line);

        result.WinningNumbers.Should().HaveCount(2);
        result.WinningNumbers.Should().Contain(11).And.Contain(2);
    }

    [Fact]
    public void ProvideCard_WhenLineHas1Number_ThenCardHas1Number()
    {
        var line = "Card 12: 13 32 20 16 61 | 61";

        var result = _subject.ProvideCard(line);

        result.Numbers.Should().ContainSingle().Which.Should().Be(61);
    }

    [Fact]
    public void ProvideCard_WhenLineHas2Numbers_ThenCardHas2Numbers()
    {
        var line = "Card 12: 13 32 20 16 61 | 61  3";

        var result = _subject.ProvideCard(line);

        result.Numbers.Should().HaveCount(2);
        result.Numbers.Should().Contain(61).And.Contain(3);
    }
}