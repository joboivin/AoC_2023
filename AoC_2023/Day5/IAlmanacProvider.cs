namespace AoC_2023.Day5;

internal interface IAlmanacProvider
{
    Task<Almanac> ProvideAlmanacAsync();
}