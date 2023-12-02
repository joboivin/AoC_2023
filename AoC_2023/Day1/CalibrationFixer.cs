namespace AoC_2023.Day1;

internal class CalibrationFixer : ICalibrationFixer
{
    public string FixCalibrationLine(string amendedLine)
    {
        var last3Chars = "";
        var last4Chars = "";
        var last5Chars = "";
        var fixedLine = "";
        var index = 0;

        foreach (var charInLine in amendedLine)
        {
            if(index < 5)
                last5Chars += charInLine;
            else
                last5Chars = last4Chars + charInLine;

            if(index < 4)
                last4Chars += charInLine;
            else
                last4Chars = last3Chars + charInLine;

            if(index < 3)
                last3Chars += charInLine;
            else
                last3Chars = $"{last3Chars[1]}{last3Chars[2]}{charInLine}";

            index++;
            fixedLine += charInLine;

            var extraChar = DetermineExtraChar(last3Chars, last4Chars, last5Chars);

            if(extraChar != ' ')
                fixedLine += extraChar;
        }

        return fixedLine;
    }

    private char DetermineExtraChar(string last3Chars, string last4Chars, string last5Chars)
    {
        if (last3Chars == "one")
            return '1';
        
        if (last3Chars == "two")
            return '2';

        if (last3Chars == "six")
            return '6';

        if (last4Chars == "four")
            return '4';

        if (last4Chars == "five")
            return '5';

        if (last4Chars == "nine")
            return '9';

        if (last5Chars == "three")
            return '3';

        if (last5Chars == "seven")
            return '7';

        if (last5Chars == "eight")
            return '8';

        return ' ';    
    }
}