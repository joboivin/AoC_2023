using AoC_2023.Day1;
using FluentAssertions;

namespace AoC_2023_Tests;

public class CalibrationProviderTests
{
    private readonly CalibrationProvider _subject;

    public CalibrationProviderTests()
    {
        _subject = new CalibrationProvider();
    }

    [Fact]
    public void ProvideCalibration_WhenLineContainsOnly2Digits_ThenReturnsExpectedCalibration()
    {
        var line = "12";

        var result = _subject.ProvideCalibration(line);

        result.Should().Be(12);
    }

    [Theory]
    [InlineData("aaa21", 21)]
    [InlineData("3aaa4", 34)]
    [InlineData("51fjrfv", 51)]
    [InlineData("a2d3g", 23)]
    public void ProvideCalibration_WhenLineContains2DigitsWithTextInBetween_ThenReturnsExpectedCalibration(string line, int expected)
    {
        var result = _subject.ProvideCalibration(line);

        result.Should().Be(expected);
    }

    [Fact]
    public void ProvideCalibration_WhenLineContainsOnly1Digit_ThenReturnsExpectedCalibration()
    {
        var line = "a1b";

        var result = _subject.ProvideCalibration(line);

        result.Should().Be(11);
    }

    [Fact]
    public void ProvideCalibration_WhenLineContainsMoreThan2Digits_ThenReturnsExpectedCalibration()
    {
        var line = "a1s2d3f4g5h";

        var result = _subject.ProvideCalibration(line);

        result.Should().Be(15);
    }
}