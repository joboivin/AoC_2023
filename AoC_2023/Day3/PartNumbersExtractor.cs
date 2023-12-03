

namespace AoC_2023.Day3;

internal class PartNumbersExtractor : IPartNumbersExtractor
{
    public IEnumerable<Part> ExtractPartNumbers(char[][] engineSchematic, bool considerGearsOnly)
    {
        for (var i = 0; i < engineSchematic.Length; i++)
        {
            for(var j = 0; j < engineSchematic[i].Length; j++)
            {
                if(char.IsDigit(engineSchematic[i][j]))
                {
                    var numberStartIndex = j;
                    
                    do
                        j++;
                    while(j < engineSchematic[i].Length && char.IsDigit(engineSchematic[i][j]));

                    j--;

                    if(IsPartNumber(engineSchematic, i, numberStartIndex, j, considerGearsOnly, out var part))
                        yield return part;
                }
            }
        }
    }

    private static bool IsPartNumber(char[][] engineSchematic, int lineIndex, int numberStartIndex, int numberEndIndex, bool considerGearsOnly, out Part part)
    {
        Func<char, bool> symbolDetector = considerGearsOnly ? IsGear : IsSymbol;

        part = new Part {Number = int.Parse(string.Concat(engineSchematic[lineIndex].Skip(numberStartIndex).Take(numberEndIndex - numberStartIndex + 1)))};
        var result = false;

        if(numberStartIndex > 0 && symbolDetector(engineSchematic[lineIndex][numberStartIndex - 1]))
        {
            result = true;
            part.NearbyGears.Add($"{lineIndex},{numberStartIndex - 1}");
        }

        if(numberEndIndex + 1 < engineSchematic[lineIndex].Length && symbolDetector(engineSchematic[lineIndex][numberEndIndex + 1]))
        {
            result = true;
            part.NearbyGears.Add($"{lineIndex},{numberEndIndex + 1}");
        }

        if(lineIndex > 0)
        {
            for(var i = numberStartIndex > 0 ? numberStartIndex - 1 : 0; i <= numberEndIndex + 1 && i < engineSchematic[lineIndex - 1].Length; i++)
                if(symbolDetector(engineSchematic[lineIndex - 1][i]))
                {
                    result = true;
                    part.NearbyGears.Add($"{lineIndex - 1},{i}");
                }
        }

        if(lineIndex + 1 < engineSchematic.Length)
        {
            for(var i = numberStartIndex > 0 ? numberStartIndex - 1 : 0; i <= numberEndIndex + 1 && i < engineSchematic[lineIndex + 1].Length; i++)
                if(symbolDetector(engineSchematic[lineIndex + 1][i]))
                {
                    result = true;
                    part.NearbyGears.Add($"{lineIndex + 1},{i}");
                }
        }

        return result;
    }

    private static bool IsSymbol(char engineSchematicChar)
        => !char.IsDigit(engineSchematicChar) && engineSchematicChar != '.';

    private static bool IsGear(char engineSchematicChar)
        => engineSchematicChar == '*';
}