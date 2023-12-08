using AoC_2023.Day7;
using FluentAssertions;

namespace AoC_2023_Tests.Day7;

public class HandTests
{
    [Theory]
    [InlineData("AAAAA", HandType.FiveOfAKind)]
    [InlineData("AA8AA", HandType.FourOfAKind)]
    [InlineData("23332", HandType.FullHouse)]
    [InlineData("TTT98", HandType.ThreeOfAKind)]
    [InlineData("23432", HandType.TwoPair)]
    [InlineData("A23A4", HandType.OnePair)]
    [InlineData("23456", HandType.HighCard)]
    public void HandType_ThenReturnsExpectedHandType(string labels, HandType expectedHandType)
    {
        var subject = new Hand { Labels = labels };

        var result = subject.HandType;

        result.Should().Be(expectedHandType);
    }

    [Theory]
    [InlineData("AAAAA", HandType.FiveOfAKind)]
    [InlineData("AA8AA", HandType.FourOfAKind)]
    [InlineData("23332", HandType.FullHouse)]
    [InlineData("TTT98", HandType.ThreeOfAKind)]
    [InlineData("23432", HandType.TwoPair)]
    [InlineData("A23A4", HandType.OnePair)]
    [InlineData("23456", HandType.HighCard)]
    [InlineData("JJJJJ", HandType.FiveOfAKind)]
    [InlineData("AJJJJ", HandType.FiveOfAKind)]
    [InlineData("AQJJJ", HandType.FourOfAKind)]
    [InlineData("T55J5", HandType.FourOfAKind)]
    public void BonusHandType_ThenReturnsExpectedHandType(string labels, HandType expectedHandType)
    {
        var subject = new Hand { Labels = labels };

        var result = subject.BonusHandType;

        result.Should().Be(expectedHandType);
    }
}