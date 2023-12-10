using System.Security.Cryptography.X509Certificates;
using AoC_2023.Common;

namespace AoC_2023.Day9;

internal class HistoriesProvider(IRawInputProvider rawInputProvider) : IHistoriesProvider
{
    private readonly IRawInputProvider _rawInputProvider = rawInputProvider;

    public async IAsyncEnumerable<IEnumerable<long>> ProvideHistoriesAsync()
    {
        await foreach(var line in _rawInputProvider.ProvideRawInputAsync())
            yield return line.Split(' ').Select(x => long.Parse(x));
    }
}