using AoC_2023.Day1;
using FluentAssertions;

namespace AoC_2023_Tests;

public class CalibrationFixerTests
{
    private readonly CalibrationFixer _subject;

    public CalibrationFixerTests()
    {
        _subject = new CalibrationFixer();
    }

    [Theory]
    [InlineData("two1nine", "two21nine9")]
    [InlineData("eightwothree", "eight8wo2three3")]
    [InlineData("abcone2threexyz", "abcone12three3xyz")]
    [InlineData("xtwone3four", "xtwo2ne13four4")]
    [InlineData("4nineeightseven2", "4nine9eight8seven72")]
    [InlineData("zoneight234", "zone1ight8234")]
    [InlineData("7pqrstsixteen", "7pqrstsix6teen")]
    public void FixCalibrationLine_ThenFixCalibration(string line, string expectedLine)
    {
        var result = _subject.FixCalibrationLine(line);

        result.Should().Be(expectedLine);
    }
}