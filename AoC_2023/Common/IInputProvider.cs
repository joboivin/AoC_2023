namespace AoC_2023.Common;

internal interface IInputProvider
{
    Task<char[][]> ProvideInputAsync();
}