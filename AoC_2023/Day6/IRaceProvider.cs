namespace AoC_2023.Day6;

internal interface IRaceProvider
{
    IAsyncEnumerable<Race> ProvideRacesAsync();
    Task<Race> ProvideSingleRaceAsync();
}