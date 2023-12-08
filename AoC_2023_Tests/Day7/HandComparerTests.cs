using AoC_2023.Day7;

namespace AoC_2023_Tests.Day7;

public class HandComparerTests
{
    private readonly HandComparer _subject = new HandComparer();

    [Fact]
    public void Compare_WhenFirstHandTypeIsBetterThenSecondHandType_ThenReturns1()
    {
        var firstHand = new Hand{ Labels= "AAAAA"};
        var secondHand = new Hand {Labels = "TTTT2"};

        var result = _subject.Compare(firstHand, secondHand);

        result.Should().Be(1);
    }

    [Fact]
    public void Compare_WhenFirstHandTypeIsWorseThenSecondHandType_ThenReturnsMinus1()
    {
        var firstHand = new Hand{ Labels= "QQQKK"};
        var secondHand = new Hand {Labels = "TTTT2"};

        var result = _subject.Compare(firstHand, secondHand);

        result.Should().Be(-1);
    }

    [Fact]
    public void Compare_WhenFirstHandTypeIsSameAsSecondHandTypeAndFirstHandFirstLabelIsBetter_ThenReturns1()
    {
        var firstHand = new Hand{ Labels= "AAAAA"};
        var secondHand = new Hand {Labels = "KKKKK"};

        var result = _subject.Compare(firstHand, secondHand);

        result.Should().Be(1);
    }

    [Fact]
    public void Compare_WhenFirstHandTypeIsSameAsSecondHandTypeAndFirstHandFirstLabelIsWorse_ThenReturnsMinus1()
    {
        var firstHand = new Hand{ Labels= "QQQQQ"};
        var secondHand = new Hand {Labels = "KKKKK"};

        var result = _subject.Compare(firstHand, secondHand);

        result.Should().Be(-1);
    }
}