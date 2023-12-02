namespace AoC_2023.Day1;

internal class CalibrationProvider : ICalibrationProvider
{
    private static readonly char[] _digits = {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};

    public int ProvideCalibration(string amendedLine)
    {
        var (firstDigit, lastDigit) = DetermineCalibrationDigits(amendedLine);
        var calibration = $"{firstDigit}{lastDigit}";
        
        return Int32.Parse(calibration);
    }

    private (char, char) DetermineCalibrationDigits(string amendedLine)
    {
        var firstDigit = ' ';
        var lastDigit = ' ';
        var firstDigitAlreadyFound = false;

        foreach(var charInLine in amendedLine)
            if(_digits.Contains(charInLine))
            {
                lastDigit = charInLine;

                if(!firstDigitAlreadyFound)
                {
                    firstDigit = charInLine;
                    firstDigitAlreadyFound = true;
                }
            }

        return (firstDigit, lastDigit);
    }
}