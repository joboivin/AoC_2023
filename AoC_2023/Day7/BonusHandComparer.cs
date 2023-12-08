namespace AoC_2023.Day7;

internal class BonusHandComparer : BaseHandComparer
{
    private readonly Dictionary<char, int> _labelValues = new Dictionary<char, int>()
    {
        {'J', 0},
        {'2', 1},
        {'3', 2},
        {'4', 3},
        {'5', 4},
        {'6', 5},
        {'7', 6},
        {'8', 7},
        {'9', 8},
        {'T', 9},
        {'Q', 10},
        {'K', 11},
        {'A', 12}
    };

    protected override Dictionary<char, int> LabelValues => _labelValues;

    protected override HandType GetHandType(Hand hand)
        => hand.BonusHandType;
}