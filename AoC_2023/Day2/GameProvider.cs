using System.Text.RegularExpressions;

namespace AoC_2023.Day2;

internal partial class GameProvider : IGameProvider
{
    [GeneratedRegex("^Game (\\d*): (.*)$")]
    private static partial Regex GameRegex();

    public Game ProvideGame(string line)
    {
        var gameResult = GameRegex().Match(line);

        return new Game {Id = int.Parse(gameResult.Groups[1].Value), Sets = ProvideSets(gameResult.Groups[2].Value).ToList()};
    }

    private static IEnumerable<IDictionary<Color, int>> ProvideSets(string setsLine)
    {
        foreach(var setLine in setsLine.Split("; "))
            yield return ProvideSet(setLine);
    }

    private static IDictionary<Color, int> ProvideSet(string setLine)
    {
        var dictionnary = new Dictionary<Color, int> {{Color.Green, 0}, {Color.Red, 0}, {Color.Blue, 0}};

        foreach(var cubeCount in setLine.Split(", "))
        {
            var cubeInfo = cubeCount.Split(' ');
            var color = DetermineColor(cubeInfo[1]);
            
            dictionnary[color] = int.Parse(cubeInfo[0]);
        }

        return dictionnary;
    }

    private static Color DetermineColor(string colorText)
    {
        if(colorText == "green")
            return Color.Green;

        return colorText == "blue" ? Color.Blue : Color.Red;
    }
}