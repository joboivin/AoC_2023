using AoC_2023.Common;

namespace AoC_2023.Day7;

internal class HandsProvider(IRawInputProvider rawInputProvider) : IHandsProvider
{
    private readonly IRawInputProvider _rawInputProvider = rawInputProvider;

    public async IAsyncEnumerable<Hand> ProvideHandsAsync()
    {
        await foreach(var line in _rawInputProvider.ProvideRawInputAsync())
        {
            yield return new Hand() {
                Labels = line[..5],
                Bid = int.Parse(line[6..])
            };
        }
    }
}