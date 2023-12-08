namespace AoC_2023.Day7;

internal class HandComparer : BaseHandComparer
{
    private readonly Dictionary<char, int> _labelValues = new Dictionary<char, int>()
    {
        {'2', 0},
        {'3', 1},
        {'4', 2},
        {'5', 3},
        {'6', 4},
        {'7', 5},
        {'8', 6},
        {'9', 7},
        {'T', 8},
        {'J', 9},
        {'Q', 10},
        {'K', 11},
        {'A', 12}
    };

    protected override Dictionary<char, int> LabelValues => _labelValues;

    protected override HandType GetHandType(Hand hand)
        => hand.HandType;
}