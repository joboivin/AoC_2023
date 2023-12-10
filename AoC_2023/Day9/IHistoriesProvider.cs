namespace AoC_2023.Day9;

internal interface IHistoriesProvider
{
    IAsyncEnumerable<IEnumerable<long>> ProvideHistoriesAsync();
}