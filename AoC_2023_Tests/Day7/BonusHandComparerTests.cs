using AoC_2023.Day7;

namespace AoC_2023_Tests.Day7;

public class BonusHandComparerTests
 {
    private readonly BonusHandComparer _subject = new BonusHandComparer();

    [Fact]
    public void Compare_WhenFirstHandTypeIsBetterThenSecondHandType_ThenReturns1()
    {
        var firstHand = new Hand{ Labels= "AAAJJ"};
        var secondHand = new Hand {Labels = "AAAKK"};

        var result = _subject.Compare(firstHand, secondHand);

        result.Should().Be(1);
    }

    [Fact]
    public void Compare_WhenFirstHandTypeIsWorseThenSecondHandType_ThenReturnsMinus1()
    {
        var firstHand = new Hand{ Labels= "QQQQ2"};
        var secondHand = new Hand {Labels = "QQQQJ"};

        var result = _subject.Compare(firstHand, secondHand);

        result.Should().Be(-1);
    }

    [Fact]
    public void Compare_WhenFirstHandTypeIsSameAsSecondHandTypeAndFirstHandLabelsAreBetter_ThenReturns1()
    {
        var firstHand = new Hand{ Labels= "22K22"};
        var secondHand = new Hand {Labels = "22KJJ"};

        var result = _subject.Compare(firstHand, secondHand);

        result.Should().Be(1);
    }

    [Fact]
    public void Compare_WhenFirstHandTypeIsSameAsSecondHandTypeAndFirstHandLabelsAreWorse_ThenReturnsMinus1()
    {
        var firstHand = new Hand{ Labels= "JJJJJ"};
        var secondHand = new Hand {Labels = "33333"};

        var result = _subject.Compare(firstHand, secondHand);

        result.Should().Be(-1);
    }
 }