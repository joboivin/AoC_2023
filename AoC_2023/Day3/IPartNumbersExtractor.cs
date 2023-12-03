namespace AoC_2023.Day3;

internal interface IPartNumbersExtractor
{
    IEnumerable<Part> ExtractPartNumbers(char[][] engineSchematic, bool considerGearsOmly);
}