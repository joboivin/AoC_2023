
using AoC_2023.Common;

namespace AoC_2023.Day4;

internal class Day4Solver(IRawInputProvider rawInputProvider, ICardProvider cardProvider) : IDaySolver
{
    private readonly IRawInputProvider _rawInputProvider = rawInputProvider;
    private readonly ICardProvider _cardProvider = cardProvider;

    public async Task<int> SolveAsync()
    {
        var pointsSum = 0;

        await foreach(var line in _rawInputProvider.ProvideRawInputAsync())
        {
            var card = _cardProvider.ProvideCard(line);

            var numberOfWinningNumbersPresent = card.Numbers.Count(n => card.WinningNumbers.Contains(n));

            pointsSum += (int)Math.Pow(2, numberOfWinningNumbersPresent - 1);
        }

        return pointsSum;
    }

    public async Task<int> SolveBonusAsync()
    {
        var cardsTotal = new Dictionary<int, int>();

        await foreach(var line in _rawInputProvider.ProvideRawInputAsync())
        {
            var card = _cardProvider.ProvideCard(line);
            
            IncrementTotalNumberOfSpecificCard(cardsTotal, card.Id, 1);

            var numberOfWinningNumbersPresent = card.Numbers.Count(n => card.WinningNumbers.Contains(n));

            for(var i = 1; i <= numberOfWinningNumbersPresent; i++)
                IncrementTotalNumberOfSpecificCard(cardsTotal, card.Id + i, cardsTotal[card.Id]);
        }

        return cardsTotal.Values.Sum();
    }

    private void IncrementTotalNumberOfSpecificCard(Dictionary<int, int> cardsTotal, int cardId, int numberOfCopies)
    {
        if(cardsTotal.TryGetValue(cardId, out int value))
        {
            cardsTotal[cardId] = value + numberOfCopies;
        }
        else
            cardsTotal.Add(cardId, numberOfCopies);
    }
}