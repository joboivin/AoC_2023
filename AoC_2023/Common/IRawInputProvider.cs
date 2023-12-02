namespace AoC_2023.Common;

internal interface IRawInputProvider
{
    IAsyncEnumerable<string> ProvideRawInputAsync();
}