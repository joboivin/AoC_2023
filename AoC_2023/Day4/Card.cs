namespace AoC_2023.Day4;

internal class Card
{
    public int Id { get; set; }
    public IList<int> WinningNumbers { get; set; }
    public IList<int> Numbers { get; set; }
}