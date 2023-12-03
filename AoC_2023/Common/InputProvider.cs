namespace AoC_2023.Common;

internal class InputProvider(IRawInputProvider rawInputProvider) : IInputProvider
{
    private readonly IRawInputProvider _rawInputProvider = rawInputProvider;

    public Task<char[][]> ProvideInputAsync()
    {
        return ProvideInputAsEnumerableAsync().ToArrayAsync().AsTask();
    }

    private async IAsyncEnumerable<char[]> ProvideInputAsEnumerableAsync()
    {
        await foreach (var line in _rawInputProvider.ProvideRawInputAsync())
        {
            yield return line.ToCharArray();
        }
    }
}