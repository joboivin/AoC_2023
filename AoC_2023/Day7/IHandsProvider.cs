namespace AoC_2023.Day7;

internal interface IHandsProvider
{
    IAsyncEnumerable<Hand> ProvideHandsAsync();
}