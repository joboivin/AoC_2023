namespace AoC_2023.Day7;

internal class Hand
{
    public static int NumberOfLabels => 5;

    public int Bid { get; set; }
    public string Labels { get; set; }

    public HandType HandType
    {
        get
        {
            var numberOfLabelsExpanded = GetNumberOfLabelsExpanded(true);

            return numberOfLabelsExpanded switch
            {
                "5" => HandType.FiveOfAKind,
                "14" => HandType.FourOfAKind,
                "23" => HandType.FullHouse,
                "113" => HandType.ThreeOfAKind,
                "122" => HandType.TwoPair,
                "1112" => HandType.OnePair,
                _ => HandType.HighCard,
            };
        }
    }

    public HandType BonusHandType
    {
        get
        {
            var numberOfJokers = Labels.Count(x => x =='J');
            
            if(numberOfJokers == 0)
                return HandType;
            
            if(numberOfJokers == 4 || numberOfJokers == 5)
                return HandType.FiveOfAKind;
            
            var numberOfLabelsExpanded = GetNumberOfLabelsExpanded(false);
            
            if(numberOfJokers == 3)
            {
                return numberOfLabelsExpanded switch
                {
                    "2" => HandType.FiveOfAKind,
                    _ => HandType.FourOfAKind
                };
            }

            if(numberOfJokers == 2)
            {
                return numberOfLabelsExpanded switch
                {
                    "3" => HandType.FiveOfAKind,
                    "12" => HandType.FourOfAKind,
                    _ => HandType.ThreeOfAKind
                };
            }

            return numberOfLabelsExpanded switch
            {
                "4" => HandType.FiveOfAKind,
                "13" => HandType.FourOfAKind,
                "22" => HandType.FullHouse,
                "112" => HandType.ThreeOfAKind,
                _ => HandType.OnePair,
            };
        }
    }

    private string GetNumberOfLabelsExpanded(bool includeJokers)
    {
        var occurencesOfLabel = new Dictionary<char, int>();

        for(var i = 0; i < NumberOfLabels; i++)
        {
            if(includeJokers || Labels[i] != 'J')
            {
                if(occurencesOfLabel.TryGetValue(Labels[i], out var number))
                    occurencesOfLabel[Labels[i]] = number + 1;
                else
                    occurencesOfLabel.Add(Labels[i], 1);
            }
        }

        return occurencesOfLabel.Values.Order().Aggregate(string.Empty, (x, y) => $"{x}{y}");
    }
}