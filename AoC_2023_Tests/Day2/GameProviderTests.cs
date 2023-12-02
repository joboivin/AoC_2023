using AoC_2023.Day2;
using FluentAssertions;

namespace AoC_2023_Tests.Day2;

public class GameProviderTests
{
    private readonly GameProvider _subject = new();

    [Fact]
    public void ProvideGame_WhenLineHasId1_ThenGameIdIs1()
    {
        var line = "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green";

        var result = _subject.ProvideGame(line);

        result.Id.Should().Be(1);
    }

    [Fact]
    public void ProvideGame_WhenLineHasId2_ThenGameIdIs2()
    {
        var line = "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue";

        var result = _subject.ProvideGame(line);

        result.Id.Should().Be(2);
    }

    [Fact]
    public void ProvideGame_WhenLineHasId10_ThenGameIdIs10()
    {
        var line = "Game 10: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green";

        var result = _subject.ProvideGame(line);

        result.Id.Should().Be(10);
    }

    [Fact]
    public void ProvideGame_WhenLineHas1Set_ThenGameSetsCountIs1()
    {
        var line = "Game 1: 3 blue, 4 red";

        var result = _subject.ProvideGame(line);

        result.Sets.Should().HaveCount(1);
    }

    [Fact]
    public void ProvideGame_WhenLineHas2Sets_ThenGameSetsCountIs2()
    {
        var line = "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue";

        var result = _subject.ProvideGame(line);

        result.Sets.Should().HaveCount(2);
    }

    [Fact]
    public void ProvideGame_WhenLineHas3Sets_ThenGameSetsCountIs3()
    {
        var line = "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green";

        var result = _subject.ProvideGame(line);

        result.Sets.Should().HaveCount(3);
    }

    [Fact]
    public void ProvideGame_WhenLineHas1SetWithColorBlue_ThenColorCountIsExpected()
    {
        var line = "Game 1: 3 blue";

        var result = _subject.ProvideGame(line);

        result.Sets[0][Color.Red].Should().Be(0);
        result.Sets[0][Color.Green].Should().Be(0);
        result.Sets[0][Color.Blue].Should().Be(3);
    }

    [Fact]
    public void ProvideGame_WhenLineHas1SetWithColorRed_ThenColorCountIsExpected()
    {
        var line = "Game 1: 2 red";

        var result = _subject.ProvideGame(line);

        result.Sets[0][Color.Red].Should().Be(2);
        result.Sets[0][Color.Green].Should().Be(0);
        result.Sets[0][Color.Blue].Should().Be(0);
    }

    [Fact]
    public void ProvideGame_WhenLineHas1SetWithColorGreen_ThenColorCountIsExpected()
    {
        var line = "Game 1: 4 green";

        var result = _subject.ProvideGame(line);

        result.Sets[0][Color.Red].Should().Be(0);
        result.Sets[0][Color.Green].Should().Be(4);
        result.Sets[0][Color.Blue].Should().Be(0);
    }

    [Fact]
    public void ProvideGame_WhenLineHas1SetWithAllColors_ThenColorCountIsExpected()
    {
        var line = "Game 3: 8 green, 6 blue, 20 red";

        var result = _subject.ProvideGame(line);

        result.Sets[0][Color.Red].Should().Be(20);
        result.Sets[0][Color.Green].Should().Be(8);
        result.Sets[0][Color.Blue].Should().Be(6);
    }
}