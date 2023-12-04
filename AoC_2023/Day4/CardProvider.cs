using System.Text.RegularExpressions;

namespace AoC_2023.Day4;

internal partial class CardProvider : ICardProvider
{
    [GeneratedRegex("^Card *(\\d*): (.*) \\| (.*)$")]
    private static partial Regex CardRegex();

    public Card ProvideCard(string line)
    {
        var cardResult = CardRegex().Match(line);

        return new Card {Id = int.Parse(cardResult.Groups[1].Value), WinningNumbers = ProvideNumbers(cardResult.Groups[2].Value).ToList(), 
             Numbers = ProvideNumbers(cardResult.Groups[3].Value).ToList()};
    }

    private static IEnumerable<int> ProvideNumbers(string numbers)
    {
        foreach(var number in numbers.Split(" "))
            if(!string.IsNullOrWhiteSpace(number))
                yield return int.Parse(number);
    }
}